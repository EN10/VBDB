Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class Signup
    Inherits System.Web.UI.Page

    Protected Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        'User & Password are reserved words so must use []
        Dim SQL As String = "INSERT INTO [User] (Username, [Password]) " & _
            "VALUES ('" & Username.Text & "','" & Password.Text & "')"
        ' Connection String defined in Web.config from Tools - Connect to Database...
        Using con As New SqlConnection(ConnectionStrings("ConnectionName").ConnectionString)
            Dim cmd As New SqlCommand(SQL, con)
            Try
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox.Text = "Sign up Successful!"
            Catch ex As Exception
                MsgBox.Text = "ERROR: " + ex.Message
            End Try
        End Using
    End Sub
End Class