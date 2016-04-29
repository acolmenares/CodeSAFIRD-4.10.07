Imports System.Configuration.ConfigurationManager

Public Module Conexiones

    Public strCadenaConexion As String = AppSettings("BDIRD")
    Public TiempoConexion As String = AppSettings("TiempoConexion")
    Public strCadenaSEG As String = AppSettings("BDIRDSEG")
    Public strPaginaError As String = AppSettings("PaginaError")

End Module