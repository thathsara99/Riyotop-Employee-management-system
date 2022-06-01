Public Class EmpReport
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CrystalReportViewer1.ReportSource = Application.StartupPath + "\Report\CrystalReport1.rpt"
        'CrystalReportViewer1.SelectionFormula = ""
        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.RefreshReport()

    End Sub
End Class