
Public Class Basic
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbResumo_Click(sender As Object, e As System.EventArgs) Handles lbResumo.Click
        Response.Redirect(ResolveUrl("~/Resumo.aspx"))
    End Sub

    Private Sub lbContas_Click(sender As Object, e As System.EventArgs) Handles lbContas.Click
        Response.Redirect(ResolveUrl("~/Contas/ContasAPagar.aspx"))
    End Sub

    Private Sub lbCadastros_Click(sender As Object, e As System.EventArgs) Handles lbCadastros.Click
        Response.Redirect(ResolveUrl("~/Cadastros/CadastroPC.aspx"))
    End Sub
End Class
