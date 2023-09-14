Public Class frmModificarProveedor
    Private codigo As String
    Public Sub New(ByVal codigoproveedor As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codigo = codigoproveedor
    End Sub
    Private Sub frmModificarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROOV As Datos.PROVEEDORES = Datos.DATOSPROVEEDORES.OBTENERCODIGO(codigo)
        codigo = PROOV.IDPROVEEDOR
        txtproveedor.Text = PROOV.PROVEEDOR
        txtcontacto.Text = PROOV.CONTACTO
        txtNumTelefono.Text = PROOV.TELEFONO
        txtDireccion.Text = PROOV.DIRECCION
        cbestatus.Text = PROOV.ESTATUS


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Datos.DATOSPROVEEDORES.MODIFICARPROVEEDOR(codigo, txtproveedor.Text, txtcontacto.Text, txtNumTelefono.Text, txtDireccion.Text, cbestatus.Text)
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub


End Class