Imports Datos
Public Class frmMantenimientoEmpresa
    Private Sub frmMantenimientoEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvEmpresa.DataSource = DATOSEMPRESA.mostrarEmpresa
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "" Then
            dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORCODIGO(txtCodigo.Text)

        Else

            dgvEmpresa.DataSource = DATOSEMPRESA.mostrarEmpresa
        End If
    End Sub

    Private Sub txtrazonsocial_TextChanged(sender As Object, e As EventArgs) Handles txtrazonsocial.TextChanged
        dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORRAZONSOCIAL(txtrazonsocial.Text)
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORDIRECCION(txtDireccion.Text)
    End Sub

    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged
        dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORTELEFONO(txttelefono.Text)
    End Sub

    Private Sub txtrnc_TextChanged(sender As Object, e As EventArgs) Handles txtrnc.TextChanged
        dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORRNC(txtrnc.Text)
    End Sub

    Private Sub cbestatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestatus.SelectedIndexChanged
        If cbestatus.Text <> "" Then
            dgvEmpresa.DataSource = DATOSEMPRESA.BUSCARPORESTATUS(cbestatus.Text)

        Else

            dgvEmpresa.DataSource = DATOSEMPRESA.mostrarEmpresa
        End If



    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtrazonsocial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrazonsocial.KeyPress
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

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtrnc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrnc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbestatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbestatus.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmMantenimientoEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        dgvEmpresa.DataSource = DATOSEMPRESA.mostrarEmpresa
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim FAE As New frmAgregarEmpresa()
        AddHandler FAE.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmMantenimientoEmpresa_FormClosed)
        FAE.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de querer eliminar este registro?", "Advertencia de eliminacion", MessageBoxButtons.YesNo)

        If respuesta = DialogResult.Yes Then

            Dim registro As DataGridViewRow = dgvEmpresa.CurrentRow
            Dim codemp As String = registro.Cells(0).Value
            Dim razonsocial As String = registro.Cells(1).Value
            Dim direccion As String = registro.Cells(2).Value
            Dim telefono As String = registro.Cells(3).Value
            Dim rnc As String = registro.Cells(4).Value
            Dim estatus As String = registro.Cells(5).Value
            DATOSEMPRESA.ELIMINAREMPRESA(codemp)
            MessageBox.Show("Acaba de eliminar a " & razonsocial & " " & direccion & " " & telefono & " " & rnc & estatus & "Eliminar registro")
            dgvEmpresa.DataSource = DATOSEMPRESA.mostrarEmpresa

        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim FILA As DataGridViewRow = dgvEmpresa.CurrentRow
        Dim codigo As String = FILA.Cells(0).Value
        Dim FME As New frmModificarEmpresa(codigo)
        AddHandler FME.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmMantenimientoEmpresa_FormClosed)
        FME.Show()
    End Sub

End Class