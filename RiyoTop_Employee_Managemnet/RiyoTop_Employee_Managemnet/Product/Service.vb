Imports MySql.Data.MySqlClient
Public Class Service
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Private Sub loadCategory()

        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT category FROM service_category;", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        CateCombo.DataSource = table
        CateCombo.ValueMember = "category"
        conn.Close()
    End Sub

    Private Sub subcategory()

        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM service_subcategory where category = '" & CateCombo.Text & "'", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        SubCateCombo.DataSource = table
        SubCateCombo.ValueMember = "subcategory"
        conn.Close()
    End Sub
    Private Sub loadType()
        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM service_type;", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        TypeCombo.DataSource = table
        TypeCombo.ValueMember = "type"
        conn.Close()
    End Sub
    Private Sub loadservices()

    End Sub

    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCategory()
        loadType()
    End Sub


    Private Sub CateCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CateCombo.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'this function to add category'
        Try
            Dim Query As String
            conn.Open()
            Query = "INSERT INTO `ppaproject`.`service_category` (`category`) VALUES ('" & CateCombo.Text & "');"
            COMMAND = New MySqlCommand(Query, conn)
            READER = Command.ExecuteReader
            conn.Close()
            MessageBox.Show("New Main Category Add Sucess")

            loadCategory()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'this function to add Sub category'
        Try
            Dim Query As String
            conn.Open()
            Query = "INSERT INTO `ppaproject`.`service_subcategory` (`category`, `subcategory`) VALUES ('" & CateCombo.Text & "', '" & SubCateCombo.Text & "');"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader
            conn.Close()
            MessageBox.Show("New Sub Category Add Sucess")
            subcategory()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'this function to add Type'
        Try
            Dim Query As String
            conn.Open()
            Query = "INSERT INTO `ppaproject`.`service_type` (`type`) VALUES ('" & TypeCombo.Text & "');"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader
            conn.Close()
            MessageBox.Show("New Type Add Sucess")
            loadType()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub SubCateCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SubCateCombo.SelectedIndexChanged

    End Sub

    Private Sub SubCateCombo_Enter(sender As Object, e As EventArgs) Handles SubCateCombo.Enter

    End Sub

    Private Sub SubCateCombo_KeyDown(sender As Object, e As KeyEventArgs) Handles SubCateCombo.KeyDown
        If e.KeyCode = Keys.Enter Then
            subcategory()
        End If
    End Sub
End Class