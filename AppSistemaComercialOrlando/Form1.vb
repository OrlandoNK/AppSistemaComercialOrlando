Public Class frmMenuPrincipal
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim fcliente As New frmMantenimientoClientes()
        fcliente.MdiParent = Me
        fcliente.Show()
    End Sub

    Private Sub SalirDelSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirDelSistemaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Dim fempleado As New Frmmantenimientoempleados()
        fempleado.MdiParent = Me
        fempleado.Show()
    End Sub

    Private Sub EmpresasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpresasToolStripMenuItem.Click
        Dim fempresa As New frmMantenimientoEmpresa()
        fempresa.MdiParent = Me
        fempresa.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim fproveedores As New frmmantenimientoproveedores()
        fproveedores.MdiParent = Me
        fproveedores.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim fproducto As New frmmantenimientoproductos()
        fproducto.MdiParent = Me
        fproducto.Show()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
