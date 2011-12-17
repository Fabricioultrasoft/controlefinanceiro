Imports FinanceiroDLL.Model
Imports FinanceiroDLL.DAO

Public Class uc_CadastroUsuario
    Inherits System.Web.UI.UserControl

#Region "Enums"

    Public Enum Modo
        NOVO = 1
        EDIT = 2
        DELETE = 3
        RECUPERAR = 4
    End Enum

#End Region

#Region "Propriedade"

    Public Property IdUsuario() As Integer
        Get
            Return ViewState("IdUsuario")
        End Get
        Set(value As Integer)
            ViewState("IdUsuario") = value
        End Set
    End Property

    Public Property PageMode() As Modo
        Get
            Return ViewState("Modo")
        End Get
        Set(value As Modo)
            ViewState("Modo") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString("id") IsNot Nothing Then
                IdUsuario = Integer.Parse(Request.QueryString("id"))
            End If

            If IdUsuario <> 0 Then

            Else
                mvUsuarios.ActiveViewIndex = 0
                'listarUsuarios()
            End If
        End If
    End Sub

End Class