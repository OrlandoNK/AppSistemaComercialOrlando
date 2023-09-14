Public Class DATOSPROVEEDORES
    Public Shared Function mostrarProveedores() As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCODIGO(ByVal CODIGO As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.IDPROVEEDOR = CODIGO
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORPROVEEDOR(ByVal PROVEEDOR As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.PROVEEDOR.StartsWith(PROVEEDOR)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORCONTACTO(ByVal CONTACTO As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.CONTACTO.StartsWith(CONTACTO)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORTELEFONO(ByVal TELEFONO As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.TELEFONO.StartsWith(TELEFONO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORESTATUS(ByVal ESTATUS As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.ESTATUS.StartsWith(ESTATUS)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORDIRECCION(ByVal DIRECCION As String) As List(Of PROVEEDORES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PROVEEDORES
                        Where P.DIRECCION.StartsWith(DIRECCION)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Sub AGREGARPROVEEDOR(ByVal proveedor As String, ByVal contacto As String, ByVal telefono As String, ByVal direccion As String, ByVal estatus As String)
        'creamos la instancia a nuestro modelo de base de datos'

        Using bd As New DBCOMERCIALEntities
            'para insertar un nuevo objeto o cliente asignando los valores de los parametros a los campos de la tabla'
            bd.PROVEEDORES.Add(New PROVEEDORES() With {.PROVEEDOR = proveedor, .CONTACTO = contacto, .TELEFONO = telefono,
                    .DIRECCION = direccion, .ESTATUS = estatus})
            'guardar los cambios'
            bd.SaveChanges()

        End Using
    End Sub
    'Ahora crearemos el metodo para modificar los datos a un cliente'
    Public Shared Sub MODIFICARPROVEEDOR(ByVal codigo As String, ByVal proveedor As String, ByVal contacto As String, ByVal telefono As String, ByVal direccion As String, ByVal estatus As String)
        'creamos la instancia a nuestro modelo de base de datos'
        Using bd As New DBCOMERCIALEntities()
            'se hace una consulta linq para buscar el cliente que se desea modificar '

            Dim MODIFICA = (From p In bd.PROVEEDORES Where p.IDPROVEEDOR = codigo
                            Select p).Single

            'Se asignan los valores de los parametros a los campos de la base de datos'
            MODIFICA.PROVEEDOR = proveedor
            MODIFICA.CONTACTO = contacto
            MODIFICA.TELEFONO = telefono
            MODIFICA.DIRECCION = direccion
            MODIFICA.ESTATUS = estatus
            'para guardar  los cambios'

            bd.SaveChanges()
        End Using
    End Sub

    'crearemos el metodo para eliminar el cliente 
    Public Shared Sub ELIMINARPROVEEDOR(ByVal codigo As String)
        'crear instancia
        Using bd As New DBCOMERCIALEntities
            Dim BORRAR = (From p In bd.PROVEEDORES
                          Where p.IDPROVEEDOR = codigo
                          Select p).Single
            'este metodo borra el registro 
            bd.PROVEEDORES.Remove(BORRAR)

            bd.SaveChanges()

        End Using
    End Sub
    'crearemos un metodo para obtener el codigo del cliente y usarlo en otros formularios
    Public Shared Function OBTENERCODIGO(ByVal codigo As String) As PROVEEDORES
        Dim PROOVEEDORES As New PROVEEDORES
        Using bd As New DBCOMERCIALEntities
            Dim PROOV = (From p In bd.PROVEEDORES
                         Where p.IDPROVEEDOR = codigo
                         Select p).Single
            PROOVEEDORES.IDPROVEEDOR = PROOV.IDPROVEEDOR
            PROOVEEDORES.PROVEEDOR = PROOV.PROVEEDOR
            PROOVEEDORES.CONTACTO = PROOV.CONTACTO
            PROOVEEDORES.TELEFONO = PROOV.TELEFONO
            PROOVEEDORES.DIRECCION = PROOV.DIRECCION
            PROOVEEDORES.ESTATUS = PROOV.ESTATUS
            Return PROOV
        End Using
    End Function
End Class
