Public Class frmagregarproveedor
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Datos.DATOSPROVEEDORES.AGREGARPROVEEDOR(txtproveedor.Text, txtcontacto.Text, txtNumTelefono.Text, txtDireccion.Text, cbestatus.Text)
        Close()
    End Sub
End Class