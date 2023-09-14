Public Class frmAgregarCliente
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            Datos.DATOSCLIENTES.AGREGARCLIENTE(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCiudad.Text, txtCodPostal.Text, txtEmail.Text, txtNumTel.Text, "")
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub


End Class