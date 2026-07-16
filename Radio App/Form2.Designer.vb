<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.tbRadioVolume = New System.Windows.Forms.TrackBar()
        Me.tbAdVolume = New System.Windows.Forms.TrackBar()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndTime = New System.Windows.Forms.DateTimePicker()
        Me.chkEnableSchedule = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.tbRadioVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAdVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbRadioVolume
        '
        Me.tbRadioVolume.Location = New System.Drawing.Point(41, 75)
        Me.tbRadioVolume.Maximum = 100
        Me.tbRadioVolume.Name = "tbRadioVolume"
        Me.tbRadioVolume.Size = New System.Drawing.Size(250, 45)
        Me.tbRadioVolume.TabIndex = 0
        Me.tbRadioVolume.Value = 100
        '
        'tbAdVolume
        '
        Me.tbAdVolume.Location = New System.Drawing.Point(41, 161)
        Me.tbAdVolume.Maximum = 100
        Me.tbAdVolume.Name = "tbAdVolume"
        Me.tbAdVolume.Size = New System.Drawing.Size(250, 45)
        Me.tbAdVolume.TabIndex = 1
        Me.tbAdVolume.Value = 100
        '
        'dtpStartTime
        '
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStartTime.Location = New System.Drawing.Point(106, 254)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.ShowUpDown = True
        Me.dtpStartTime.Size = New System.Drawing.Size(184, 20)
        Me.dtpStartTime.TabIndex = 2
        '
        'dtpEndTime
        '
        Me.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpEndTime.Location = New System.Drawing.Point(106, 283)
        Me.dtpEndTime.Name = "dtpEndTime"
        Me.dtpEndTime.ShowUpDown = True
        Me.dtpEndTime.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndTime.TabIndex = 3
        '
        'chkEnableSchedule
        '
        Me.chkEnableSchedule.AutoSize = True
        Me.chkEnableSchedule.Location = New System.Drawing.Point(44, 231)
        Me.chkEnableSchedule.Name = "chkEnableSchedule"
        Me.chkEnableSchedule.Size = New System.Drawing.Size(119, 17)
        Me.chkEnableSchedule.TabIndex = 4
        Me.chkEnableSchedule.Text = "Enable scheduling?"
        Me.chkEnableSchedule.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(90, 419)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(163, 25)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Stream volume:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Audio file volume:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Start at:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 286)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "End at:"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 456)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkEnableSchedule)
        Me.Controls.Add(Me.dtpEndTime)
        Me.Controls.Add(Me.dtpStartTime)
        Me.Controls.Add(Me.tbAdVolume)
        Me.Controls.Add(Me.tbRadioVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.Text = "Lobby Radio Player Settings"
        CType(Me.tbRadioVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAdVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbRadioVolume As TrackBar
    Friend WithEvents tbAdVolume As TrackBar
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents dtpEndTime As DateTimePicker
    Friend WithEvents chkEnableSchedule As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
