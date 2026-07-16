Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbRadioVolume.Value = CInt(Form1.radioVolumeMultiplier * 100)
        tbAdVolume.Value = CInt(Form1.adVolumeMultiplier * 100)

        chkEnableSchedule.Checked = Form1.isScheduleEnabled
        dtpStartTime.Value = Today.Add(Form1.scheduleStart)
        dtpEndTime.Value = Today.Add(Form1.scheduleEnd)

        dtpStartTime.Enabled = chkEnableSchedule.Checked
        dtpEndTime.Enabled = chkEnableSchedule.Checked
    End Sub

    Private Sub chkEnableSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSchedule.CheckedChanged
        dtpStartTime.Enabled = chkEnableSchedule.Checked
        dtpEndTime.Enabled = chkEnableSchedule.Checked
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Form1.radioVolumeMultiplier = tbRadioVolume.Value / 100.0F
        Form1.adVolumeMultiplier = tbAdVolume.Value / 100.0F

        Form1.isScheduleEnabled = chkEnableSchedule.Checked
        Form1.scheduleStart = dtpStartTime.Value.TimeOfDay
        Form1.scheduleEnd = dtpEndTime.Value.TimeOfDay

        Form1.UpdateLiveVolume()
        Me.Close()
    End Sub
End Class