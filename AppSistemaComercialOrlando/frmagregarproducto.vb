Public Class frmagregarproducto
    Private Sub frmagregarproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Datos.DATOSPRODUCTOS.AGREGARPRODUCTO(txtNombre.Text, txtdescripcion.Text, txtpreciounitario.Text, txtstock.Text)
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try


    End Sub
End Class