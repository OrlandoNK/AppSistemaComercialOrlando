Public Class frmModificarCliente
    Private codigo As String
    Public Sub New(ByVal codigocliente As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codigo = codigocliente
    End Sub

    Private Sub frmModificarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CLIE As Datos.CLIENTES = Datos.DATOSCLIENTES.OBTENERCODIGO(codigo)
        codigo = CLIE.IDCLIENTE
        txtNombre.Text = CLIE.NOMBRE
        txtApellido.Text = CLIE.APELLIDO
        txtDireccion.Text = CLIE.DIRECCION
        txtCiudad.Text = CLIE.CIUDAD
        txtCodPostal.Text = CLIE.CODIGOPOSTAL
        txtEmail.Text = CLIE.EMAIL
        txtNumTel.Text = CLIE.NUMTELEFONO


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Datos.DATOSCLIENTES.MODIFICARCLIENTE(codigo, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCiudad.Text, txtCodPostal.Text, txtEmail.Text, txtNumTel.Text)
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub
End Class