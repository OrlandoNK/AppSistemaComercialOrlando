Public Class frmModificarProducto
    Private codigo As String
    Public Sub New(ByVal codigoproducto As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codigo = codigoproducto
    End Sub
    Private Sub frmModificarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROD As Datos.PRODUCTO = Datos.DATOSPRODUCTOS.OBTENERCODIGO(codigo)
        codigo = PROD.IDPRODUCTO
        txtNombre.Text = PROD.NOMBRE
        txtdescripcion.Text = PROD.Descripcion
        txtpreciounitario.Text = PROD.PRECIO_UNITARIO
        txtstock.Text = PROD.Stock
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Datos.DATOSPRODUCTOS.MODIFICARPRODUCTO(codigo, txtNombre.Text, txtdescripcion.Text, txtpreciounitario.Text, txtstock.Text)
            Close()
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub
End Class