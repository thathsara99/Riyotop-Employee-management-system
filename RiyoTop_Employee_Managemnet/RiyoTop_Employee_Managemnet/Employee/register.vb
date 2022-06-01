Imports MySql.Data.MySqlClient
Public Class register
    Dim no As Integer
    Dim salary As Double
    Dim Command As MySqlCommand
    Dim READER As MySqlDataReader
    Private Sub loadEmp()
        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM ppaproject.employeeadd;", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        conn.Close()
    End Sub
    Private Sub regload()
        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim regdate As String = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd")
        Dim adapter As New MySqlDataAdapter("SELECT * FROM ppaproject.register where Date = '" & regdate & "'", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView2.DataSource = table
        conn.Close()
        Dim tot As Double = 0
        For f As Integer = 0 To DataGridView2.Rows.Count - 1 Step +1
            tot = tot + DataGridView2.Rows(f).Cells(3).Value
        Next
        TotalCriditLbl.Text = tot.ToString
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadEmp()
        regload()
        'this is for the printer select function'
        For Each strprinterName As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            Me.ComboBox1.Items.Add(strprinterName)
        Next
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Me.ComboBox1.SelectedIndex = 0 'Select defalt'
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(0).Value
        no = DataGridView1.Rows(a).Cells(0).Value
        NameTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        salary = DataGridView1.Rows(a).Cells(5).Value
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(0).Value
        no = DataGridView1.Rows(a).Cells(0).Value
        NameTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        salary = DataGridView1.Rows(a).Cells(5).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PasswordTxt.Text = "2258" Then
            If NoTxt.Text <> "" Then
                Dim isinn As Boolean = False
                'All readey Add that person'
                regload()
                For f As Integer = 0 To DataGridView2.Rows.Count - 1 Step +1
                    If no = DataGridView2.Rows(f).Cells(1).Value Then
                        isinn = True
                    End If
                Next
                If isinn = True Then
                    MessageBox.Show("That Person All Ready Register for Today")
                Else
                    Try
                        Dim query As String
                        Dim regdate As String = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd")
                        conn.Open()
                        query = "INSERT INTO register (`empId`, `EmpName`, `Salary`, `Date`) VALUES ('" & no & "', '" & NameTxt.Text & "', '" & salary & "', '" & regdate & "');"
                        Command = New MySqlCommand(query, conn)
                        READER = Command.ExecuteReader
                        conn.Close()
                        MessageBox.Show("Register Sucess")
                        regload()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try
                End If

            Else
                MessageBox.Show("Not Select Person")
            End If
        Else
            MessageBox.Show("You Are Not Admin Please Enter Password")
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        regload()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim repdate As String = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd")
        Dim cryRpt As New EmpRegister
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

    Private Sub TotalCriditLbl_Click(sender As Object, e As EventArgs) Handles TotalCriditLbl.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class