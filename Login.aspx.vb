Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        'User is a reserved word so must use []
        'query find username and password in th db
        Dim SQL = "SELECT Username " & _
              "FROM [User] " & _
              "WHERE Username = '" & Username.Text & "'" & _
              "AND Password = '" & Password.Text & "'"
        ' Connection String defined in Web.config from Tools - Connect to Database...
        Using con As New SqlConnection(ConnectionStrings("ConnectionName").ConnectionString)
            Try
                ' dataadapter which execute the sql query on the connection
                Dim dAdapter = New SqlDataAdapter(SQL, con)
                ' table data structure that hold the result of the query
                Dim dSet = New DataSet
                dAdapter.Fill(dSet, "User")
                'match found or not found
                If dSet.Tables("User").Rows.Count > 0 Then
                    MsgBox.Text = "Login!"
                Else
                    MsgBox.Text = "Try Again!"
                End If
            Catch ex As Exception
                MsgBox.Text = "ERROR: " + ex.Message
            End Try
        End Using
    End Sub

End Class