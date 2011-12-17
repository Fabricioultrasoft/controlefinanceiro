Imports FinanceiroDLL.Model
Imports FinanceiroDLL.DAO

Public Class uc_CadastroPC
    Inherits System.Web.UI.UserControl

#Region "Enum"

    Public Enum Modo
        NOVO = 1
        EDIT = 2
        DELETE = 3
    End Enum

#End Region

#Region "Properties"

    Public Property IdPlano() As Integer
        Get
            Return ViewState("IdPlano")
        End Get
        Set(value As Integer)
            ViewState("IdPlano") = value
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

#Region "Eventos"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            mvPlanoDecontas.ActiveViewIndex = 0
            listarPlanos()

            If Request.QueryString("id") IsNot Nothing Then
                IdPlano = Integer.Parse(Request.QueryString("id"))
            End If

            If IdPlano <> 0 Then
                Dim pcDAO As New PlanoDeContasDAO
                Dim pc As PlanoDeContas = pcDAO.RetrievePlanoDeContas(IdPlano)

                lbSalvar.Visible = False
                lbCancelar.Visible = False
                txtDescricaoPlanoDeContas.Text = pc.Descricao
                txtDescricaoPlanoDeContas.Enabled = False

                mvPlanoDecontas.ActiveViewIndex = 1
            End If
        End If
    End Sub

    Private Sub lbSalvar_Click(sender As Object, e As System.EventArgs) Handles lbSalvar.Click
        If Not txtDescricaoPlanoDeContas.Text = "" Then
            mvPlanoDecontas.ActiveViewIndex = 2
            lblConfirmText.Text = "Confirma o cadastro do Plano de Contas: <b>" & txtDescricaoPlanoDeContas.Text & "</b> ?"
        Else
            lblErro.Visible = True
            lblErro.Text = "Escreva uma descrição para o plano de contas!"
        End If
    End Sub

    Private Sub lbCancelar_Click(sender As Object, e As System.EventArgs) Handles lbCancelar.Click
        txtDescricaoPlanoDeContas.Text = ""
        mvPlanoDecontas.ActiveViewIndex = 0

        If Request.QueryString("id") IsNot Nothing Then
            Response.Redirect("~/Cadastros/CadastroPC.aspx")
        End If

        If lblErro.Visible = True Then
            lblErro.Visible = False
        End If
    End Sub

    Private Sub lbConfirmar_Click(sender As Object, e As System.EventArgs) Handles lbConfirmar.Click
        Try
            Dim pc As New PlanoDeContas
            Dim pcDAO As New PlanoDeContasDAO

            pc.Descricao = txtDescricaoPlanoDeContas.Text

            If IdPlano <> 0 Then
                pc.Id = IdPlano
                If PageMode = Modo.DELETE Then
                    pcDAO.DeletePlanoDeContas(IdPlano)
                ElseIf PageMode = Modo.EDIT Then
                    pcDAO.UpdatePlanoDeContas(pc)
                End If
            Else
                pcDAO.CreatePlanoDeContas(pc)
            End If
        Catch ex As Exception
            'Log
        End Try

        Response.Redirect("~/Cadastros/CadastroPC.aspx")
    End Sub

    Private Sub lbVoltar_Click(sender As Object, e As System.EventArgs) Handles lbVoltar.Click
        mvPlanoDecontas.ActiveViewIndex = 1
    End Sub

    Private Sub gvPlanoDeContas_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPlanoDeContas.RowCommand
        If e.CommandName = "mostrarDetalhes" Then
            IdPlano = Integer.Parse(e.CommandArgument)
            Dim queryID As String = "?id=" & IdPlano
            Response.Redirect("~/Cadastros/CadastroPC.aspx" & queryID)
        End If
    End Sub

#End Region

#Region "Methods"

    Private Sub listarPlanos()
        Dim pcDAO As New PlanoDeContasDAO
        Dim listPC As New List(Of PlanoDeContas)

        listPC = pcDAO.ListPlanos()

        gvPlanoDeContas.DataSource = listPC
        gvPlanoDeContas.DataBind()
    End Sub

    Public Sub setActiveView(ByVal index As Integer)
        mvPlanoDecontas.ActiveViewIndex = index
        If PageMode = Modo.DELETE Then
            If Request.QueryString("id") IsNot Nothing Then
                Dim pcDAO As New PlanoDeContasDAO
                IdPlano = Integer.Parse(Request.QueryString("id"))

                If IdPlano > 0 Then
                    Dim pc As PlanoDeContas = pcDAO.RetrievePlanoDeContas(IdPlano)
                    lblConfirmText.Text = "Confirma a exclusão do Plano de Contas: <b>" & pc.Descricao & "</b> ?"
                End If
            End If
        End If
    End Sub

    Public Sub setVisibleButtons(ByVal v As Boolean)
        lbSalvar.Visible = v
        lbCancelar.Visible = v
        txtDescricaoPlanoDeContas.Enabled = True
    End Sub

#End Region

End Class