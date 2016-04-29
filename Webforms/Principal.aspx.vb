
Partial Class Webforms_Principal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack Then Exit Sub

        If Session("IdUsuario") Is Nothing Then
            Session.RemoveAll()
            Response.Redirect("../login.aspx")
            Exit Sub
        End If
        If Session("Id_Proyecto") Is Nothing Then
            Session.RemoveAll()
            Response.Redirect("../login.aspx")
            Exit Sub
        End If

        Dim lblidUsuario As Label
        lblidUsuario = Master.FindControl("lblidusuario")
        lblidUsuario.Text = Session("IdUsuario")

        Dim LblNombreUsuario As Label
        LblNombreUsuario = Master.FindControl("LblNombreUsuario")
        LblNombreUsuario.Text = Session("NombreUsuario")

        Dim Lbl_regional As Label
        Lbl_regional = Master.FindControl("Lbl_regional")
        Lbl_regional.Text = Session("NombreRegional")

        Dim Lbl_usuario As Label
        Lbl_usuario = Master.FindControl("Lbl_usuario")
        Lbl_usuario.Text = Session("LoginUsuario")

        Dim Lbl_perfil As Label
        Lbl_perfil = Master.FindControl("Lbl_perfil")
        Lbl_perfil.Text = Session("NombrePerfil")

        Me.Header.Title = "SAFIRD Sistema Financiero IRD"

        Me.lblcorreo1.Text = "rortiz@irdglobal.org"
        Me.lblcorreo1.NavigateUrl = "mailto://" + lblcorreo1.Text
        Me.lbldireccion1.Text = "Cra 19 C 86 A 43 Ofc 201"
        Me.lblfax1.Text = "7446670 ext 103"
        Me.lblnombre1.Text = "I.R.D."
        Me.Lbltel1.Text = "7446670"
        Me.lbloa1.Text = "Sistema de Administración Financiera IRD SAFIRD. "
        Me.lblweb1.Text = "www.ird.org.co"
        Me.lblweb1.NavigateUrl = "http://" + lblweb1.Text

    End Sub

End Class
