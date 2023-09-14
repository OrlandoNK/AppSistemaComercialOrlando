Public Class frmAgregarEmpresa


    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Datos.DATOSEMPRESA.AGREGAREMPRESA(txtrazonsocial.Text, txtDireccion.Text, txttelefono.Text, txtrnc.Text, cbestatus.Text)
        Close()
    End Sub

End Class