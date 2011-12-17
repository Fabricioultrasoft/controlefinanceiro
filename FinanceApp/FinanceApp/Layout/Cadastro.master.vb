Public Class Cadastro
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbPC_Click(sender As Object, e As System.EventArgs) Handles lbPC.Click
        Response.Redirect("~/Cadastros/CadastroPC.aspx")
    End Sub

    Private Sub lbSPC_Click(sender As Object, e As System.EventArgs) Handles lbSPC.Click
        Response.Redirect("~/Cadastros/CadastroSPC.aspx")
    End Sub

    Private Sub lbUsuarios_Click(sender As Object, e As System.EventArgs) Handles lbUsuarios.Click
        Response.Redirect("~/Cadastros/CadastroUsuarios.aspx")
    End Sub
End Class