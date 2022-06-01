Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Public Class login
    Dim COMMAND As MySqlCommand
    Public Sub Login_data()

        Dim password As String
        Dim passwordSHA As String

        password = TextBox2.Text

        Call passwordEncryptSHA(password) ' Lets call the first password encryption function for SHA1

        passwordSHA = passwordEncryptSHA(password) ' give the variable the returned SHA value

        Dim READER As MySqlDataReader
        Try
            conn.Open()
            Dim Query As String
            Query = "select * from userlog where username='" & TextBox1.Text & "' and password='" & passwordSHA & "' "
            COMMAND = New MySqlCommand(Query, conn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1

            End While

            If count = 1 Then
                main.Show()
                Me.Hide()

            Else
                MessageBox.Show("Your Username or Password Does not match")

            End If


            conn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login_data()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Select()
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()

        End If
    End Sub
    Public Function passwordEncryptSHA(ByVal password As String) As String
        Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte ' and here is a byte variable

        bytesToHash = System.Text.Encoding.ASCII.GetBytes(password) ' covert the password into ASCII code

        bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

        Dim encPassword As String = ""

        For Each b As Byte In bytesToHash
            encPassword += b.ToString("x2")
        Next

        Return encPassword ' boom there goes the encrypted password!

    End Function
End Class