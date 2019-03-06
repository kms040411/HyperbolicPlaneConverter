Public Class Form1
    Public mouseX(100000) As Single
    Public mouseY(100000) As Single
    Dim ConvmousX(100000) As Single
    Dim ConvmousY(100000) As Single
    Dim Counter As Long
    Dim A As Single
    Dim B As Single
    Public firstX As Single
    Public firstY As Single
    Public i As Long

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.ImageLocation = InputBox("Load Image", "이미지 파일의 경로를 입력하세요")
        Counter = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Refresh()
        PictureBox1.CreateGraphics.DrawEllipse(Pens.Blue, firstX, firstY, 2, 2)
        Dim j As Integer
        For j = 1 To 1000
            A = mouseX(j)
            B = mouseY(j)

            ConvmousX(j) = 100 * ((2 * A * B) / (A * A + (B - 1) * (B - 1)))
            ConvmousY(j) = 100 * ((-(A * A) + -(B * B) + 1) / (A * A + (B - 1) * (B - 1)))
            TextBox1.Text = ConvmousX(151)
            TextBox2.Text = ConvmousY(151)
            'Form2.PictureBox1.CreateGraphics.DrawEllipse(Pens.Red, (ConvmousX(j) + firstX), (firstY - ConvmousY(j)), 2, 2)
            PictureBox1.CreateGraphics.DrawEllipse(Pens.Red, (ConvmousX(j) + firstX), (firstY - ConvmousY(j)), 2, 2)
        Next j
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Counter = 0
        i = 1
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        For i = 1 To 1000
            If Counter = 1 Then
                mouseX(i) = (MousePosition.X - firstX) / 300
                mouseY(i) = (firstY - MousePosition.Y) / 300

                PictureBox1.CreateGraphics.DrawEllipse(Pens.Red, MousePosition.X, MousePosition.Y, 2, 2)
                TextBox3.Text = mouseX(i)
                TextBox4.Text = mouseY(i)
                i = i + 1
            Else
                firstX = PictureBox1.Scale.weight / 2
                firstY = MousePosition.Y
                PictureBox1.CreateGraphics.DrawEllipse(Pens.Blue, MousePosition.X, MousePosition.Y, 2, 2)
                Counter = 1
            End If
        Next i
    End Sub
End Class
