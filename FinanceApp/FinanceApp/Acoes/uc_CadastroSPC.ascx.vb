Imports FinanceiroDLL.DAO
Imports FinanceiroDLL.Model

Public Class uc_CadastroSPC
    Inherits System.Web.UI.UserControl

    Private Class SubPlanoDeContasHelper
        Private Id_ As Integer
        Private Descricao_ As String
        Private PlanoDescricao_ As String

        Public Property Id() As Integer
            Get
                Return Id_
            End Get
            Set(value As Integer)
                Id_ = value
            End Set
        End Property

        Public Property Descricao() As String
            Get
                Return Descricao_
            End Get
            Set(value As String)
                Descricao_ = value
            End Set
        End Property

        Public Property PlanoDescricao() As String
            Get
                Return PlanoDescricao_
            End Get
            Set(value As String)
                PlanoDescricao_ = value
            End Set
        End Property
    End Class

#Region "Enums"

    Public Enum Modo
        NOVO = 1
        EDIT = 2
        DELETE = 3
    End Enum

#End Region

#Region "Properties"

    Public Property IdSubPlano() As Integer
        Get
            Return ViewState("IdSubPlano")
        End Get
        Set(value As Integer)
            ViewState("IdSubPlano") = value
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

#Region "Events"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Request.QueryString("id") IsNot Nothing Then
                IdSubPlano = Integer.Parse(Request.QueryString("id"))
            End If

            If IdSubPlano <> 0 Then
                Dim spcDAO As New SubPlanoDeContasDAO
                Dim spc As SubPlanoDeContas = spcDAO.RetrieveSubPlanoDeContas(IdSubPlano)

                mvSubPlanoDecontas.ActiveViewIndex = 1
                FillDropDown()

                lbSalvar.Visible = False
                lbCancelar.Visible = False
                txtDescricaoPlanoDeContas.Text = spc.Descricao
                ddlPlanosDeContas.SelectedValue = spc.IdPlano
                txtDescricaoPlanoDeContas.Enabled = False
            Else
                mvSubPlanoDecontas.ActiveViewIndex = 0
                listarSubPlanos()
            End If

        End If
    End Sub

    Private Sub lbSalvar_Click(sender As Object, e As System.EventArgs) Handles lbSalvar.Click
        If Not txtDescricaoPlanoDeContas.Text = "" Then
            If Not ddlPlanosDeContas.SelectedValue = 0 AndAlso ddlPlanosDeContas.SelectedValue IsNot Nothing Then
                mvSubPlanoDecontas.ActiveViewIndex = 2
                lblConfirmText.Text = "Confirma o cadastro do Sub-plano de Contas: <b>" & txtDescricaoPlanoDeContas.Text & "</b>, vinculado com Plano de Contas: <b>" & ddlPlanosDeContas.SelectedItem.Text & "</b> ?"
            Else
                lblErro.Visible = True
                lblErro.Text = "Selecione um plano de contas para vincular!"
            End If
        Else
            lblErro.Visible = True
            lblErro.Text = "Escreva uma descrição para o sub-plano de contas!"
        End If
    End Sub

    Private Sub lbCancelar_Click(sender As Object, e As System.EventArgs) Handles lbCancelar.Click
        txtDescricaoPlanoDeContas.Text = ""
        ddlPlanosDeContas.SelectedValue = 0
        mvSubPlanoDecontas.ActiveViewIndex = 0

        If Request.QueryString("id") IsNot Nothing Then
            Response.Redirect("~/Cadastros/CadastroSPC.aspx")
        End If

        If lblErro.Visible = True Then
            lblErro.Visible = False
        End If
    End Sub

    Private Sub lbConfirmar_Click(sender As Object, e As System.EventArgs) Handles lbConfirmar.Click
        Try
            Dim spc As New SubPlanoDeContas
            Dim spcDAO As New SubPlanoDeContasDAO

            spc.Descricao = txtDescricaoPlanoDeContas.Text
            spc.IdPlano = ddlPlanosDeContas.SelectedValue

            If IdSubPlano <> 0 Then
                spc.Id = IdSubPlano
                If PageMode = Modo.EDIT Then
                    spcDAO.UpdateSubPlanoDeContas(spc)
                ElseIf PageMode = Modo.DELETE Then
                    spcDAO.DeleteSubPlanoDeContas(IdSubPlano)
                End If
            Else
                spcDAO.CreateSubPlanoDeContas(spc)
            End If
        Catch ex As Exception
            '*Log
        End Try

        Response.Redirect("~/Cadastros/CadastroSPC.aspx")
    End Sub

    Private Sub lbVoltar_Click(sender As Object, e As System.EventArgs) Handles lbVoltar.Click
        mvSubPlanoDecontas.ActiveViewIndex = 1
    End Sub

    Private Sub gvSubPlanoDeContas_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvSubPlanoDeContas.RowCommand
        If e.CommandName = "mostrarDetalhes" Then
            IdSubPlano = Integer.Parse(e.CommandArgument)
            Dim queryID As String = "?id=" & IdSubPlano
            Response.Redirect("~/Cadastros/CadastroSPC.aspx" & queryID)
        End If
    End Sub

#End Region

#Region "Methods"

    Private Sub listarSubPlanos()
        Dim spcDAO As New SubPlanoDeContasDAO
        Dim pcDAO As New PlanoDeContasDAO
        Dim listSPC As New List(Of SubPlanoDeContas)
        Dim listHelper As New List(Of SubPlanoDeContasHelper)
        Dim helper As SubPlanoDeContasHelper

        listSPC = spcDAO.ListSubPlanos()

        For Each subPlano As SubPlanoDeContas In listSPC
            helper = New SubPlanoDeContasHelper
            helper.Id = subPlano.Id
            helper.Descricao = subPlano.Descricao
            helper.PlanoDescricao = pcDAO.RetrievePlanoDeContas(subPlano.IdPlano).Descricao

            listHelper.Add(helper)
        Next

        If listHelper IsNot Nothing Or listHelper.Count > 0 Then
            gvSubPlanoDeContas.DataSource = listHelper
            gvSubPlanoDeContas.DataBind()
        End If

    End Sub

    Public Sub setActiveView(ByVal index As Integer)
        mvSubPlanoDecontas.ActiveViewIndex = index
        If PageMode = Modo.DELETE Then
            If Request.QueryString("id") IsNot Nothing Then
                Dim spcDAO As New SubPlanoDeContasDAO
                IdSubPlano = Integer.Parse(Request.QueryString("id"))

                If IdSubPlano > 0 Then
                    Dim subPlano As SubPlanoDeContas = spcDAO.RetrieveSubPlanoDeContas(IdSubPlano)
                    lblConfirmText.Text = "Confirma a exclusão do Sub-plano de Contas: <b>" & subPlano.Descricao & "</b> ?"
                End If
            End If
        ElseIf PageMode = Modo.NOVO Or PageMode = Modo.EDIT Then
            FillDropDown()
        End If
    End Sub

    Public Sub setVisibleButtons(ByVal v As Boolean)
        lbSalvar.Visible = v
        lbCancelar.Visible = v
        txtDescricaoPlanoDeContas.Enabled = True
    End Sub

    Public Sub FillDropDown()
        Dim pcDAO As New PlanoDeContasDAO
        Dim listPC As New List(Of PlanoDeContas)
        listPC = pcDAO.ListPlanos()

        If listPC IsNot Nothing Then

            ddlPlanosDeContas.DataTextField = "Descricao"
            ddlPlanosDeContas.DataValueField = "Id"
            ddlPlanosDeContas.DataSource = listPC
            ddlPlanosDeContas.DataBind()


            Dim listItem As New ListItem
            listItem.Text = "Selecione"
            listItem.Value = 0
            ddlPlanosDeContas.Items.Add(listItem)

            ddlPlanosDeContas.SelectedValue = 0
        End If
    End Sub

#End Region
   
End Class