Imports Microsoft.Data.SqlClient

Public Class Form1
    Dim st As String
    Private ReadOnly ncm As New SqlCommand
    Dim cm As New SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim data As Integer
    Dim number, q, price, nq, npr, nqq, nqr, nqn As Integer

    Public ReadOnly Property Connection1 As New SqlConnection("Server = DESKTOP-SJ41T7O\SQLEXPRESS; database =inventory; integrated security = true")

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click


    End Sub

    Private Sub load_()
        st = "Select * from product"
        Dim search As New SqlDataAdapter(st, Connection1)
        Dim ds As DataSet = New DataSet
        search.Fill(ds, "product")
        DataGridView1.DataSource = ds.Tables("product")
        Connection1.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim command As New SqlCommand("delete from product where pnumber = @number", Connection1)

        command.Parameters.Add("@number", SqlDbType.Int).Value = TextBox1.Text
        Connection1.Open()

        If command.ExecuteNonQuery = 1 Then
            MsgBox("Delete Successfully")
        Else
            MsgBox("Delete Failed")
        End If
        Connection1.Close()
        load_()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Connection1.Open()
        cm.CommandType = CommandType.Text
        cm.CommandText = "SELECT * FROM  product  WHERE pnumber ='" & TextBox1.Text & "'"
        da = New SqlDataAdapter(cm.CommandText, Connection1)
        dt = New DataTable
        data = da.Fill(dt)
        If data > 0 Then
            nq = dt.Rows(0).Item("pquantity")
            nqn = TextBox3.Text
            nqq = nq - nqn
            da.Dispose()
            dt = Nothing
            cm = New SqlCommand
            With cm
                .CommandText = "UPDATE product SET  pquantity=@quantity WHERE pnumber =@number"
                .Connection = Connection1
                .Parameters.AddWithValue("@quantity", nqq)
                .Parameters.AddWithValue("@number", TextBox1.Text)
                .ExecuteNonQuery()
            End With
            MsgBox("PullOut Successfull")
        End If
        Connection1.Close()
        load_()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("insert into product(pname,pquantity,price) values(@name,@quantity,@price)", Connection1)

        command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox2.Text
        command.Parameters.Add("@quantity", SqlDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@price", SqlDbType.VarChar).Value = TextBox4.Text
        Connection1.Open()

        If command.ExecuteNonQuery = 1 Then
            MsgBox("Add successfully")
        Else
            MsgBox("Add Failed")
        End If
        Connection1.Close()
        load_()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.AppStat = "Trial Version" Then
            If My.Settings.LoadCount < 0 Then
                Form2.ShowDialog()
            End If

            Me.Text = My.Settings.AppStat & " : Counter =>" & My.Settings.LoadCount
            My.Settings.LoadCount -= 1
            My.Settings.Save()
        Else
            Me.Text = My.Settings.AppStat
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Connection1.Open()
        cm.CommandType = CommandType.Text
        cm.CommandText = "Select * from product where pnumber ='" & TextBox1.Text & "'"
        da = New SqlDataAdapter(cm.CommandText, Connection1)
        dt = New DataTable
        data = da.Fill(dt)

        If data > 0 Then
            q = dt.Rows(0).Item("pquantity")
            price = dt.Rows(0).Item("price")
            nq = q + TextBox3.Text
            npr = price + TextBox4.Text
            da.Dispose()
            dt = Nothing
            cm = New SqlCommand
            With cm
                .CommandText = "UPDATE product SET  price=@p_price, pquantity=@quantity where pnumber=@number"
                .Connection = Connection1
                .Parameters.AddWithValue("@quantity", nq)
                .Parameters.AddWithValue("@number", TextBox1.Text)
                .Parameters.AddWithValue("@p_price", npr)
                .ExecuteNonQuery()
            End With

        End If
        MsgBox("Add successfully")
        Connection1.Close()
        load_()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
    End Sub
End Class

Friend Class SqlDataAdapter
    Private commandText As String
    Private connection As SqlConnection

    Public Sub New(commandText As String, connection As SqlConnection)
        Me.commandText = commandText
        Me.connection = connection
    End Sub

    Friend Sub Dispose()
        Throw New NotImplementedException()
    End Sub

    Friend Sub Fill(ds As DataSet, v As String)
        Throw New NotImplementedException()
    End Sub

    Friend Function Fill(ds As DataSet, dt As DataTable) As Integer
        Throw New NotImplementedException()
    End Function

    Friend Function Fill(dt As DataTable) As Integer
        Throw New NotImplementedException()
    End Function
End Class
