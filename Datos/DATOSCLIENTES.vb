Public Class DATOSCLIENTES
    Public Shared Function mostrarCliente() As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCODIGO(ByVal CODIGO As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.IDCLIENTE = CODIGO
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORNOMBRE(ByVal NOMBRE As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.NOMBRE.StartsWith(NOMBRE)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORAPELLIDO(ByVal APELLIDO As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.APELLIDO.StartsWith(APELLIDO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORDIRECCION(ByVal DIRECCION As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.DIRECCION.StartsWith(DIRECCION)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCODIGOPOSTAL(ByVal CODIGOPOSTAL As Integer) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.CODIGOPOSTAL = CODIGOPOSTAL
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCORREO(ByVal CORREO As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.EMAIL.StartsWith(CORREO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORTELEFONO(ByVal TELEFONO As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.NUMTELEFONO.StartsWith(TELEFONO)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORSEXO(ByVal SEXO As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.SEXO.StartsWith(SEXO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCIUDAD(ByVal CIUDAD As String) As List(Of CLIENTES)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.CLIENTES
                        Where P.CIUDAD.StartsWith(CIUDAD)
                        Select P).ToList
            Return INFO
        End Using

    End Function
    Public Shared Sub AGREGARCLIENTE(ByVal nombre As String, ByVal apellido As String, ByVal direccion As String,
     ByVal ciudad As String, ByVal codigopostal As String, ByVal email As String, ByVal telefono As String, ByVal sexo As String)
        'creamos la instancia a nuestro modelo de base de datos'

        Using bd As New DBCOMERCIALEntities
            'para insertar un nuevo objeto o cliente asignando los valores de los parametros a los campos de la tabla'
            bd.CLIENTES.Add(New CLIENTES() With {.NOMBRE = nombre, .APELLIDO = apellido, .DIRECCION = direccion,
                            .CIUDAD = ciudad, .CODIGOPOSTAL = codigopostal, .EMAIL = email, .NUMTELEFONO = telefono, .SEXO = sexo})
            'guardar los cambios'
            bd.SaveChanges()

        End Using
    End Sub
    'Ahora crearemos el metodo para modificar los datos a un cliente'
    Public Shared Sub MODIFICARCLIENTE(ByVal codigo As String, ByVal nombre As String, ByVal apellido As String, ByVal direccion As String,
     ByVal ciudad As String, ByVal codigopostal As String, ByVal email As String, ByVal telefono As String)
        'creamos la instancia a nuestro modelo de base de datos'
        Using bd As New DBCOMERCIALEntities()
            'se hace una consulta linq para buscar el cliente que se desea modificar '

            Dim MODIFICA = (From p In bd.CLIENTES Where p.IDCLIENTE = codigo
                            Select p).Single

            'Se asignan los valores de los parametros a los campos de la base de datos'
            MODIFICA.NOMBRE = nombre
            MODIFICA.APELLIDO = apellido
            MODIFICA.DIRECCION = direccion
            MODIFICA.CIUDAD = ciudad
            MODIFICA.CODIGOPOSTAL = codigopostal
            MODIFICA.EMAIL = email
            MODIFICA.NUMTELEFONO = telefono

            'para guardar  los cambios'

            bd.SaveChanges()
        End Using
    End Sub

    'crearemos el metodo para eliminar el cliente 
    Public Shared Sub ELIMINARCLIENTE(ByVal codigo As String)
        'crear instancia
        Using bd As New DBCOMERCIALEntities
            Dim BORRAR = (From p In bd.CLIENTES
                          Where p.IDCLIENTE = codigo
                          Select p).Single
            'este metodo borra el registro 
            bd.CLIENTES.Remove(BORRAR)

            bd.SaveChanges()

        End Using
    End Sub
    'crearemos un metodo para obtener el codigo del cliente y usarlo en otros formularios
    Public Shared Function OBTENERCODIGO(ByVal codigo As String) As CLIENTES
        Dim CLIENTE As New CLIENTES
        Using bd As New DBCOMERCIALEntities
            Dim CLIE = (From p In bd.CLIENTES
                        Where p.IDCLIENTE = codigo
                        Select p).Single
            CLIENTE.IDCLIENTE = CLIE.IDCLIENTE
            CLIENTE.NOMBRE = CLIE.NOMBRE
            CLIENTE.APELLIDO = CLIE.APELLIDO
            CLIENTE.DIRECCION = CLIE.DIRECCION
            CLIENTE.CIUDAD = CLIE.CIUDAD
            CLIENTE.CODIGOPOSTAL = CLIE.CODIGOPOSTAL
            CLIENTE.EMAIL = CLIE.EMAIL
            CLIENTE.NUMTELEFONO = CLIE.NUMTELEFONO
            CLIENTE.SEXO = CLIE.SEXO
            Return CLIENTE
        End Using
    End Function
End Class
