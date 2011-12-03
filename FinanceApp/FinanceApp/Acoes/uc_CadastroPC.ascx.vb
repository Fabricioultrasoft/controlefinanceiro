Public Class uc_CadastroPC
    Inherits System.Web.UI.UserControl

#Region "Properties"

    Public Property SetViewIndex() As Integer

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        'End If
    End Sub

    Public Sub SetActiveView()
        mvPlanoDecontas.ActiveViewIndex = SetViewIndex
    End Sub

End Class