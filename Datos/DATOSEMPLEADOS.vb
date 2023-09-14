Public Class DATOSEMPLEADOS
    Public Shared Function mostrarEmpleado() As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCODIGO(ByVal CODIGO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.IDEMPLEADO = CODIGO
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORNOMBRE(ByVal NOMBRE As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.NOMBRE.StartsWith(NOMBRE)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORAPELLIDO(ByVal APELLIDO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.APELLIDO.StartsWith(APELLIDO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORDIRECCION(ByVal DIRECCION As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.DIRECCION.StartsWith(DIRECCION)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCODIGOPOSTAL(ByVal CODIGOPOSTAL As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.CODIGOPOSTAL = CODIGOPOSTAL
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCORREO(ByVal CORREO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.EMAIL.StartsWith(CORREO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORTELEFONO(ByVal TELEFONO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.NUMTELEFONO.StartsWith(TELEFONO)
                        Select P).ToList
            Return INFO
        End Using
    End Function

    Public Shared Function BUSCARPORSEXO(ByVal SEXO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.SEXO.StartsWith(SEXO)
                        Select P).ToList
            Return INFO
        End Using
    End Function
    Public Shared Function BUSCARPORCIUDAD(ByVal CIUDAD As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.CIUDAD.StartsWith(CIUDAD)
                        Select P).ToList
            Return INFO
        End Using

    End Function

    Public Shared Function BUSCARPORCARGO(ByVal CARGO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.CARGO.StartsWith(CARGO)
                        Select P).ToList
            Return INFO
        End Using

    End Function
    Public Shared Function BUSCARPORSALARIO(ByVal SALARIO As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.SALARIO = SALARIO
                        Select P).ToList
            Return INFO
        End Using

    End Function
    Public Shared Function BUSCARPORFECHACONTRATACION(ByVal FECHA As String) As List(Of EMPLEADOS)
        Using BD As New DBCOMERCIALEntities
            Dim INFO = (From P In BD.EMPLEADOS
                        Where P.FECHACONTRATACION = FECHA
                        Select P).ToList
            Return INFO
        End Using

    End Function
    Public Shared Sub AGREGAREMPLEADO(ByVal nombre As String, ByVal apellido As String, ByVal direccion As String,
 ByVal ciudad As String, ByVal codigopostal As String, ByVal email As String, ByVal telefono As String, ByVal fechacontratacion As String, ByVal cargo As String, ByVal salario As String, ByVal sexo As String)
        'creamos la instancia a nuestro modelo de base de datos'

        Using bd As New DBCOMERCIALEntities
            'para insertar un nuevo objeto o cliente asignando los valores de los parametros a los campos de la tabla'
            bd.EMPLEADOS.Add(New EMPLEADOS() With {.NOMBRE = nombre, .APELLIDO = apellido, .DIRECCION = direccion,
                        .CIUDAD = ciudad, .CODIGOPOSTAL = codigopostal, .EMAIL = email, .NUMTELEFONO = telefono, .FECHACONTRATACION = fechacontratacion, .CARGO = cargo, .SALARIO = salario, .SEXO = sexo})
            'guardar los cambios'
            bd.SaveChanges()

        End Using
    End Sub
    'Ahora crearemos el metodo para modificar los datos a un cliente'
    Public Shared Sub MODIFICAREMPLEADO(ByVal codigo As String, ByVal nombre As String, ByVal apellido As String, ByVal direccion As String,
 ByVal ciudad As String, ByVal codigopostal As String, ByVal email As String, ByVal telefono As String, ByVal fechacontratacion As String, ByVal cargo As String, ByVal salario As String, ByVal sexo As String)
        'creamos la instancia a nuestro modelo de base de datos'
        Using bd As New DBCOMERCIALEntities()
            'se hace una consulta linq para buscar el cliente que se desea modificar '

            Dim MODIFICA = (From p In bd.EMPLEADOS Where p.IDEMPLEADO = codigo
                            Select p).Single

            'Se asignan los valores de los parametros a los campos de la base de datos'
            MODIFICA.NOMBRE = nombre
            MODIFICA.APELLIDO = apellido
            MODIFICA.DIRECCION = direccion
            MODIFICA.CIUDAD = ciudad
            MODIFICA.CODIGOPOSTAL = codigopostal
            MODIFICA.EMAIL = email
            MODIFICA.NUMTELEFONO = telefono
            MODIFICA.FECHACONTRATACION = fechacontratacion
            MODIFICA.CARGO = cargo
            MODIFICA.SALARIO = salario
            'para guardar  los cambios'

            bd.SaveChanges()
        End Using
    End Sub

    'crearemos el metodo para eliminar el cliente 
    Public Shared Sub ELIMINAREMPLEADO(ByVal codigo As String)
        'crear instancia
        Using bd As New DBCOMERCIALEntities
            Dim BORRAR = (From p In bd.EMPLEADOS
                          Where p.IDEMPLEADO = codigo
                          Select p).Single
            'este metodo borra el registro 
            bd.EMPLEADOS.Remove(BORRAR)

            bd.SaveChanges()

        End Using
    End Sub
    'crearemos un metodo para obtener el codigo del cliente y usarlo en otros formularios
    Public Shared Function OBTENERCODIGO(ByVal codigo As String) As EMPLEADOS
        Dim EMPLEADO As New EMPLEADOS
        Using bd As New DBCOMERCIALEntities
            Dim EMPLE = (From p In bd.EMPLEADOS
                         Where p.IDEMPLEADO = codigo
                         Select p).Single
            EMPLEADO.IDEMPLEADO = EMPLE.IDEMPLEADO
            EMPLEADO.NOMBRE = EMPLE.NOMBRE
            EMPLEADO.APELLIDO = EMPLE.APELLIDO
            EMPLEADO.DIRECCION = EMPLE.DIRECCION
            EMPLEADO.CIUDAD = EMPLE.CIUDAD
            EMPLEADO.CODIGOPOSTAL = EMPLE.CODIGOPOSTAL
            EMPLEADO.EMAIL = EMPLE.EMAIL
            EMPLEADO.NUMTELEFONO = EMPLE.NUMTELEFONO
            EMPLEADO.FECHACONTRATACION = EMPLE.FECHACONTRATACION
            EMPLEADO.CARGO = EMPLE.CARGO
            EMPLEADO.SALARIO = EMPLE.SALARIO
            EMPLEADO.SEXO = EMPLE.SEXO

            Return EMPLEADO
        End Using
    End Function
End Class


