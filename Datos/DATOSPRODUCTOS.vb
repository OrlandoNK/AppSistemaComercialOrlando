Public Class DATOSPRODUCTOS
    Public Shared Function mostrarProductos() As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCODIGO(ByVal CODIGO As String) As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Where P.IDPRODUCTO = CODIGO
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORNOMBRE(ByVal NOMBRE As String) As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Where P.NOMBRE.StartsWith(NOMBRE)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORDESCRIPCION(ByVal DESCRIPCION As String) As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Where P.Descripcion.StartsWith(DESCRIPCION)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORPRECIO(ByVal PRECIO As String) As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Where P.PRECIO_UNITARIO = PRECIO
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORSTOCK(ByVal STOCK As String) As List(Of PRODUCTO)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.PRODUCTO
                        Where P.Stock = STOCK
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Sub AGREGARPRODUCTO(ByVal nombre As String, ByVal descripcion As String, ByVal precio As String, ByVal stock As String)
        'creamos la instancia a nuestro modelo de base de datos'

        Using bd As New DBCOMERCIALEntities
            'para insertar un nuevo objeto o cliente asignando los valores de los parametros a los campos de la tabla'
            bd.PRODUCTO.Add(New PRODUCTO() With {.NOMBRE = nombre, .Descripcion = descripcion, .PRECIO_UNITARIO = precio,
                    .Stock = stock})
            'guardar los cambios'
            bd.SaveChanges()

        End Using
    End Sub
    'Ahora crearemos el metodo para modificar los datos a un cliente'
    Public Shared Sub MODIFICARPRODUCTO(ByVal codigo As String, ByVal nombre As String, ByVal descripcion As String, ByVal precio As String, ByVal stock As String)
        'creamos la instancia a nuestro modelo de base de datos'
        Using bd As New DBCOMERCIALEntities()
            'se hace una consulta linq para buscar el cliente que se desea modificar '

            Dim MODIFICA = (From p In bd.PRODUCTO Where p.IDPRODUCTO = codigo
                            Select p).Single

            'Se asignan los valores de los parametros a los campos de la base de datos'
            MODIFICA.NOMBRE = nombre
            MODIFICA.Descripcion = descripcion
            MODIFICA.PRECIO_UNITARIO = precio
            MODIFICA.Stock = stock
            'para guardar  los cambios'

            bd.SaveChanges()
        End Using
    End Sub

    'crearemos el metodo para eliminar el cliente 
    Public Shared Sub ELIMINARPRODUCTO(ByVal codigo As String)
        'crear instancia
        Using bd As New DBCOMERCIALEntities
            Dim BORRAR = (From p In bd.PRODUCTO
                          Where p.IDPRODUCTO = codigo
                          Select p).Single
            'este metodo borra el registro 
            bd.PRODUCTO.Remove(BORRAR)

            bd.SaveChanges()

        End Using
    End Sub
    'crearemos un metodo para obtener el codigo del cliente y usarlo en otros formularios
    Public Shared Function OBTENERCODIGO(ByVal codigo As String) As PRODUCTO
        Dim PRODUCTO As New PRODUCTO
        Using bd As New DBCOMERCIALEntities
            Dim PROD = (From p In bd.PRODUCTO
                        Where p.IDPRODUCTO = codigo
                        Select p).Single
            PRODUCTO.IDPRODUCTO = PROD.IDPRODUCTO
            PRODUCTO.NOMBRE = PROD.NOMBRE
            PRODUCTO.Descripcion = PROD.Descripcion
            PRODUCTO.PRECIO_UNITARIO = PROD.PRECIO_UNITARIO
            PRODUCTO.Stock = PROD.Stock
            Return PRODUCTO
        End Using
    End Function
End Class



