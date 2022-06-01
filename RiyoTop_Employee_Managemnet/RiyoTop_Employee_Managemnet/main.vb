Imports System.ComponentModel

Public Class main
    Private Sub main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        login.Close()
    End Sub
    Private Sub RegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem.Click
        register.Show()
        register.MdiParent = Me
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        EmpAdd.Show()
        EmpAdd.MdiParent = Me

    End Sub

    Private Sub SalaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaryToolStripMenuItem.Click
        Empsalary.Show()
        Empsalary.MdiParent = Me

    End Sub

    Private Sub AddNewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewUserToolStripMenuItem.Click
        AddUser.Show()

    End Sub

    Private Sub ProductAddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductAddToolStripMenuItem.Click
        product.Show()
        product.MdiParent = Me

    End Sub

    Private Sub SellingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SellingToolStripMenuItem.Click
        ServiceSale1.Show()
        ServiceSale1.MdiParent = Me
    End Sub

    Private Sub AddToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem1.Click
        customerAdd.Show()

    End Sub
End Class