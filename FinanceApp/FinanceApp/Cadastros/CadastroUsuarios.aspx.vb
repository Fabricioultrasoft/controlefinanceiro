Public Class CadastroUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("id") IsNot Nothing Then
                lbEditUsuario.Visible = True
                lbExcluirUsuario.Visible = True
                lbNovoUsuario.Visible = False
            Else
                lbEditUsuario.Visible = False
                lbExcluirUsuario.Visible = False
                lbNovoUsuario.Visible = True
            End If
        End If
    End Sub

    Private Sub lbNovoUsuario_Click(sender As Object, e As System.EventArgs) Handles lbNovoUsuario.Click

    End Sub

    Private Sub lbEditUsuario_Click(sender As Object, e As System.EventArgs) Handles lbEditUsuario.Click

    End Sub

    Private Sub lbExcluirUsuario_Click(sender As Object, e As System.EventArgs) Handles lbExcluirUsuario.Click

    End Sub
End Class