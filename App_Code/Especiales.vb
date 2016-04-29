Imports Microsoft.VisualBasic

Partial Public Class Especiales

    Public Shared Function ajustarFecha10digitos(ByVal fecha As Date) As String
        Dim wfecha As String = ""
        Dim wstrdia, wstrmes As String
        Dim wdia, wmes, wano As Integer
        If Len(fecha.ToString.Trim) = 10 Then
            wfecha = fecha.ToString.Trim
        Else
            wdia = fecha.Day
            wmes = fecha.Month
            wano = fecha.Year
            If Len(wdia.ToString.Trim) = 1 Then
                wstrdia = "0" & wdia.ToString.Trim
            Else
                wstrdia = wdia.ToString.Trim
            End If
            If Len(wmes.ToString.Trim) = 1 Then
                wstrmes = "0" & wmes.ToString.Trim
            Else
                wstrmes = wmes.ToString.Trim
            End If
            wfecha = wstrdia & "/" & wstrmes & "/" & fecha.Year.ToString.Trim
        End If
        Return wfecha
    End Function

End Class
