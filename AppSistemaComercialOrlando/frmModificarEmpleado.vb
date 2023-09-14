Public Class frmModificarEmpleado
    Private codigo As String
    Public Sub New(ByVal codigoempleado As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codigo = codigoempleado
    End Sub
    Private Sub frmModificarEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EMPLE As Datos.EMPLEADOS = Datos.DATOSEMPLEADOS.OBTENERCODIGO(codigo)
        codigo = EMPLE.IDEMPLEADO
        txtNombre.Text = EMPLE.NOMBRE
        txtApellido.Text = EMPLE.APELLIDO
        txtDireccion.Text = EMPLE.DIRECCION
        txtCiudad.Text = EMPLE.CIUDAD
        txtCodPostal.Text = EMPLE.CODIGOPOSTAL
        txtEmail.Text = EMPLE.EMAIL
        txtNumTel.Text = EMPLE.NUMTELEFONO
        txtfecha.Text = EMPLE.FECHACONTRATACION
        txtcargo.Text = EMPLE.CARGO
        txtsalario.Text = EMPLE.SALARIO


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Datos.DATOSEMPLEADOS.MODIFICAREMPLEADO(codigo, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtCiudad.Text, txtCodPostal.Text, txtEmail.Text, txtNumTel.Text, txtfecha.Text, txtcargo.Text, txtsalario.Text, "")
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub
End Class