Imports Datos
Public Class frmmantenimientoproveedores
    Private Sub frmmantenimientoproveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProveedor.DataSource = DATOSPROVEEDORES.mostrarProveedores
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "" Then
            dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORCODIGO(txtCodigo.Text)

        Else

            dgvProveedor.DataSource = DATOSPROVEEDORES.mostrarProveedores

        End If


    End Sub

    Private Sub txtproveedor_TextChanged(sender As Object, e As EventArgs) Handles txtproveedor.TextChanged
        dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORPROVEEDOR(txtproveedor.Text)
    End Sub

    Private Sub txtcontacto_TextChanged(sender As Object, e As EventArgs) Handles txtcontacto.TextChanged
        dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORCONTACTO(txtcontacto.Text)
    End Sub

    Private Sub txtNumTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtNumTelefono.TextChanged
        dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORTELEFONO(txtNumTelefono.Text)
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORDIRECCION(txtDireccion.Text)

    End Sub


    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtproveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcontacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontacto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNumTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumTelefono.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim FILA As DataGridViewRow = dgvProveedor.CurrentRow
        Dim codigo As String = FILA.Cells(0).Value
        Dim FMP As New frmModificarProveedor(codigo)
        AddHandler FMP.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmmantenimientoproveedores_FormClosed)
        FMP.Show()
    End Sub

    Private Sub frmmantenimientoproveedores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        dgvProveedor.DataSource = DATOSPROVEEDORES.mostrarProveedores
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim FAP As New frmagregarproveedor()
        AddHandler FAP.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmmantenimientoproveedores_FormClosed)
        FAP.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de querer eliminar este registro?", "Advertencia de eliminacion", MessageBoxButtons.YesNo)

        If respuesta = DialogResult.Yes Then

            Dim registro As DataGridViewRow = dgvProveedor.CurrentRow
            Dim codpro As String = registro.Cells(0).Value
            Dim proveedor As String = registro.Cells(1).Value
            Dim contacto As String = registro.Cells(2).Value
            Dim telefono As String = registro.Cells(3).Value
            Dim direccion As String = registro.Cells(4).Value
            Dim estatus As String = registro.Cells(5).Value
            DATOSPROVEEDORES.ELIMINARPROVEEDOR(codpro)
            MessageBox.Show("Acaba de eliminar a " & proveedor & " " & contacto & " " & telefono & " " & direccion & estatus & "Eliminar registro")
            dgvProveedor.DataSource = DATOSPROVEEDORES.mostrarProveedores



        End If
    End Sub

    Private Sub cbestatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestatus.SelectedIndexChanged
        dgvProveedor.DataSource = DATOSPROVEEDORES.BUSCARPORESTATUS(cbestatus.Text)
    End Sub

    Private Sub cbestatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbestatus.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class