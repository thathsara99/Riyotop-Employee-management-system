Imports MySql.Data.MySqlClient

Public Class ServiceSale1
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim oldqty As Integer
    Dim IT_Code As String
    Dim Stockt As Integer
    Dim selectItm As String
    Dim Cost As Double
    Private Sub load_data()
        conn.Open()

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT barcode,description,cost,price,stock FROM product;", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        ItemShowGridView.DataSource = table
        ItemShowGridView.Columns(0).Width = 150
        ItemShowGridView.Columns(1).Width = 450
        ItemShowGridView.Columns(2).Width = 90
        ItemShowGridView.Columns(3).Width = 150
        ItemShowGridView.Columns(4).Width = 150
        conn.Close()
    End Sub
    Private Sub load_InvNo()
        Dim dadapter As New MySqlDataAdapter
        Try
            'Dim Query As String
            conn.Open()
            'Dim dataset1 As New DataSet
            'Query = "select No from salemanagedbs.invno where No='" & InvLbl.Text & "' "
            'Dim da As New MySqlDataAdapter(Query, conn)
            'da.Fill(dataset1, "db")

            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("select inNo from invoice", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            InvNoDataGridView.DataSource = table
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try


        conn.Close()
    End Sub
    Private Sub ShowRetailSale()
        conn.Open()

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select IT_Code,Description,Qut,Unit_Price,Discount,Amount from retailsale2", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        DataGridView1.DataSource = table
        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 450
        DataGridView1.Columns(2).Width = 90
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 50
        DataGridView1.Columns(5).Width = 150
        conn.Close()
    End Sub
    Private Sub AddtoGrideView()
        Dim chk As String
        Dim oldsqty As Integer
        IT_Code = IT_CodeTextBox.Text
        For q As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            If IT_Code = DataGridView1.Rows(q).Cells(0).Value Then
                chk = "Isinn"
                oldsqty = DataGridView1.Rows(q).Cells(2).Value
                oldsqty = oldsqty + QutTextBox.Text
            End If
        Next
        If chk = "Isinn" Then
            'if that item getting from selected'
            If selectItm = "ItsSelect" Then
                'This item is in the textbox'

                If DiscountTextBox.Text = "" Then
                    Try
                        Dim Query As String
                        conn.Open()

                        Query = "update retailsale2 set Qut='" & QutTextBox.Text & "',Unit_Price='" & Unit_PriceTextBox.Text & "',Amount='" & AmountTextBox.Text & "' where IT_Code='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        selectItm = ""
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try

                Else
                    Try
                        Dim Query As String
                        conn.Open()

                        Query = "update retailsale2 set Qut='" & QutTextBox.Text & "',Unit_Price='" & Unit_PriceTextBox.Text & "',Discount='" & DiscountTextBox.Text & "',Amount='" & AmountTextBox.Text & "' where IT_Code='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        selectItm = ""
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try
                End If
                '----------------------------------------'
            Else
                'This item is in the textbox'
                If DiscountTextBox.Text = "" Then
                    Try
                        Dim Query As String
                        conn.Open()

                        Query = "update retailsale2 set Qut='" & oldsqty & "',Unit_Price='" & Unit_PriceTextBox.Text & "',Amount='" & AmountTextBox.Text & "' where IT_Code='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        selectItm = ""
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try

                Else
                    Try
                        Dim Query As String
                        conn.Open()

                        Query = "update retailsale2 set Qut='" & oldsqty & "',Unit_Price='" & Unit_PriceTextBox.Text & "',Discount='" & DiscountTextBox.Text & "',Amount='" & AmountTextBox.Text & "' where IT_Code='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        selectItm = ""
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try
                End If
                '----------------------------------------'
            End If

        Else
            If DiscountTextBox.Text = "" Then
                Try
                    Dim Query As String
                    conn.Open()
                    Query = "insert into retailsale2 (Inv_No,Cus_Name,IT_Code,Description,Qut,Unit_Price,Amount,Date) values ('" & InvLbl.Text & "','" & CNameTxt.Text & "','" & IT_CodeTextBox.Text & "','" & DesTxt.Text & "','" & QutTextBox.Text & "','" & Unit_PriceTextBox.Text & "','" & AmountTextBox.Text & "','" & TextBox4.Text & "')"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try

            Else
                Try
                    Dim Query As String
                    conn.Open()
                    Query = "insert into retailsale2 (Inv_No,Cus_Name,IT_Code,Description,Qut,Unit_Price,Discount,Amount,Date) values ('" & InvLbl.Text & "','" & CNameTxt.Text & "','" & IT_CodeTextBox.Text & "','" & DesTxt.Text & "','" & QutTextBox.Text & "','" & Unit_PriceTextBox.Text & "','" & DiscountTextBox.Text & "','" & AmountTextBox.Text & "','" & TextBox4.Text & "')"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try
            End If

        End If


    End Sub
    Private Sub PrintInvoice()
        'This code for increase invoice NO'
        Dim s As Integer
        s = InvLbl.Text
        s = s + 1


        Try
            Dim Query As String
            conn.Open()
            Query = "update invoice set inNo='" & s & "' where inNo='" & InvLbl.Text & "'"
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader
            conn.Close()
            load_InvNo()
            InvLbl.Text = InvNoDataGridView.Rows(0).Cells(0).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try


    End Sub
    Private Sub ServiceSale1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()
        load_InvNo()
        ShowRetailSale()
        InvLbl.Text = InvNoDataGridView.Rows(0).Cells(0).Value.ToString
        Me.TextBox4.Text = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd hh:mm:ss")
        Dim rowcount As Integer = DataGridView1.Rows.Count
        Dim tot As Double = 0
        If rowcount = 0 Then

        Else

            For d As Integer = 0 To rowcount - 1 Step +1
                tot = tot + DataGridView1.Rows(d).Cells(5).Value
            Next

            mgsumTxt.Text = tot.ToString
            Fullsumtxt.Text = mgsumTxt.Text
            conn.Open()

            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("select Cus_Name,Date from retailsale2", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            DataGridView1.DataSource = table
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(1).Width = 50


            conn.Close()
            CNameTxt.Text = DataGridView1.Rows(0).Cells(0).Value.ToString

        End If
        ShowRetailSale()
        If Panel1.Visible Then
            Panel1.Visible = False
        Else
            Panel1.Visible = False

        End If
        IT_CodeTextBox.Select()
        'this is for the printer select function'
        For Each strprinterName As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            Me.ComboBox1.Items.Add(strprinterName)
        Next
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Me.ComboBox1.SelectedIndex = 0 'Select defalt'
    End Sub

    Private Sub IT_CodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles IT_CodeTextBox.TextChanged
        '--------------------'
        conn.Open()

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT barcode,description,cost,price,stock FROM product  order by barcode", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        ItemShowGridView.DataSource = table
        Dim dv As New DataView(table)

        dv.RowFilter = String.Format("barcode Like '{0}%'", IT_CodeTextBox.Text)
        ItemShowGridView.DataSource = dv
        ItemShowGridView.Columns(0).Width = 150
        ItemShowGridView.Columns(1).Width = 450
        ItemShowGridView.Columns(2).Visible = False
        ItemShowGridView.Columns(3).Width = 150
        ItemShowGridView.Columns(4).Width = 150

        conn.Close()
        '----------------'
    End Sub

    Private Sub IT_CodeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IT_CodeTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            If Panel1.Visible Then
                Panel1.Visible = False
            Else
                Panel1.Visible = False
            End If
        Else
            If Panel1.Visible Then
                Panel1.Visible = True
            Else
                Panel1.Visible = True

            End If


        End If
    End Sub

    Private Sub IT_CodeTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles IT_CodeTextBox.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Panel1.Visible Then
                Panel1.Visible = False
            Else
                Panel1.Visible = False
            End If
        End If
        If e.KeyCode = Keys.Up Then
            ItemShowGridView.Select()
        End If
        If e.KeyCode = Keys.Down Then
            ItemShowGridView.Select()
        End If
        If e.KeyCode = Keys.F1 Then
            Button7.PerformClick()

        End If

        If e.KeyCode = Keys.Enter Then
            Dim itm As Integer = ItemShowGridView.Rows.Count
            If itm = 1 Then
                IT_CodeTextBox.Text = ItemShowGridView.Rows(0).Cells(0).Value
                Unit_PriceTextBox.Text = ItemShowGridView.Rows(0).Cells(3).Value
                Stockt = ItemShowGridView.Rows(0).Cells(4).Value
                Cost = ItemShowGridView.Rows(0).Cells(2).Value
                IT_Code = IT_CodeTextBox.Text
                DesTxt.Text = ItemShowGridView.Rows(0).Cells(1).Value
                QutTextBox.Text = "1"
                QutTextBox.Select()
            End If
        End If
    End Sub

    Private Sub DesTxt_TextChanged(sender As Object, e As EventArgs) Handles DesTxt.TextChanged
        If IT_CodeTextBox.Text = "" Then
            '--------------------'
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT barcode,description,cost,price,stock FROM product  order by barcode", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            ItemShowGridView.DataSource = table
            Dim dv As New DataView(table)

            dv.RowFilter = String.Format("description Like '%{0}%'", DesTxt.Text)
            ItemShowGridView.DataSource = dv

            ItemShowGridView.Columns(0).Width = 150
            ItemShowGridView.Columns(1).Width = 450
            ItemShowGridView.Columns(2).Visible = False
            ItemShowGridView.Columns(3).Width = 150
            ItemShowGridView.Columns(4).Width = 150

            conn.Close()
            '----------------'
        Else
            '--------------------'
            conn.Open()
            Dim bsource As New BindingSource
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT barcode,description,cost,price,stock FROM product where barcode like'" & IT_CodeTextBox.Text & "%' order by barcode", conn)
            adapter.Fill(table)
            bsource.DataSource = table
            ItemShowGridView.DataSource = table
            Dim dv As New DataView(table)

            dv.RowFilter = String.Format("description Like '%{0}%'", DesTxt.Text)
            ItemShowGridView.DataSource = dv

            ItemShowGridView.Columns(0).Width = 150
            ItemShowGridView.Columns(1).Width = 450
            ItemShowGridView.Columns(2).Visible = False
            ItemShowGridView.Columns(3).Width = 150
            ItemShowGridView.Columns(4).Width = 150

            conn.Close()
            '----------------'
        End If
    End Sub

    Private Sub DesTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles DesTxt.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Panel1.Visible Then
                Panel1.Visible = False
            Else
                Panel1.Visible = False
            End If
        End If
        If e.KeyCode = Keys.Up Then
            ItemShowGridView.Select()
        End If
        If e.KeyCode = Keys.Down Then
            ItemShowGridView.Select()
        End If
        If e.KeyCode = Keys.Enter Then
            Dim itm As Integer = ItemShowGridView.Rows.Count
            If itm = 1 Then
                IT_CodeTextBox.Text = ItemShowGridView.Rows(0).Cells(0).Value
                Unit_PriceTextBox.Text = ItemShowGridView.Rows(0).Cells(3).Value
                Stockt = ItemShowGridView.Rows(0).Cells(4).Value
                Cost = ItemShowGridView.Rows(0).Cells(2).Value
                IT_Code = IT_CodeTextBox.Text
                DesTxt.Text = ItemShowGridView.Rows(0).Cells(1).Value
                QutTextBox.Text = "1"
                QutTextBox.Select()
            End If
        End If
    End Sub

    Private Sub DesTxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DesTxt.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            If Panel1.Visible Then
                Panel1.Visible = False
            Else
                Panel1.Visible = False
            End If
        Else
            If Panel1.Visible Then
                Panel1.Visible = True
            Else
                Panel1.Visible = True

            End If


        End If
    End Sub

    Private Sub ItemShowGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ItemShowGridView.CellContentClick

    End Sub

    Private Sub ItemShowGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemShowGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim itm As Integer = ItemShowGridView.CurrentRow.Index
            IT_CodeTextBox.Text = ItemShowGridView.Rows(itm).Cells(0).Value
            Unit_PriceTextBox.Text = ItemShowGridView.Rows(0).Cells(3).Value
            Stockt = ItemShowGridView.Rows(0).Cells(4).Value
            Cost = ItemShowGridView.Rows(0).Cells(2).Value
            IT_Code = IT_CodeTextBox.Text
            DesTxt.Text = ItemShowGridView.Rows(0).Cells(1).Value
            QutTextBox.Text = "1"
            QutTextBox.Select()
        End If
    End Sub

    Private Sub QutTextBox_TextChanged(sender As Object, e As EventArgs) Handles QutTextBox.TextChanged
        If QutTextBox.Text = "" Then
        Else
            If Unit_PriceTextBox.Text = "" Then
            Else
                AmountTextBox.Text = QutTextBox.Text * Unit_PriceTextBox.Text

            End If
        End If
    End Sub

    Private Sub QutTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles QutTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If QutTextBox.Text = "" Then
                MsgBox("Plese Enter Quantity")
            Else
                If Panel1.Visible Then
                    Panel1.Visible = False
                Else
                    Panel1.Visible = False
                End If

                Unit_PriceTextBox.Select()
            End If

        End If
    End Sub

    Private Sub Unit_PriceTextBox_TextChanged(sender As Object, e As EventArgs) Handles Unit_PriceTextBox.TextChanged
        If QutTextBox.Text = "" Then

        Else
            If Unit_PriceTextBox.Text = "" Then
            Else
                AmountTextBox.Text = QutTextBox.Text * Unit_PriceTextBox.Text

            End If
        End If
    End Sub

    Private Sub Unit_PriceTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit_PriceTextBox.KeyDown

        If e.KeyCode = Keys.Enter Then
            DiscountTextBox.Select()
        End If
    End Sub

    Private Sub DiscountTextBox_TextChanged(sender As Object, e As EventArgs) Handles DiscountTextBox.TextChanged
        If QutTextBox.Text = "" Then

        Else
            If Unit_PriceTextBox.Text = "" Then

            Else
                If DiscountTextBox.Text = "" Then
                    AmountTextBox.Text = QutTextBox.Text * Unit_PriceTextBox.Text
                Else
                    Dim dis As Integer
                    AmountTextBox.Text = QutTextBox.Text * Unit_PriceTextBox.Text
                    dis = 100 - DiscountTextBox.Text
                    AmountTextBox.Text = (AmountTextBox.Text / 100)
                    AmountTextBox.Text = AmountTextBox.Text * dis

                End If
            End If
        End If
    End Sub

    Private Sub DiscountTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DiscountTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()
        End If
    End Sub
    Private Sub changestock()
        Dim chk As String
        For q As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
            If IT_Code = DataGridView1.Rows(q).Cells(0).Value Then
                chk = "Isinn"
            End If
        Next
        If chk = "Isinn" Then
            'If that item select from retaialsale'
            If selectItm = "ItsSelect" Then
                Dim nqty As Integer = QutTextBox.Text
                If nqty = oldqty Then
                Else
                    If nqty > oldqty Then
                        nqty = nqty - oldqty
                        Dim valu As Integer = ItemShowGridView.Rows(0).Cells(4).Value
                        valu = valu - nqty
                        Try
                            Dim Query As String
                            conn.Open()
                            Query = "update product set stock='" & valu & "' where barcode='" & IT_Code & "'"
                            COMMAND = New MySqlCommand(Query, conn)
                            READER = COMMAND.ExecuteReader
                            conn.Close()
                            load_data()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                            conn.Close()
                        End Try
                    Else
                        nqty = oldqty - nqty
                        Dim valu As Integer = ItemShowGridView.Rows(0).Cells(4).Value
                        valu = valu + nqty
                        Try
                            Dim Query As String
                            conn.Open()
                            Query = "update product set stock='" & valu & "' where barcode='" & IT_Code & "'"
                            COMMAND = New MySqlCommand(Query, conn)
                            READER = COMMAND.ExecuteReader
                            conn.Close()
                            load_data()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                            conn.Close()
                        End Try
                    End If
                End If
            Else
                'not selected item'
                Try
                    Stockt = Stockt - QutTextBox.Text
                    Dim Query As String
                    conn.Open()
                    Query = "update product set stock='" & Stockt & "' where barcode='" & IT_Code & "'"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()
                    load_data()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try
            End If

        Else
            If Stockt Then
                Stockt = Stockt - QutTextBox.Text
                Try
                    Dim Query As String
                    conn.Open()
                    Query = "update product set stock='" & Stockt & "' where barcode='" & IT_Code & "'"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()
                    load_data()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try
            Else

                Stockt = 0
                Stockt = Stockt - QutTextBox.Text
                Try
                    Dim Query As String
                    conn.Open()
                    Query = "update product set stock='" & Stockt & "' where barcode='" & IT_Code & "'"
                    COMMAND = New MySqlCommand(Query, conn)
                    READER = COMMAND.ExecuteReader
                    conn.Close()
                    load_data()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    conn.Close()
                End Try
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Unit_PriceTextBox.Text = "" Then
            MsgBox("Please Enter Unit Price")
        Else
            If DesTxt.Text = "" Then
                MsgBox("Please Enter Description")
            Else

                If IT_CodeTextBox.Text = "" Then
                    MsgBox("Please Enter Item Code")
                Else
                    If AmountTextBox.Text = "" Then
                        MsgBox("Please Enter Amount")
                    Else
                        If QutTextBox.Text = "" Then
                            MsgBox("Plese Enter Quantity")
                        Else
                            If Unit_PriceTextBox.Text < Cost Then
                                MsgBox("Price undercost change unit price")
                            Else
                                If DiscountTextBox.Text = "" Then
                                    changestock()
                                    AddtoGrideView()
                                    ShowRetailSale()
                                    Dim summ As Double = 0
                                    For q As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                                        summ = summ + DataGridView1.Rows(q).Cells(5).Value
                                    Next
                                    mgsumTxt.Text = summ.ToString

                                    If DiscoText.Text = "0" Then
                                        Fullsumtxt.Text = mgsumTxt.Text
                                    End If
                                    IT_CodeTextBox.Clear()
                                    DesTxt.Clear()
                                    QutTextBox.Clear()
                                    Unit_PriceTextBox.Clear()
                                    DiscountTextBox.Clear()
                                    AmountTextBox.Clear()
                                    IT_CodeTextBox.Select()

                                Else
                                    Dim discount As Double = DiscountTextBox.Text
                                    Dim unitprice As Double = Unit_PriceTextBox.Text
                                    discount = 100 - discount
                                    Dim sums As Double = (unitprice / 100) * discount
                                    If sums < Cost Then
                                        MsgBox("You Entered discount Under Cost please change the discount")
                                    Else
                                        changestock()
                                        AddtoGrideView()
                                        ShowRetailSale()
                                        Dim summ As Double = 0
                                        For q As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                                            summ = summ + DataGridView1.Rows(q).Cells(5).Value
                                        Next
                                        mgsumTxt.Text = summ.ToString

                                        If DiscoText.Text = "0" Then
                                            Fullsumtxt.Text = mgsumTxt.Text
                                        End If
                                        IT_CodeTextBox.Clear()
                                        DesTxt.Clear()
                                        QutTextBox.Clear()
                                        Unit_PriceTextBox.Clear()
                                        DiscountTextBox.Clear()
                                        AmountTextBox.Clear()
                                        IT_CodeTextBox.Select()

                                    End If

                                End If
                            End If

                        End If


                    End If
                End If

            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If mgsumTxt.Text = "" Then

        Else
            If DiscoText.Text = "" Then
                MessageBox.Show("Net Discount is Empty")
            Else
                If LiveDiscountTxt.Text = "" Then
                Else
                    For f As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                        If DataGridView1.Rows(f).Cells(4).Value.ToString = "" Then

                            Try
                                Dim Query As String
                                conn.Open()
                                Query = "insert into retailselling (Inv_No,Customer,Item_Code,Description,Quantity,Unit_Price,Amount,Net_Amount,Inv_Dis,Inv_Disamt,Grand_Total,Selling_Date) values ('" & InvLbl.Text & "','" & CNameTxt.Text & "','" & DataGridView1.Rows(f).Cells(0).Value & "','" & DataGridView1.Rows(f).Cells(1).Value & "','" & DataGridView1.Rows(f).Cells(2).Value & "','" & DataGridView1.Rows(f).Cells(3).Value & "','" & DataGridView1.Rows(f).Cells(5).Value & "','" & mgsumTxt.Text & "','" & DiscoText.Text & "','" & LiveDiscountTxt.Text & "','" & Fullsumtxt.Text & "','" & TextBox4.Text & "')"
                                COMMAND = New MySqlCommand(Query, conn)
                                READER = COMMAND.ExecuteReader
                                conn.Close()

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                                conn.Close()
                            End Try
                        Else
                            Try
                                Dim Query As String
                                conn.Open()
                                Query = "insert into retailselling (Inv_No,Customer,Item_Code,Description,Quantity,Unit_Price,Discount,Amount,Net_Amount,Inv_Dis,Inv_Disamt,Grand_Total,Selling_Date) values ('" & InvLbl.Text & "','" & CNameTxt.Text & "','" & DataGridView1.Rows(f).Cells(0).Value & "','" & DataGridView1.Rows(f).Cells(1).Value & "','" & DataGridView1.Rows(f).Cells(2).Value & "','" & DataGridView1.Rows(f).Cells(3).Value & "','" & DataGridView1.Rows(f).Cells(4).Value & "','" & DataGridView1.Rows(f).Cells(5).Value & "','" & mgsumTxt.Text & "','" & DiscoText.Text & "','" & LiveDiscountTxt.Text & "','" & Fullsumtxt.Text & "','" & TextBox4.Text & "')"
                                COMMAND = New MySqlCommand(Query, conn)
                                READER = COMMAND.ExecuteReader
                                conn.Close()

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                                conn.Close()
                            End Try
                        End If

                    Next
                    Try
                        Dim Query As String
                        conn.Open()
                        Query = "delete from retailsale2"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                    Catch ex As Exception

                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try

                    Dim cryRpt As New ServiceDesign
                    cryRpt.Refresh()
                    cryRpt.RecordSelectionFormula = "{retailselling1.Inv_No} = '" & InvLbl.Text.ToString() & "'"
                    cryRpt.Refresh()


                    With cryRpt
                        '.FileName = Application.StartupPath + ("\InvoiceDesign\RetailInv.rpt")


                    End With
                    'CrystalReportViewer1.ReportSource = cryRpt
                    'CrystalReportViewer1.Refresh()
                    cryRpt.PrintOptions.PrinterName = Me.ComboBox1.Text 'print by selected combobox'
                    cryRpt.PrintToPrinter(0, False, 1, 1)

                    '-----------------'
                    ShowRetailSale()
                    PrintInvoice()
                    'This for the reset all the textbox and Others'
                    IT_CodeTextBox.Clear()
                    DesTxt.Clear()
                    QutTextBox.Clear()
                    Unit_PriceTextBox.Clear()
                    DiscountTextBox.Clear()
                    AmountTextBox.Clear()
                    IT_CodeTextBox.Select()
                    CNameTxt.Text = "Cash"
                    mgsumTxt.Text = "0"
                    DiscoText.Text = "0"
                    LiveDiscountTxt.Text = "0"
                    Fullsumtxt.Text = "0"
                    Me.TextBox4.Text = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd hh:mm:ss")
                    '--------------'


                End If
            End If
        End If


    End Sub
    Private Sub itemdel()
        conn.Open()

        Dim bsource As New BindingSource
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select barcode,description,stock from product where barcode='" & IT_Code & "'", conn)
        adapter.Fill(table)
        bsource.DataSource = table
        ItemShowGridView.DataSource = table
        ItemShowGridView.Columns(0).Width = 150
        ItemShowGridView.Columns(1).Width = 450
        ItemShowGridView.Columns(2).Width = 90

        conn.Close()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MessageBox.Show("Are you Sure to Delete This", "OR Not", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If IT_CodeTextBox.Text = "" Then
            Else
                If QutTextBox.Text = "" Then
                Else
                    IT_Code = IT_CodeTextBox.Text
                    Dim netAmount As Double = mgsumTxt.Text
                    Dim delAmt As Double = AmountTextBox.Text
                    netAmount = netAmount - delAmt
                    mgsumTxt.Text = netAmount.ToString

                    itemdel()
                    Dim stock As Integer
                    Dim qty As Integer

                    qty = QutTextBox.Text


                    stock = ItemShowGridView.Rows(0).Cells(2).Value
                    stock = qty + stock



                    Try
                        Dim Query As String
                        conn.Open()
                        Query = "update product set stock='" & stock & "' where barcode='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        load_data()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                        conn.Close()
                    End Try



                    Try
                        Dim Query As String
                        conn.Open()

                        Query = "delete from retailsale2 where IT_Code='" & IT_Code & "'"
                        COMMAND = New MySqlCommand(Query, conn)
                        READER = COMMAND.ExecuteReader
                        conn.Close()
                        MessageBox.Show("Item Is delete")

                        IT_CodeTextBox.Clear()
                        DesTxt.Clear()
                        QutTextBox.Clear()
                        Unit_PriceTextBox.Clear()
                        DiscountTextBox.Clear()
                        AmountTextBox.Clear()
                        If mgsumTxt.Text = "" Then
                        Else
                            If DiscoText.Text = "0" Then
                                Fullsumtxt.Text = mgsumTxt.Text
                            Else

                                If DiscoText.Text = "" Then
                                    Fullsumtxt.Text = mgsumTxt.Text
                                Else
                                    Dim mgsum As Double = mgsumTxt.Text
                                    Dim disrate As Double = DiscoText.Text
                                    Dim disAmt As Double
                                    Dim fulltot As Double
                                    disAmt = (mgsum / 100) * disrate
                                    fulltot = (100 - disrate) * mgsum / 100

                                    LiveDiscountTxt.Text = disAmt.ToString
                                    Fullsumtxt.Text = fulltot.ToString
                                End If
                            End If

                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)

                        conn.Close()
                    End Try
                    ShowRetailSale()
                End If
            End If

        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim b As Integer = DataGridView1.CurrentRow.Index
        IT_CodeTextBox.Text = DataGridView1.Rows(b).Cells(0).Value.ToString
        DesTxt.Text = DataGridView1.Rows(b).Cells(1).Value.ToString
        QutTextBox.Text = DataGridView1.Rows(b).Cells(2).Value.ToString
        Unit_PriceTextBox.Text = DataGridView1.Rows(b).Cells(3).Value.ToString
        DiscountTextBox.Text = DataGridView1.Rows(b).Cells(4).Value.ToString
        AmountTextBox.Text = DataGridView1.Rows(b).Cells(5).Value.ToString
        oldqty = DataGridView1.Rows(b).Cells(2).Value.ToString
        IT_Code = IT_CodeTextBox.Text
        selectItm = "ItsSelect"

    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim b As Integer = DataGridView1.CurrentRow.Index
        IT_CodeTextBox.Text = DataGridView1.Rows(b).Cells(0).Value.ToString
        DesTxt.Text = DataGridView1.Rows(b).Cells(1).Value.ToString
        QutTextBox.Text = DataGridView1.Rows(b).Cells(2).Value.ToString
        Unit_PriceTextBox.Text = DataGridView1.Rows(b).Cells(3).Value.ToString
        DiscountTextBox.Text = DataGridView1.Rows(b).Cells(4).Value.ToString
        AmountTextBox.Text = DataGridView1.Rows(b).Cells(5).Value.ToString
        oldqty = DataGridView1.Rows(b).Cells(2).Value.ToString
        IT_Code = IT_CodeTextBox.Text
        selectItm = "ItsSelect"
    End Sub
    Private Sub DiscoText_TextChanged(sender As Object, e As EventArgs) Handles DiscoText.TextChanged
        If DiscoText.Text = "" Then
            LiveDiscountTxt.Clear()
            Fullsumtxt.Clear()
        Else
            If DiscoText.Text = "0" Then
                LiveDiscountTxt.Text = "0"
                Fullsumtxt.Text = mgsumTxt.Text
            End If
            Dim mgsum As Double = mgsumTxt.Text
            Dim disrate As Double = DiscoText.Text
            Dim disAmt As Double
            Dim fulltot As Double
            disAmt = (mgsum / 100) * disrate
            fulltot = (100 - disrate) * mgsum / 100

            LiveDiscountTxt.Text = disAmt.ToString
            Fullsumtxt.Text = fulltot.ToString
        End If
    End Sub
End Class