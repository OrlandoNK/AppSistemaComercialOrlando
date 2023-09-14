Imports Datos
Public Class frmmantenimientoproductos
    Private Sub frmmantenimientoproductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProducto.DataSource = DATOSPRODUCTOS.mostrarProductos
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "" Then
            dgvProducto.DataSource = DATOSPRODUCTOS.BUSCARPORCODIGO(txtCodigo.Text)

        Else

            dgvProducto.DataSource = DATOSPRODUCTOS.mostrarProductos
        End If


    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        dgvProducto.DataSource = DATOSPRODUCTOS.BUSCARPORNOMBRE(txtNombre.Text)
    End Sub

    Private Sub txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcion.TextChanged
        dgvProducto.DataSource = DATOSPRODUCTOS.BUSCARPORDESCRIPCION(txtdescripcion.Text)
    End Sub

    Private Sub txtpreciounitario_TextChanged(sender As Object, e As EventArgs) Handles txtpreciounitario.TextChanged


        Try
            dgvProducto.DataSource = DATOSPRODUCTOS.BUSCARPORPRECIO(txtpreciounitario.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try





    End Sub

    Private Sub txtstock_TextChanged(sender As Object, e As EventArgs) Handles txtstock.TextChanged


        Try
            dgvProducto.DataSource = DATOSPRODUCTOS.BUSCARPORSTOCK(txtstock.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try




    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtdescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtpreciounitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpreciounitario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtstock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtstock.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim FAP As New frmagregarproducto()
        AddHandler FAP.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmmantenimientoproductos_FormClosed)
        FAP.Show()
    End Sub

    Private Sub frmmantenimientoproductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        dgvProducto.DataSource = DATOSPRODUCTOS.mostrarProductos
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de querer eliminar este registro?", "Advertencia de eliminacion", MessageBoxButtons.YesNo)

        If respuesta = DialogResult.Yes Then

            Dim registro As DataGridViewRow = dgvProducto.CurrentRow
            Dim codpro As String = registro.Cells(0).Value
            Dim nombre As String = registro.Cells(1).Value
            Dim descripcion As String = registro.Cells(2).Value
            Dim precio As String = registro.Cells(3).Value
            Dim stock As String = registro.Cells(4).Value
            DATOSPRODUCTOS.ELIMINARPRODUCTO(codpro)
            MessageBox.Show("Acaba de eliminar a " & nombre & " " & descripcion & " " & precio & " " & stock & "Eliminar registro")
            dgvProducto.DataSource = DATOSPRODUCTOS.mostrarProductos



        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim FILA As DataGridViewRow = dgvProducto.CurrentRow
        Dim codigo As String = FILA.Cells(0).Value
        Dim FMP As New frmModificarProducto(codigo)
        AddHandler FMP.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmmantenimientoproductos_FormClosed)
        FMP.Show()
    End Sub

End Class