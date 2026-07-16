Imports NAudio.Wave
Imports System.IO
Imports System.Threading

Public Class Form1
    Private outputDevice As WaveOutEvent
    Private streamReader As MediaFoundationReader
    Private adReader As AudioFileReader

    Private isAdPlaying As Boolean = False
    Private adIntervalSeconds As Integer = 300
    Private localAdPath As String = ""
    Private streamUrl As String = ""

    Public radioVolumeMultiplier As Single = 1.0F
    Public adVolumeMultiplier As Single = 1.0F
    Public isScheduleEnabled As Boolean = False
    Public scheduleStart As TimeSpan = New TimeSpan(8, 0, 0)
    Public scheduleEnd As TimeSpan = New TimeSpan(23, 0, 0)

    Private isSystemRunning As Boolean = False
    Private isConnecting As Boolean = False

    Private WithEvents reconnectTimer As New System.Windows.Forms.Timer()
    Private WithEvents scheduleCheckTimer As New System.Windows.Forms.Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default

        reconnectTimer.Interval = 5000
        scheduleCheckTimer.Interval = 10000
        scheduleCheckTimer.Start()

        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

    Public Sub UpdateLiveVolume()
        If outputDevice IsNot Nothing AndAlso outputDevice.PlaybackState = PlaybackState.Playing Then
            If isAdPlaying Then
                outputDevice.Volume = adVolumeMultiplier
            Else
                outputDevice.Volume = radioVolumeMultiplier
            End If
        End If
    End Sub

    Private Function IsWithinSchedule() As Boolean
        If Not isScheduleEnabled Then Return True

        Dim nowTime As TimeSpan = DateTime.Now.TimeOfDay
        If scheduleStart <= scheduleEnd Then
            Return (nowTime >= scheduleStart AndAlso nowTime <= scheduleEnd)
        Else
            Return (nowTime >= scheduleStart OrElse nowTime <= scheduleEnd)
        End If
    End Function

    Private Sub scheduleCheckTimer_Tick(sender As Object, e As EventArgs) Handles scheduleCheckTimer.Tick
        If isSystemRunning AndAlso Not isConnecting Then
            If Not IsWithinSchedule() Then
                If outputDevice IsNot Nothing AndAlso outputDevice.PlaybackState = PlaybackState.Playing Then
                    StopAllAudioResources()
                    Timer1.Stop()
                    reconnectTimer.Stop()
                    lblStatus.Text = "Status: Outside Active Hours (Muted)"
                    lblStatus.ForeColor = Color.Purple
                End If
            Else
                If outputDevice Is Nothing OrElse outputDevice.PlaybackState = PlaybackState.Stopped Then
                    StartSystem()
                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Audio files (*.wav;*.mp3)|*.wav;*.mp3"
            ofd.Title = "Select Audio Advertisement File"
            ofd.Multiselect = False
            If ofd.ShowDialog() = DialogResult.OK Then
                TextBox3.Text = ofd.FileName
                localAdPath = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        streamUrl = TextBox1.Text.Trim()
        localAdPath = TextBox3.Text.Trim()

        If String.IsNullOrEmpty(streamUrl) OrElse String.IsNullOrEmpty(localAdPath) Then
            MessageBox.Show("Please enter a valid stream URL and select an advertisement file.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not File.Exists(localAdPath) Then
            MessageBox.Show("The selected audio file does not exist. Please browse and select a valid file.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not Integer.TryParse(TextBox2.Text, adIntervalSeconds) OrElse adIntervalSeconds <= 0 Then
            MessageBox.Show("Please enter a valid interval in seconds (integer greater than 0).", "Invalid Interval", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        isSystemRunning = True
        SetInputControlsState(False)

        If Not IsWithinSchedule() Then
            MessageBox.Show("The current time is outside active scheduled hours. The system will start automatically when active hours begin.", "Schedule Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Enabled = False
            Button2.Enabled = True
            lblStatus.Text = "Status: Outside Active Hours (Muted)"
            lblStatus.ForeColor = Color.Purple
            Exit Sub
        End If

        StartSystem()
    End Sub

    Private Sub SetInputControlsState(enabled As Boolean)
        TextBox1.Enabled = enabled
        TextBox2.Enabled = enabled
        TextBox3.Enabled = enabled
        Button3.Enabled = enabled
    End Sub

    Private Sub StartSystem()
        lblStatus.Text = "Status: Connecting to stream..."
        lblStatus.ForeColor = Color.Orange
        Button1.Enabled = False
        Button2.Enabled = True
        isConnecting = True

        Dim t As New Thread(New ThreadStart(AddressOf ConnectToStreamBackground))
        t.IsBackground = True
        t.Start()
    End Sub

    Private Sub ConnectToStreamBackground()
        Try
            Dim tempReader As New MediaFoundationReader(streamUrl)

            Me.Invoke(Sub()
                          reconnectTimer.Stop()
                          StopAllAudioResources()

                          If outputDevice Is Nothing Then
                              outputDevice = New WaveOutEvent()
                          End If

                          streamReader = tempReader
                          outputDevice.Init(streamReader)
                          outputDevice.Volume = radioVolumeMultiplier

                          AddHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
                          outputDevice.Play()

                          lblStatus.Text = "Status: Playing now"
                          lblStatus.ForeColor = Color.Green

                          isConnecting = False

                          Timer1.Interval = adIntervalSeconds * 1000
                          Timer1.Enabled = True
                          Timer1.Start()

                          Me.Cursor = Cursors.Default
                      End Sub)

        Catch ex As Exception
            Me.Invoke(Sub()
                          isConnecting = False
                          lblStatus.Text = "Status: Error! Retrying in 5 seconds..."
                          lblStatus.ForeColor = Color.Red
                          reconnectTimer.Start()
                          Me.Cursor = Cursors.Default
                      End Sub)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not isAdPlaying AndAlso IsWithinSchedule() AndAlso Not isConnecting Then
            PlayAdvertisement()
        End If
    End Sub

    Private Sub PlayRadioStream(url As String)
        StopAllAudioResources()

        If outputDevice Is Nothing Then
            outputDevice = New WaveOutEvent()
        End If

        streamReader = New MediaFoundationReader(url)
        outputDevice.Init(streamReader)
        outputDevice.Volume = radioVolumeMultiplier

        AddHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
        outputDevice.Play()

        lblStatus.Text = "Status: Playing now"
        lblStatus.ForeColor = Color.Green
    End Sub

    Private Sub OnStreamStoppedUnexpectedly(sender As Object, e As StoppedEventArgs)
        If outputDevice IsNot Nothing Then
            RemoveHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
        End If

        If Not isAdPlaying AndAlso isSystemRunning AndAlso IsWithinSchedule() Then
            lblStatus.Text = "Status: Connection interrupted. Reconnecting..."
            lblStatus.ForeColor = Color.Red
            Timer1.Stop()
            reconnectTimer.Start()
        End If
    End Sub

    Private Sub reconnectTimer_Tick(sender As Object, e As EventArgs) Handles reconnectTimer.Tick
        isConnecting = True
        Dim t As New Thread(New ThreadStart(AddressOf ReconnectBackground))
        t.IsBackground = True
        t.Start()
    End Sub

    Private Sub ReconnectBackground()
        Try
            Dim tempReader As New MediaFoundationReader(streamUrl)

            Me.Invoke(Sub()
                          reconnectTimer.Stop()
                          StopAllAudioResources()

                          If outputDevice Is Nothing Then
                              outputDevice = New WaveOutEvent()
                          End If

                          streamReader = tempReader
                          outputDevice.Init(streamReader)
                          outputDevice.Volume = radioVolumeMultiplier

                          AddHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
                          outputDevice.Play()

                          lblStatus.Text = "Status: Playing now"
                          lblStatus.ForeColor = Color.Green

                          isConnecting = False
                          Timer1.Start()
                          Me.Cursor = Cursors.Default
                      End Sub)
        Catch ex As Exception
            Me.Invoke(Sub()
                          isConnecting = False
                          lblStatus.Text = "Status: Reconnection failed. Retrying..."
                          lblStatus.ForeColor = Color.Red
                          reconnectTimer.Start()
                          Me.Cursor = Cursors.Default
                      End Sub)
        End Try
    End Sub

    Private Sub PlayAdvertisement()
        If Not File.Exists(localAdPath) Then
            lblStatus.Text = "Status: Audio file not found."
            lblStatus.ForeColor = Color.DarkRed
            Exit Sub
        End If

        isAdPlaying = True
        Timer1.Stop()
        reconnectTimer.Stop()

        Try
            FadeOutActiveDevice()

            If outputDevice IsNot Nothing Then
                RemoveHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
            End If

            StopAllAudioResources()

            If outputDevice Is Nothing Then
                outputDevice = New WaveOutEvent()
            End If

            adReader = New AudioFileReader(localAdPath)
            outputDevice.Init(adReader)
            outputDevice.Volume = adVolumeMultiplier

            AddHandler outputDevice.PlaybackStopped, AddressOf OnAdFinished
            outputDevice.Play()

            Dim fileName As String = Path.GetFileName(localAdPath)
            lblStatus.Text = "Status: Playing audio file [" & fileName & "]"
            lblStatus.ForeColor = Color.Blue

        Catch ex As Exception
            ResumeRadio()
        End Try
    End Sub

    Private Sub OnAdFinished(sender As Object, e As StoppedEventArgs)
        If outputDevice IsNot Nothing Then
            RemoveHandler outputDevice.PlaybackStopped, AddressOf OnAdFinished
        End If

        ResumeRadio()
    End Sub

    Private Sub ResumeRadio()
        Try
            PlayRadioStream(streamUrl)
            FadeInActiveDevice()
        Catch
            lblStatus.Text = "Status: Connection failed. Reconnecting..."
            lblStatus.ForeColor = Color.Red
            reconnectTimer.Start()
        End Try

        isAdPlaying = False
        Timer1.Start()
    End Sub

    Private Sub FadeOutActiveDevice()
        If outputDevice IsNot Nothing AndAlso outputDevice.PlaybackState = PlaybackState.Playing Then
            For v As Single = radioVolumeMultiplier To 0.0F Step -0.1F
                If v < 0 Then v = 0
                outputDevice.Volume = v
                Thread.Sleep(40)
            Next
            outputDevice.Volume = 0.0F
        End If
    End Sub

    Private Sub FadeInActiveDevice()
        If outputDevice IsNot Nothing AndAlso outputDevice.PlaybackState = PlaybackState.Playing Then
            outputDevice.Volume = 0.0F
            For v As Single = 0.0F To radioVolumeMultiplier Step 0.1F
                If v > radioVolumeMultiplier Then v = radioVolumeMultiplier
                outputDevice.Volume = v
                Thread.Sleep(60)
            Next
            outputDevice.Volume = radioVolumeMultiplier
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isSystemRunning = False
        isConnecting = False
        StopAll()
        SetInputControlsState(True)
        Button1.Enabled = True
        Button2.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub StopAllAudioResources()
        Try
            If outputDevice IsNot Nothing Then
                outputDevice.Stop()
            End If
        Catch
        End Try

        Try
            If streamReader IsNot Nothing Then
                streamReader.Dispose()
                streamReader = Nothing
            End If
        Catch
        End Try

        Try
            If adReader IsNot Nothing Then
                adReader.Dispose()
                adReader = Nothing
            End If
        Catch
        End Try
    End Sub

    Private Sub StopAll()
        Timer1.Stop()
        reconnectTimer.Stop()

        If outputDevice IsNot Nothing Then
            RemoveHandler outputDevice.PlaybackStopped, AddressOf OnAdFinished
            RemoveHandler outputDevice.PlaybackStopped, AddressOf OnStreamStoppedUnexpectedly
        End If

        StopAllAudioResources()

        If outputDevice IsNot Nothing Then
            outputDevice.Dispose()
            outputDevice = Nothing
        End If

        isAdPlaying = False
        lblStatus.Text = "Status: Stopped"
        lblStatus.ForeColor = Color.Black
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim helpForm As New FormHelp()
        helpForm.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim infoText As String =
            "Developed by Djordje Vasic" & vbCrLf &
            "Visit Us: www.cyformat.rs" & vbCrLf & vbCrLf &
            "Contact:" & vbCrLf &
            "• djordje@cyformat.rs" & vbCrLf &
            "• vasic.official@gmail.com" & vbCrLf & vbCrLf &
            "Version: 1.0" & vbCrLf &
            "Last Update: July 16, 2026." & vbCrLf & vbCrLf &
            "This edition of the software is open-source, licensed under the MIT License, and will always remain 100% free." & vbCrLf & vbCrLf &
            "Need custom features, branding, or specialized modifications for your business? Feel free to contact us via either of the email addresses listed above."

        MessageBox.Show(infoText, "About Author & Software", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim settingsForm As New Form2()
        settingsForm.ShowDialog()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopAll()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub
End Class