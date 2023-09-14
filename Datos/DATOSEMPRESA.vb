Public Class DATOSEMPRESA
    Public Shared Function mostrarEmpresa() As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCODIGO(ByVal CODIGO As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.IDEMPRESA = CODIGO
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORRAZONSOCIAL(ByVal RAZONSOCIAL As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.RAZONSOCIAL.StartsWith(RAZONSOCIAL)
                        Select P).ToList
            Return INFO
        End Using
    End Function


    Public Shared Function BUSCARPORDIRECCION(ByVal DIRECCION As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.DIRECCION.StartsWith(DIRECCION)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORTELEFONO(ByVal TELEFONO As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.TELEFONO.StartsWith(TELEFONO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORRNC(ByVal RNC As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.RNC.StartsWith(RNC)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORESTATUS(ByVal ESTATUS As String) As List(Of EMPRESA)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPRESA
                        Where P.ESTATUS.StartsWith(ESTATUS)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Sub AGREGAREMPRESA(ByVal razonsocial As String, ByVal direccion As String, ByVal telefono As String,
     ByVal rnc As String, ByVal estatus As String)
        'creamos la instancia a nuestro modelo de base de datos'

        Using bd As New DBCOMERCIALEntities
            'para insertar un nuevo objeto o cliente asignando los valores de los parametros a los campos de la tabla'
            bd.EMPRESA.Add(New EMPRESA() With {.RAZONSOCIAL = razonsocial, .DIRECCION = direccion, .TELEFONO = telefono,
                            .RNC = rnc, .ESTATUS = estatus})
            'guardar los cambios'
            bd.SaveChanges()

        End Using
    End Sub
    'Ahora crearemos el metodo para modificar los datos a un cliente'
    Public Shared Sub MODIFICAREMPRESA(ByVal codigo As String, ByVal razonsocial As String, ByVal direccion As String, ByVal telefono As String,
    ByVal rnc As String, ByVal estatus As String)
        'creamos la instancia a nuestro modelo de base de datos'
        Using bd As New DBCOMERCIALEntities()
            'se hace una consulta linq para buscar el cliente que se desea modificar '

            Dim MODIFICA = (From p In bd.EMPRESA Where p.IDEMPRESA = codigo Select p).Single

            'Se asignan los valores de los parametros a los campos de la base de datos'
            MODIFICA.RAZONSOCIAL = razonsocial
            MODIFICA.DIRECCION = direccion
            MODIFICA.TELEFONO = telefono
            MODIFICA.RNC = rnc
            MODIFICA.ESTATUS = estatus
            'para guardar  los cambios'

            bd.SaveChanges()
        End Using
    End Sub


    'crearemos el metodo para eliminar el cliente 
    Public Shared Sub ELIMINAREMPRESA(ByVal codigo As String)
        'crear instancia
        Using bd As New DBCOMERCIALEntities
            Dim BORRAR = (From p In bd.EMPRESA
                          Where p.IDEMPRESA = codigo
                          Select p).Single
            'este metodo borra el registro 
            bd.EMPRESA.Remove(BORRAR)

            bd.SaveChanges()

        End Using
    End Sub
    'crearemos un metodo para obtener el codigo del cliente y usarlo en otros formularios
    Public Shared Function OBTENERCODIGO(ByVal codigo As String) As EMPRESA
        Dim EMPRESA As New EMPRESA
        Using bd As New DBCOMERCIALEntities
            Dim EMP = (From p In bd.EMPRESA
                       Where p.IDEMPRESA = codigo
                       Select p).Single
            EMPRESA.IDEMPRESA = EMP.IDEMPRESA
            EMPRESA.RAZONSOCIAL = EMP.RAZONSOCIAL
            EMPRESA.DIRECCION = EMP.DIRECCION
            EMPRESA.TELEFONO = EMP.TELEFONO
            EMPRESA.RNC = EMP.RNC
            EMPRESA.ESTATUS = EMP.ESTATUS
            Return EMPRESA
        End Using
    End Function
End Class
