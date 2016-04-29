Imports System.data
Imports System.Collections.Generic
Imports ingNovar.Utilidades2

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Session.RemoveAll()
        Response.Redirect("../login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_fecha.Text = Format(Now(), "dd/MMMM/yyyy")
    End Sub
End Class

