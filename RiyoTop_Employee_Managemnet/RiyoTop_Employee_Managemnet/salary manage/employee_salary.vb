Imports MySql.Data.MySqlClient

Public Class employee_salary



    Private Sub Fetchdataemployee()
        If id.Text = "" Then
            MsgBox("Enter the employee ID")
        Else

            conn.Open()
            Dim query = "SELECT * FROM ppaproject.employeeadd where (`id` = ' " & id.Text & "');"
            Dim COMMAND As MySqlCommand
            COMMAND = New MySqlCommand(query, conn)
            Dim table As DataTable
            table = New DataTable
            Dim adapter As New MySqlDataAdapter(COMMAND)
            adapter = New MySqlDataAdapter(COMMAND)
            adapter.Fill(table)
            For Each dr As DataRow In table.Rows
                nameTxt.Text = dr(1).ToString()
                positionTxt.Text = dr(2).ToString()
                nameTxt.Visible = True
                positionTxt.Visible = True

            Next
            conn.Close()

        End If




    End Sub

    Private Sub text_clear()

        id.Text = ""
        nameTxt.Text = ""
        positionTxt.Text = ""
        workedTb.Text = ""
        salaryTb.Text = ""


    End Sub

    Private Sub employee_salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'fetch button'
        Fetchdataemployee() 'take data from employee view system'

    End Sub

    Dim DailyPay

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'view button'

        If positionTxt.Text = "" Then
            MsgBox("Select an Employee")
        ElseIf WorkedTb.Text = "" Or Convert.ToInt32(WorkedTb.Text) > 28 Then
            MsgBox("Enter a valid Number of Days")
        Else

            If positionTxt.Text = "Manager" Then
                DailyPay = 1200
            ElseIf positionTxt.Text = "Accountant" Then
                DailyPay = 1200
            ElseIf positionTxt.Text = "Security" Then
                DailyPay = 600
            ElseIf positionTxt.Text = "IT" Then
                DailyPay = 850
            Else
                DailyPay = 500
            End If
            Dim total = DailyPay * Convert.ToInt32(WorkedTb.Text)
            salaryTb.Text = "Employee Id:    " + id.Text + vbCrLf + "Employee Name:    " + nameTxt.Text + vbCrLf + "Employee Position:     " + positionTxt.Text + vbCrLf + "Days Worked     " + workedTb.Text + vbCrLf + "Daily Salary Rs:     " + Convert.ToString(DailyPay) + vbCrLf + "Total Amount Rs:     " + Convert.ToString(total)

        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        text_clear()
    End Sub





    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub workedTb_TextChanged(sender As Object, e As EventArgs) Handles workedTb.TextChanged

    End Sub

    Private Sub workedTb_KeyDown(sender As Object, e As KeyEventArgs) Handles workedTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()


        End If
    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged

    End Sub

    Private Sub id_KeyDown(sender As Object, e As KeyEventArgs) Handles id.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
            workedTb.Select()



        End If
    End Sub

    Private Sub positionTxt_Click(sender As Object, e As EventArgs) Handles positionTxt.Click

    End Sub
End Class