Imports MySql.Data.MySqlClient

Public Class EmpAdd
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
        DataGridView1.Columns(2).Width = 350
        DataGridView1.Columns(3).Width = 270
        conn.Close()

    End Sub
    Private Sub textClear() 'clearmethod '
        NoTxt.Clear()
        NameTxt.Clear()
        TelNoTxt.Clear()
        positionTxt.Text = ""

    End Sub
    Private Sub EmpAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadEmp()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        textClear()  'add new button eka click krpuwama serma field tika clear krna '
        NameTxt.Select()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick 'data grid viver ekata data pass krnawa'
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(0).Value.ToString
        NameTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        positionTxt.Text = DataGridView1.Rows(a).Cells(2).Value
        TelNoTxt.Text = DataGridView1.Rows(a).Cells(3).Value
        RegDatePicker.Text = DataGridView1.Rows(a).Cells(4).Value
        SalaryTxt.Text = DataGridView1.Rows(a).Cells(5).Value
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim a As Integer = DataGridView1.CurrentRow.Index
        NoTxt.Text = DataGridView1.Rows(a).Cells(0).Value.ToString
        NameTxt.Text = DataGridView1.Rows(a).Cells(1).Value
        positionTxt.Text = DataGridView1.Rows(a).Cells(2).Value
        TelNoTxt.Text = DataGridView1.Rows(a).Cells(3).Value
        RegDatePicker.Text = DataGridView1.Rows(a).Cells(4).Value
        SalaryTxt.Text = DataGridView1.Rows(a).Cells(5).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'save button'
        If NameTxt.Text = "" Then
        Else
            If TelNoTxt.Text = "" Then
            Else
                If positionTxt.Text = "" Then
                Else
                    Dim query As String
                    Dim regdate As String = Format(Me.RegDatePicker.Value, "yyyy-MM-dd")
                    Try
                        conn.Open()
                        query = "INSERT INTO `ppaproject`.`employeeadd` (`name`, `position`, `phone`, `date`,`Salary`) VALUES ('" & NameTxt.Text & "', '" & positionTxt.Text & "', '" & TelNoTxt.Text & "' , '" & regdate & "','" & SalaryTxt.Text & "');"
                        Command = New MySqlCommand(query, conn)
                        READER = Command.ExecuteReader
                        conn.Close()

                        MsgBox("succese fully Saved")
                        loadEmp()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)

                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub NameTxt_TextChanged(sender As Object, e As EventArgs) Handles NameTxt.TextChanged

    End Sub

    Private Sub NameTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles NameTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SalaryTxt.Select()

        End If
    End Sub

    Private Sub TelNoTxt_TextChanged(sender As Object, e As EventArgs) Handles TelNoTxt.TextChanged

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SalaryTxt.TextChanged

    End Sub

    Private Sub SalaryTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles SalaryTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            TelNoTxt.Select()

        End If
    End Sub

    Private Sub TelNoTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles TelNoTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            positionTxt.Select()

        End If
    End Sub

    Private Sub positionTxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles positionTxt.SelectedIndexChanged

    End Sub

    Private Sub positionTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles positionTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            RegDatePicker.Select()

        End If
    End Sub

    Private Sub RegDatePicker_ValueChanged(sender As Object, e As EventArgs) Handles RegDatePicker.ValueChanged

    End Sub

    Private Sub RegDatePicker_KeyDown(sender As Object, e As KeyEventArgs) Handles RegDatePicker.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure to Delete This Customer", "OR Not", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If NoTxt.Text = "" Then
                MessageBox.Show("Please Select The Customer")
            Else
                Try
                    Dim q As String
                    conn.Open()
                    q = "DELETE FROM `ppaproject`.`employeeadd` WHERE (`id` = '" & NoTxt.Text & "');"
                    Command = New MySqlCommand(q, conn)
                    READER = Command.ExecuteReader
                    conn.Close()
                    loadEmp()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub NameSearchTxt_TextChanged(sender As Object, e As EventArgs) Handles NameSearchTxt.TextChanged

        If SpositionTxt.Text = "" Then
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT * FROM ppaproject.employeeadd;", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            DataGridView1.DataSource = table
            Dim d As New DataView(table)

            d.RowFilter = String.Format("name Like '%{0}%'", NameSearchTxt.Text)
            DataGridView1.DataSource = d
            conn.Close()
        Else
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT * FROM ppaproject.employeeadd where position like '" & SpositionTxt.Text & "%'", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            DataGridView1.DataSource = table
            Dim d As New DataView(table)

            d.RowFilter = String.Format("name Like '%{0}%'", NameSearchTxt.Text)
            DataGridView1.DataSource = d
            conn.Close()
        End If
    End Sub

    Private Sub SpositionTxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SpositionTxt.SelectedIndexChanged
        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM ppaproject.employeeadd;", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        Dim d As New DataView(table)

        d.RowFilter = String.Format("position Like '%{0}%'", SpositionTxt.Text)
        DataGridView1.DataSource = d
        conn.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
End Class