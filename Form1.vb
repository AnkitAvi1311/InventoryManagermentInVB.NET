Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim command As MySqlCommand

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password= ;database=myapp"
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Dim query As String
            query = "INSERT INTO userdetails (fname, email, phone, carname, service) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            MessageBox.Show("User Added Successfully")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            conn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password= ;database=myapp"
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Dim query As String
            Dim id As Integer = CInt(TextBox7.Text)
            query = "UPDATE userdetails SET fname='" & TextBox1.Text & "',email='" & TextBox2.Text & "',phone='" & TextBox3.Text & "',carname='" & TextBox4.Text & "',service='" & TextBox5.Text & "' WHERE id = '" & TextBox7.Text & "' "
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            MessageBox.Show("User Details Modified Successfully")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password= ;database=myapp"
        Dim reader As MySqlDataReader
        Try
            conn.Open()
            Dim query As String
            query = "SELECT fname, email, phone, carname, service FROM userdetails WHERE id = '" & TextBox6.Text & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            Dim count As Integer
            count = 0
            While reader.Read
                count = count + 1
            End While

            If count = 1 Then
                Label10.Text = reader.GetString("fname")
                Label11.Text = reader.GetString("email")
                Label12.Text = reader.GetString("phone")
                Label13.Text = reader.GetString("carname")
                Label14.Text = reader.GetString("service")
            Else
                MessageBox.Show("No user exists")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password= ;database=myapp"
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Dim query As String

            query = "DELETE FROM userdetails WHERE id = '" & TextBox6.Text & "' "
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            MessageBox.Show("User Details Deleted Successfully")
            Label10.Text = ""
            Label11.Text = ""
            Label12.Text = ""
            Label13.Text = ""
            Label14.Text = ""

            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
