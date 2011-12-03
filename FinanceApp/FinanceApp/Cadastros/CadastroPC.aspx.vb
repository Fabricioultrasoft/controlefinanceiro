Public Class CadastroPC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbNovoPlano_Click(sender As Object, e As System.EventArgs) Handles lbNovoPlano.Click
        cadastroPC.SetViewIndex = 1
        cadastroPC.SetActiveView()
    End Sub
End Class