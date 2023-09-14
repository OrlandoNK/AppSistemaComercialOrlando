Public Class frmagregarempleado
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            Datos.DATOSEMPLEADOS.AGREGAREMPLEADO(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCiudad.Text, txtCodPostal.Text, txtEmail.Text, txtNumTel.Text, txtfecha.Text, txtcargo.Text, txtsalario.Text, "")
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub


End Class