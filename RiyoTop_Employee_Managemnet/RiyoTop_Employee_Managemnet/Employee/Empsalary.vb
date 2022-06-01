Imports MySql.Data.MySqlClient
Public Class Empsalary
    Dim tot As Double
    Dim Command As MySqlCommand
    Dim READER As MySqlDataReader
    Private Sub getdateidff()
        conn.Open()
        Dim Stadate As String
        Dim enddat As String
        enddat = Format(Me.EndDate.Value, "yyy-MM-dd")
        Stadate = Format(Me.StartDate.Value, "yyyy-MM-dd")

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from register where Date BETWEEN '" & Stadate & "' And '" & enddat & "'", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        conn.Close()
        tot = 0
        For f As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            tot = tot + DataGridView1.Rows(f).Cells(3).Value
        Next
        TotalCriditLbl.Text = tot.ToString

    End Sub
    Private Sub Empsalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this is for the printer select function'
        For Each strprinterName As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            Me.ComboBox1.Items.Add(strprinterName)
        Next
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Me.ComboBox1.SelectedIndex = 0 'Select defalt'
    End Sub

    Private Sub DateFilterBtn_Click(sender As Object, e As EventArgs) Handles DateFilterBtn.Click
        getdateidff()
    End Sub

    Private Sub NameSeachTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameSeachTextBox.TextChanged
        conn.Open()
        Dim Stadate As String
        Dim enddat As String
        enddat = Format(Me.EndDate.Value, "yyy-MM-dd")
        Stadate = Format(Me.StartDate.Value, "yyyy-MM-dd")

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from register where Date BETWEEN '" & Stadate & "' And '" & enddat & "'", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        Dim dv As New DataView(table)
        dv.RowFilter = String.Format("EmpName Like '%{0}%'", NameSeachTextBox.Text)
        DataGridView1.DataSource = dv
        conn.Close()
        tot = 0
        For f As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            tot = tot + DataGridView1.Rows(f).Cells(3).Value
        Next
        TotalCriditLbl.Text = tot.ToString
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub deleteOldsalary()
        Try
            Dim query As String
            conn.Open()
            query = "DELETE FROM salary"
            Command = New MySqlCommand(query, conn)
            READER = Command.ExecuteReader
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub
    Private Sub generatereport()
        Dim cryRpt As New SalaryDesign
        cryRpt.Refresh()
        'cryRpt.RecordSelectionFormula = "{register1.Date} = '" & repdate & "'"
        'cryRpt.Refresh()


        With cryRpt
            '.FileName = Application.StartupPath + ("\InvoiceDesign\RetailInv.rpt")


        End With
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
        cryRpt.PrintOptions.PrinterName = Me.ComboBox1.Text 'print by selected combobox'
        cryRpt.PrintToPrinter(0, False, 1, 1)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NoTxt.Text = "" Then
            MessageBox.Show("Enter Employee Id To generate Report")
        Else
            If NameSeachTextBox.Text = "" Then
                MessageBox.Show("Enter Employee Name")
            Else
                If bonesTxt.Text = "" Then
                    MessageBox.Show("Please Enter Bones")
                Else
                    If SalaryTxt.Text <> "" Then
                        deleteOldsalary()
                        For f As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                            Dim salary As Double = DataGridView1.Rows(f).Cells(3).Value
                            Dim getdate As String = Format(Me.DataGridView1.Rows(f).Cells(4).Value, "yyyy-MM-dd")

                            Try
                                Dim query As String
                                conn.Open()
                                query = "INSERT INTO salary (`EmpId`, `Name`, `Salary`, `Bones`, `VatAndOther`, `Total`,`Adate`) VALUES ('" & NoTxt.Text & "', '" & NameSeachTextBox.Text & "', '" & salary & "', '" & bonesTxt.Text & "', '" & EtfTxt.Text & "', '" & SalaryTxt.Text & "','" & getdate & "');"
                                Command = New MySqlCommand(query, conn)
                                READER = Command.ExecuteReader
                                conn.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                                conn.Close()
                            End Try
                        Next
                        MessageBox.Show("Sucess")
                        generatereport()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        NameSeachTextBox.Text = DataGridView1.Rows(a).Cells(2).Value
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        NameSeachTextBox.Text = DataGridView1.Rows(a).Cells(2).Value
    End Sub

    Private Sub bonesTxt_TextChanged(sender As Object, e As EventArgs) Handles bonesTxt.TextChanged
        Try
            Dim b As Double
            Dim etf As Double
            If bonesTxt.Text <> "" Then
                b = bonesTxt.Text
            Else
                b = 0
            End If
            If EtfTxt.Text <> "" Then
                etf = EtfTxt.Text
            Else
                etf = 0
            End If
            Dim sum As Double = tot - etf + b
            SalaryTxt.Text = sum.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EtfTxt_TextChanged(sender As Object, e As EventArgs) Handles EtfTxt.TextChanged
        Try
            Dim b As Double
            Dim etf As Double
            If bonesTxt.Text <> "" Then
                b = bonesTxt.Text
            Else
                b = 0
            End If
            If EtfTxt.Text <> "" Then
                etf = EtfTxt.Text
            Else
                etf = 0
            End If
            Dim sum As Double = tot - etf + b
            SalaryTxt.Text = sum.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class