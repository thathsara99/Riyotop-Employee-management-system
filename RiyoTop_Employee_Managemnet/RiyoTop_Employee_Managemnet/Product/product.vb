Imports MySql.Data.MySqlClient
Public Class product
    Private Sub textClear()
        Item_CodeTextBox.Clear()
        DescriptionTextBox.Clear()
        CostTextBox.Clear()
        PriceTxt.Clear()
        AVstockTxt.Clear()

    End Sub
    'this function to count row'
    Private Sub rowcount()
        Dim k As Integer = DataGridView1.Rows.Count() - 1
        Label3.Text = k
    End Sub
    Private Sub productLoad()
        conn.Open()

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM product", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        DataGridView1.Columns(0).Width = 140
        DataGridView1.Columns(1).Width = 520
        DataGridView1.Columns(2).Width = 110
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 90
        conn.Close()
        rowcount()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        textClear()
        Item_CodeTextBox.Select()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Item_CodeTextBox.Text = "" Then
            MessageBox.Show("Item Code is Empty")
        Else
            If DescriptionTextBox.Text = "" Then
                MessageBox.Show("Description is Empty")
            Else
                If CostTextBox.Text = "" Then
                    MessageBox.Show("Cost is Empty")
                Else

                    If PriceTxt.Text = "" Then
                        MessageBox.Show("Price is Empty")
                    Else
                        If AVstockTxt.Text = "" Then
                                MessageBox.Show("Average Stock is Empty")
                            Else
                                Dim itcode As String = Item_CodeTextBox.Text
                                Dim nitcode As String = itcode.Trim()

                                Dim odes As String = DescriptionTextBox.Text
                                Dim newDes As String = odes.Trim()
                                Dim COMMAND As MySqlCommand
                                Dim READER As MySqlDataReader

                            Try
                                    Dim Query As String
                                    conn.Open()
                                Query = "INSERT INTO `ppaproject`.`product` (`barcode`, `description`, `cost`, `price`, `stock`, `avgStock`) VALUES ('" & nitcode & "', '" & newDes & "', '" & CostTextBox.Text & "', '" & PriceTxt.Text & "', '0', '" & AVstockTxt.Text & "');"
                                COMMAND = New MySqlCommand(Query, conn)
                                    READER = COMMAND.ExecuteReader
                                conn.Close()
                                MessageBox.Show("Item Add To the System")
                                productLoad()
                                textClear()
                                Item_CodeTextBox.Select()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                conn.Close()
                            End Try

                            End If
                        End If
                    End If
                End If
            End If

    End Sub


    Private Sub Item_CodeTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Item_CodeTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            DescriptionTextBox.Select()

        End If
    End Sub

    Private Sub DescriptionTextBox_TextChanged(sender As Object, e As EventArgs) Handles DescriptionTextBox.TextChanged

    End Sub

    Private Sub DescriptionTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DescriptionTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            CostTextBox.Select()

        End If
    End Sub


    Private Sub PriceTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles PriceTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            AVstockTxt.Select()

        End If
    End Sub



    Private Sub CostTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CostTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            PriceTxt.Select()

        End If
    End Sub



    Private Sub AVstockTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles AVstockTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()


        End If
    End Sub

    Private Sub product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productLoad()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Item_CodeTextBox.Text = "" Then
            MessageBox.Show("Item Code is Empty")
        Else
            If DescriptionTextBox.Text = "" Then
                MessageBox.Show("Description is Empty")
            Else
                If CostTextBox.Text = "" Then
                    MessageBox.Show("Cost is Empty")
                Else

                    If PriceTxt.Text = "" Then
                        MessageBox.Show("Price is Empty")
                    Else
                        If AVstockTxt.Text = "" Then
                            MessageBox.Show("Average Stock is Empty")
                        Else
                            Dim itcode As String = Item_CodeTextBox.Text
                            Dim nitcode As String = itcode.Trim()

                            Dim odes As String = DescriptionTextBox.Text
                            Dim newDes As String = odes.Trim()
                            Dim COMMAND As MySqlCommand
                            Dim READER As MySqlDataReader

                            Try
                                Dim Query As String
                                conn.Open()
                                Query = "UPDATE `ppaproject`.`product` SET  `description` = '" & newDes & "', `cost` = '" & CostTextBox.Text & "', `price` = '" & PriceTxt.Text & "', `avgStock` = '" & AVstockTxt.Text & "' WHERE (`barcode` = '" & nitcode & "');"
                                COMMAND = New MySqlCommand(Query, conn)
                                READER = COMMAND.ExecuteReader
                                conn.Close()
                                MessageBox.Show("Product Update Complete")
                                productLoad()
                                textClear()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                                conn.Close()
                            End Try

                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim k As Integer = DataGridView1.CurrentRow.Index
        Item_CodeTextBox.Text = DataGridView1.Rows(k).Cells(0).Value.ToString
        DescriptionTextBox.Text = DataGridView1.Rows(k).Cells(1).Value.ToString
        CostTextBox.Text = DataGridView1.Rows(k).Cells(2).Value.ToString
        PriceTxt.Text = DataGridView1.Rows(k).Cells(3).Value.ToString
        AVstockTxt.Text = DataGridView1.Rows(k).Cells(5).Value.ToString
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim k As Integer = DataGridView1.CurrentRow.Index
        Item_CodeTextBox.Text = DataGridView1.Rows(k).Cells(0).Value.ToString
        DescriptionTextBox.Text = DataGridView1.Rows(k).Cells(1).Value.ToString
        CostTextBox.Text = DataGridView1.Rows(k).Cells(2).Value.ToString
        PriceTxt.Text = DataGridView1.Rows(k).Cells(3).Value.ToString
        AVstockTxt.Text = DataGridView1.Rows(k).Cells(5).Value.ToString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Item_CodeTextBox.Text = "" Then
            MessageBox.Show("Please Select The Item")
        Else
            Dim result As DialogResult = MessageBox.Show("Are you Sure to Delete This", "OR Not", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim COMMAND As MySqlCommand
                Dim READER As MySqlDataReader

                Try
                    Dim Query As String
                    conn.Open()
                    Query = "DELETE FROM `ppaproject`.`product` WHERE (`barcode` = '" & Item_CodeTextBox.Text & "');"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()
                    MessageBox.Show("Product Delete Sucess")
                    productLoad()
                    textClear()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try
            End If
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        '--------------------'
        conn.Open()
        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM product", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        Dim dv As New DataView(table)

        dv.RowFilter = String.Format("barcode Like '{0}%'", TextBox1.Text)
        DataGridView1.DataSource = dv
        conn.Close()

        rowcount()
        '----------------'
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox1.Text = "" Then
            '--------------------'
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            DataGridView1.DataSource = table
            Dim dv As New DataView(table)

            dv.RowFilter = String.Format("description Like '%{0}%'", TextBox2.Text)
            DataGridView1.DataSource = dv
            conn.Close()

            rowcount()
            '----------------'
        Else
            '--------------------'
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT * FROM product where barcode like'" & TextBox1.Text & "%' order by barcode", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            DataGridView1.DataSource = table
            Dim dv As New DataView(table)

            dv.RowFilter = String.Format("description Like '%{0}%'", TextBox2.Text)
            DataGridView1.DataSource = dv
            conn.Close()

            rowcount()
        End If
    End Sub
End Class