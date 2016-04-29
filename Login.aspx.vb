Imports System.Security.Cryptography
Imports SeguridadUsuarios

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub imgok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgok.Click
        ' validacion de Usuario
        lbl_error.Text = ""
        Dim objusuario As New UsuariosBrl
        objusuario = UsuariosBrl.CargarPorloginyContrasena(txt_login.Text, generarClaveSHA1(txt_contrasena.Text))
        Session.Remove("IdUsuario")
        Session.Remove("NombreUsuario")
        Session.Remove("LoginUsuario")
        Session.Remove("NombrePerfil")
        Session.Remove("NombreRegional")

        If objusuario IsNot Nothing Then
            lbl_error.Text = "Bienvenid@ " & objusuario.Nombre_Completo
            Session("IdUsuario") = objusuario.ID
            Session("NombreUsuario") = objusuario.Nombre_Completo
            Session("loginUsuario") = objusuario.Login
            Session("NombrePerfil") = objusuario.Perfiles.Descripcion
            Session("NombreRegional") = objusuario.Sucursales.Descripcion
            Session("Id_Proyecto") = ddl_Proyecto.SelectedValue
            FormsAuthentication.RedirectFromLoginPage(txt_login.Text, False)
        Else
            ' sino.. a la de error de login
            lbl_error.Text = "Error en Acceso de usuario o contraseña - Verifique !!!!"
        End If
    End Sub

    Private Function generarClaveSHA1(ByVal nombre As String) As String
        ' Crear una clave SHA1 como la generada por 
        ' FormsAuthentication.HashPasswordForStoringInConfigFile
        ' Adaptada del ejemplo de la ayuda en la descripción de SHA1 (Clase)
        Dim enc As New UTF8Encoding
        Dim data() As Byte = enc.GetBytes(nombre)
        Dim result() As Byte

        Dim sha As New SHA1CryptoServiceProvider
        ' This is one implementation of the abstract class SHA1.
        result = sha.ComputeHash(data)
        '
        ' Convertir los valores en hexadecimal
        ' cuando tiene una cifra hay que rellenarlo con cero
        ' para que siempre ocupen dos dígitos.
        Dim sb As New StringBuilder
        For i As Integer = 0 To result.Length - 1
            If result(i) < 16 Then
                sb.Append("0")
            End If
            sb.Append(result(i).ToString("x"))
        Next
        '
        Return sb.ToString.ToUpper
    End Function

End Class
