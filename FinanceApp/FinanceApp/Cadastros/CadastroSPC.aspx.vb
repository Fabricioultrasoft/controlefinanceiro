Public Class CadastroSPC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("id") IsNot Nothing Then
                lbEditSP.Visible = True
                lbExcluirSP.Visible = True
                lbNovoSP.Visible = False
            Else
                lbEditSP.Visible = False
                lbExcluirSP.Visible = False
                lbNovoSP.Visible = True
            End If
        End If
    End Sub

    Private Sub lbNovoSP_Click(sender As Object, e As System.EventArgs) Handles lbNovoSP.Click
        CadastroSPC.PageMode = uc_CadastroSPC.Modo.NOVO
        CadastroSPC.setActiveView(1)
    End Sub

    Private Sub lbEditSP_Click(sender As Object, e As System.EventArgs) Handles lbEditSP.Click
        CadastroSPC.PageMode = uc_CadastroSPC.Modo.EDIT
        CadastroSPC.setVisibleButtons(True)
    End Sub

    Private Sub lbExcluirSP_Click(sender As Object, e As System.EventArgs) Handles lbExcluirSP.Click
        CadastroSPC.PageMode = uc_CadastroSPC.Modo.DELETE
        CadastroSPC.setActiveView(2)
    End Sub
End Class