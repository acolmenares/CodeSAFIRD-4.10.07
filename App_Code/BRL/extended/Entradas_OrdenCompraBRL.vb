Imports Microsoft.VisualBasic

Partial Public Class Entradas_OrdenCompraBRL

    Public Shared Function CantidadEntradaOC(ByVal Id_OrdenCompra_Detalle As Integer) As Double
        Return Entradas_OrdenCompraDAL.CantidadEntradaOC(Id_OrdenCompra_Detalle)
    End Function

End Class
