Public Class Cadastro
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbPC_Click(sender As Object, e As System.EventArgs) Handles lbPC.Click
        Response.Redirect("~/Cadastros/CadastroPC.aspx")
    End Sub
End Class