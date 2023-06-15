Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class Form2
    Dim connection As New SqlConnection("Server = DESKTOP-SJ41T7O\SQLEXPRESS; database =inventory; integrated security = true")
    Dim cm As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim data As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'antonio
        If My.Settings.SerialKey = TextBox1.Text Then
            My.Settings.AppStat = "Full Version"
            My.Settings.Save()
            Me.Close()
        Else
            MsgBox("Invalid Serial Key")
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
