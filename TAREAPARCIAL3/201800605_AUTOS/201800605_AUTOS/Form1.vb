Public Class Form1

    Dim x As Integer = 0
    Dim numero_placa(7) As String
    Dim tipoAuto(7) As String
    Dim cobroBase(7) As Double
    Dim kilometraje_ini(7) As Double
    Dim kilometraje_fin(7) As Double
    Dim pagofinal(7) As Double
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            Dim ini, fin, tot, pre, ex, pafin As Double
            ini = CDbl(TextBox2.Text)
            fin = CDbl(TextBox3.Text)
            tot = fin - ini
            ex = getExtra(tot)
            pre = getPrecio()

            pafin = pre + ex
            If x < 7 Then
                numero_placa(x) = TextBox1.Text
                tipoAuto(x) = gettipo()
                cobroBase(x) = pre
                kilometraje_ini(x) = ini
                kilometraje_fin(x) = fin
                pagofinal(x) = pre + ex

                DataGridView1.Rows.Add(TextBox1.Text, gettipo(), getPrecio(), ini, fin, pafin)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                x += 1
            Else
                MsgBox("el vector esta lleno y no se puede realizar la operacion")
            End If
        Else
            MsgBox("no se pudo agregar")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function gettipo() As String
        MsgBox("Obtuve el tipoo")
        If ComboBox1.SelectedIndex = 0 Then
            Return "Tipo 1"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Return "Tipo 2"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Return "Tipo 3"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Return "Tipo 4"
        Else
            Return ""
        End If
    End Function

    Public Function getPrecio() As Double

        If ComboBox1.SelectedIndex = 0 Then
            Return 500
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Return 400
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Return 300
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Return 200
        Else
            Return 0
        End If
    End Function

    Public Function getExtra(km As Double) As Double
        MsgBox(km)
        If km <= 50 Then
            Return km * 3
        ElseIf km >= 50 And km <= 70 Then
            Return km * 4
        ElseIf km > 70 Then
            Return km * 5
        Else
            Return 0
        End If
    End Function

    Private Sub VaciarDatagridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VaciarDatagridToolStripMenuItem.Click
        Me.DataGridView1.Rows.Clear()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub VaciarVectoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VaciarVectoresToolStripMenuItem.Click
        For i = 0 To 6
            numero_placa(i) = Nothing
            tipoAuto(i) = Nothing
            cobroBase(i) = 0
            kilometraje_ini(i) = 0
            kilometraje_fin(i) = 0
            pagofinal(i) = 0
        Next

        x = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dato As Boolean = False

        For i = 0 To x
            If TextBox4.Text = numero_placa(i) Then
                If dato = False Then
                    Me.DataGridView1.Rows.Clear()
                End If
                dato = True
                DataGridView1.Rows.Add(numero_placa(i), tipoAuto(i), cobroBase(i), kilometraje_ini(i), kilometraje_fin(i), pagofinal(i))

            End If
        Next
        TextBox4.Clear()
        If dato = False Then
            MsgBox("no se encontro el dato")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i = 0 To x

            DataGridView1.Rows.Add(numero_placa(i), tipoAuto(i), cobroBase(i), kilometraje_ini(i), kilometraje_fin(i), pagofinal(i))

        Next
    End Sub
End Class
