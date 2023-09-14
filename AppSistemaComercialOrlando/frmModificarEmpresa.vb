Public Class frmModificarEmpresa
    Private codigo As String
    Public Sub New(ByVal codigoempresa As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codigo = codigoempresa
    End Sub
    Private Sub frmModificarEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EMP As Datos.EMPRESA = Datos.DATOSEMPRESA.OBTENERCODIGO(codigo)
        codigo = EMP.IDEMPRESA
        txtrazonsocial.Text = EMP.RAZONSOCIAL
        txtDireccion.Text = EMP.DIRECCION
        txttelefono.Text = EMP.TELEFONO
        txtrnc.Text = EMP.RNC
        cbestatus.Text = EMP.ESTATUS

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Datos.DATOSEMPRESA.MODIFICAREMPRESA(codigo, txtrazonsocial.Text, txtDireccion.Text, txttelefono.Text, txtrnc.Text, cbestatus.Text)
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub
End Class