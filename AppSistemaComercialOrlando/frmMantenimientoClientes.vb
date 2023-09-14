Public Class frmMantenimientoClientes
    Private Sub frmMantenimientoClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCliente.DataSource = Datos.DATOSCLIENTES.mostrarCliente()
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text <> "" Then
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORCODIGO(txtCodigo.Text)

        Else

            dgvCliente.DataSource = Datos.DATOSCLIENTES.mostrarCliente
        End If


    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged


        Try
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORNOMBRE(txtNombre.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub txtApellido_TextChanged(sender As Object, e As EventArgs) Handles txtApellido.TextChanged

        Try
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORAPELLIDO(txtApellido.Text)

        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try





    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged



        Try
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORDIRECCION(txtDireccion.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub txtCiudad_TextChanged(sender As Object, e As EventArgs) Handles txtCiudad.TextChanged



        Try
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORCIUDAD(txtCiudad.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub txtCodigoPostal_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoPostal.TextChanged
        Try
            dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORCODIGOPOSTAL(txtCodigoPostal.Text)
        Catch ex As Exception
            ' Manejo de la excepción
            MessageBox.Show("Coloque Los datos a buscar: " & MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORCORREO(txtEmail.Text)
    End Sub

    Private Sub txtNumTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtNumTelefono.TextChanged

        dgvCliente.DataSource = Datos.DATOSCLIENTES.BUSCARPORTELEFONO(txtNumTelefono.Text)

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

    Private Sub frmMantenimientoClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        dgvCliente.DataSource = Datos.DATOSCLIENTES.mostrarCliente

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'crearemos una instancia de tipo frmAgregarCliente
        Dim FAC As New frmAgregarCliente()
        'Abrimos el formulario y actualizamos el DataGridView dgvClientes
        AddHandler FAC.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmMantenimientoClientes_FormClosed)
        FAC.Show()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim FILA As DataGridViewRow = dgvCliente.CurrentRow
        Dim codigo As String = FILA.Cells(0).Value
        Dim FMC As New frmModificarCliente(codigo)
        AddHandler FMC.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf frmMantenimientoClientes_FormClosed)
        FMC.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de querer eliminar este registro?", "Advertencia de eliminacion", MessageBoxButtons.YesNo)

        If respuesta = DialogResult.Yes Then

            Dim registro As DataGridViewRow = dgvCliente.CurrentRow
            Dim codclie As String = registro.Cells(0).Value
            Dim nombre As String = registro.Cells(1).Value
            Dim apellido As String = registro.Cells(2).Value
            Dim direccion As String = registro.Cells(3).Value
            Dim ciudad As String = registro.Cells(4).Value
            Dim codigopostal As String = registro.Cells(5).Value
            Dim correo As String = registro.Cells(6).Value
            Dim telefono As String = registro.Cells(7).Value
            Datos.DATOSCLIENTES.ELIMINARCLIENTE(codclie)
            MessageBox.Show("Acaba de eliminar a " & nombre & " " & apellido & " " & direccion & " " & ciudad & " " & codigopostal & " " & correo & " " & telefono, "Eliminar registro")
            dgvCliente.DataSource = Datos.DATOSCLIENTES.mostrarCliente

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class