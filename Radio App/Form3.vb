Public Class FormHelp
    Private Sub FormHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Lobby Radio Player - User Guide & Documentation"
        Me.StartPosition = FormStartPosition.CenterParent

        Dim docsText As String =
            "LOBBY RADIO PLAYER v1.0" & vbCrLf &
            "==========================================================================" & vbCrLf & vbCrLf &
            "Welcome to the official documentation for the Lobby Radio Player. This utility is designed " & vbCrLf &
            "specifically for commercial venues, hotels, lobbies, and offices to automate background " & vbCrLf &
            "music streaming while seamlessly injecting local audio advertisements at designated intervals." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "KEY FEATURES & CAPABILITIES" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "• Multithreaded Connection Engine: Stream loading and reconnection attempts run entirely " & vbCrLf &
            "  on background threads. The user interface remains 100% responsive, eliminating application " & vbCrLf &
            "  freezing and loading cursors." & vbCrLf & vbCrLf &
            "• Smart Volume Transition (Fade In/Out): To ensure a pleasant listener experience, the system " & vbCrLf &
            "  smoothly fades out the live radio stream before playing an advertisement, and gently fades " & vbCrLf &
            "  the radio back in once the advertisement finishes playing." & vbCrLf & vbCrLf &
            "• Independent Volume Controls: Fully customizable volume levels for both the background music " & vbCrLf &
            "  and the local advertisements, adjustable in real-time from the Settings panel." & vbCrLf & vbCrLf &
            "• Automated Silence / Active Hours Scheduler: Set active operating hours (e.g., 08:00 to 23:00). " & vbCrLf &
            "  The system will automatically stop playback outside of these hours and resume seamlessly when " & vbCrLf &
            "  active hours begin, saving network bandwidth and power." & vbCrLf & vbCrLf &
            "• Self-Healing Reconnection Logic: Built-in watchdog timers actively monitor stream states. " & vbCrLf &
            "  If your internet connection drops, the system stops current tasks and attempts a silent " & vbCrLf &
            "  reconnection every 5 seconds until the stream is restored." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "UNDERSTANDING THE SCHEDULER (ACTIVE HOURS)" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "The Scheduler acts as an automatic autopilot, but it requires you to 'arm' the system first " & vbCrLf &
            "by clicking the 'PLAY' button. Depending on when you click PLAY, two things can happen:" & vbCrLf & vbCrLf &
            "1. If you click PLAY DURING active hours (e.g., at 12:00 PM):" & vbCrLf &
            "   The stream starts playing immediately. When the active period ends (e.g., 11:00 PM), the " & vbCrLf &
            "   system automatically stops the stream, pauses the ad timer, and changes status to " & vbCrLf &
            "   'Outside Active Hours (Muted)'." & vbCrLf & vbCrLf &
            "2. If you click PLAY OUTSIDE active hours (e.g., in the morning at 07:00 AM, before opening):" & vbCrLf &
            "   The system locks the fields and stands by silently. No audio will play, and the status " & vbCrLf &
            "   will show 'Outside Active Hours (Muted)'. As soon as the clock strikes your start time " & vbCrLf &
            "   (e.g., 08:00 AM), the system automatically wakes up and starts the radio stream and ads." & vbCrLf & vbCrLf &
            "This setup ensures you only have to press PLAY once, and the software will manage the entire " & vbCrLf &
            "week's schedule completely unattended." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "HARDWARE & SETUP REQUIREMENTS (IMPORTANT)" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "To ensure the system works as intended in a public or commercial space:" & vbCrLf &
            "• Sound System Connection: The computer or device running this application MUST be physically " & vbCrLf &
            "  connected to your venue's amplifier, mixer, or central sound system (via a 3.5mm audio jack, " & vbCrLf &
            "  Bluetooth, USB DAC, or HDMI) to broadcast the audio to your speakers." & vbCrLf &
            "• Active Audio Device: Make sure the correct output device is set as the default playback " & vbCrLf &
            "  device in your Windows sound settings before starting the program." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "STEP-BY-STEP SETUP GUIDE" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "1. Enter Stream Link:" & vbCrLf &
            "   Paste the direct streaming URL into the 'Link' input field." & vbCrLf & vbCrLf &
            "2. Set Advertisement Interval:" & vbCrLf &
            "   Enter the desired delay between ads in seconds (e.g., 300 seconds for a 5-minute interval)." & vbCrLf & vbCrLf &
            "3. Choose Advertisement File:" & vbCrLf &
            "   Click the browse button to locate and select your target local audio file (.mp3 or .wav)." & vbCrLf & vbCrLf &
            "4. Start Playback:" & vbCrLf &
            "   Click the 'PLAY' button to arm the system. Once active, input fields will lock automatically " & vbCrLf &
            "   to prevent accidental modifications during broadcast. To adjust settings, click 'STOP'." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "HOW TO FIND DIRECT STREAM URLS" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "Standard web player links (like those embedded in radio station websites) will not work. " & vbCrLf &
            "The application requires a direct audio stream address." & vbCrLf & vbCrLf &
            "1. Open your web browser and navigate to a stream directory (e.g., https://streamurl.link/)." & vbCrLf &
            "2. Search for your preferred radio station." & vbCrLf &
            "3. Look for the 'Direct URL'. These links usually:" & vbCrLf &
            "   • Contain a specific port number (e.g., http://example.com:8000/stream)" & vbCrLf &
            "   • End with an audio format extension (e.g., .mp3, .aac, .pls, or .m3u)" & vbCrLf &
            "4. Copy this direct link and paste it into the application's 'Link' field." & vbCrLf & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "LEGAL DISCLAIMER & LICENSE" & vbCrLf &
            "--------------------------------------------------------------------------" & vbCrLf &
            "This software is open-source, released under the MIT License. The Author " &
            "provides this utility strictly as-is. The end-user is entirely and solely " &
            "responsible for acquiring any necessary public performance licenses, " &
            "complying with national copyright laws, and securing appropriate broadcast " &
            "permissions for any commercial, public, or business environment." & vbCrLf &
            ""

        RichTextBox1.Text = docsText
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Try
            System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(e.LinkText) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Unable to open the link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class