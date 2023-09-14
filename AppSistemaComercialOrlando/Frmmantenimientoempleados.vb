Imports Datos
Public Class Frmmantenimientoempleados
    Private Sub Frmmantenimientoempleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvEmpleados.DataSource = DATOSEMPLEADOS.mostrarEmpleado
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "" Then
            dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORCODIGO(txtCodigo.Text)

        Else

            dgvEmpleados.DataSource = DATOSEMPLEADOS.mostrarEmpleado
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORNOMBRE(txtNombre.Text)
    End Sub

    Private Sub txtApellido_TextChanged(sender As Object, e As EventArgs) Handles txtApellido.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORAPELLIDO(txtApellido.Text)
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORDIRECCION(txtDireccion.Text)
    End Sub

    Private Sub txtCiudad_TextChanged(sender As Object, e As EventArgs) Handles txtCiudad.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORCIUDAD(txtCiudad.Text)
    End Sub

    Private Sub txtCodigoPostal_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoPostal.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORCODIGOPOSTAL(txtCodigoPostal.Text)
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORCORREO(txtEmail.Text)
    End Sub

    Private Sub txtNumTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtNumTelefono.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORTELEFONO(txtNumTelefono.Text)
    End Sub

    Private Sub txtfecha_TextChanged(sender As Object, e As EventArgs) Handles txtfecha.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORFECHACONTRATACION(txtfecha.Text)
    End Sub

    Private Sub txtcargo_TextChanged(sender As Object, e As EventArgs) Handles txtcargo.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORCARGO(txtcargo.Text)
    End Sub

    Private Sub txtsalario_TextChanged(sender As Object, e As EventArgs) Handles txtsalario.TextChanged
        dgvEmpleados.DataSource = DATOSEMPLEADOS.BUSCARPORSALARIO(txtsalario.Text)
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

    Private Sub txtApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido.KeyPress
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

    Private Sub txtCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiudad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodigoPostal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPostal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
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

    Private Sub txtfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcargo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtsalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsalario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim FAE As New frmagregarempleado()
        AddHandler FAE.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Frmmantenimientoempleados_FormClosed)
        FAE.Show()
    End Sub

    Private Sub Frmmantenimientoempleados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        dgvEmpleados.DataSource = DATOSEMPLEADOS.mostrarEmpleado
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim FILA As DataGridViewRow = dgvEmpleados.CurrentRow
        Dim codigo As String = FILA.Cells(0).Value
        Dim FME As New frmModificarEmpleado(codigo)
        AddHandler FME.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Frmmantenimientoempleados_FormClosed)
        FME.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de querer eliminar este registro?", "Advertencia de eliminacion", MessageBoxButtons.YesNo)

        If respuesta = DialogResult.Yes Then

            Dim registro As DataGridViewRow = dgvEmpleados.CurrentRow
            Dim codemp As String = registro.Cells(0).Value
            Dim nombre As String = registro.Cells(1).Value
            Dim apellido As String = registro.Cells(2).Value
            Dim direccion As String = registro.Cells(3).Value
            Dim ciudad As String = registro.Cells(4).Value
            Dim codigopostal As String = registro.Cells(5).Value
            Dim correo As String = registro.Cells(6).Value
            Dim telefono As String = registro.Cells(7).Value
            Dim fecha As String = registro.Cells(8).Value
            Dim cargo As String = registro.Cells(9).Value
            Dim salario As String = registro.Cells(10).Value
            DATOSEMPLEADOS.ELIMINAREMPLEADO(codemp)
            MessageBox.Show("Acaba de eliminar a " & nombre & " " & apellido & " " & direccion & " " & ciudad & " " & codigopostal & " " & correo & " " & telefono & fecha & cargo & salario, "Eliminar registro")
            dgvEmpleados.DataSource = Datos.DATOSCLIENTES.mostrarCliente
        End If
    End Sub
End Class