Public Class CadastroPC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("id") IsNot Nothing Then
                lbEditPlano.Visible = True
                lbExcluirPlano.Visible = True
                lbNovoPlano.Visible = False
            Else
                lbEditPlano.Visible = False
                lbExcluirPlano.Visible = False
                lbNovoPlano.Visible = True
            End If
        End If
    End Sub

    Private Sub lbNovoPlano_Click(sender As Object, e As System.EventArgs) Handles lbNovoPlano.Click
        cadastroPC.PageMode = uc_CadastroPC.Modo.NOVO
        cadastroPC.setActiveView(1)
    End Sub

    Private Sub lbEditPlano_Click(sender As Object, e As System.EventArgs) Handles lbEditPlano.Click
        cadastroPC.PageMode = uc_CadastroPC.Modo.EDIT
        cadastroPC.setVisibleButtons(True)
    End Sub

    Private Sub lbExcluirPlano_Click(sender As Object, e As System.EventArgs) Handles lbExcluirPlano.Click
        cadastroPC.PageMode = uc_CadastroPC.Modo.DELETE
        'Criar popriedade para assinar plano porque ele só está dando postback no controle!
        cadastroPC.setActiveView(2)
    End Sub
End Class