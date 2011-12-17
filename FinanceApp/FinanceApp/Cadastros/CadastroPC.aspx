<%@ Page Title="Planos de Contas" 
Language="vb" 
AutoEventWireup="false" 
MasterPageFile="~/Layout/Cadastro.master" 
CodeBehind="CadastroPC.aspx.vb" 
Inherits="FinanceApp.CadastroPC" %>

<%@ Register Src="~/Acoes/uc_CadastroPC.ascx" TagName="ucCadastroPC" TagPrefix="uc1" %>

<asp:Content ID="bbb" ContentPlaceHolderID="cphAcoes" runat="server">
    <asp:LinkButton ID="lbNovoPlano" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Novo Plano</asp:LinkButton>
    <asp:LinkButton ID="lbEditPlano" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Editar Plano</asp:LinkButton>
    <asp:LinkButton ID="lbExcluirPlano" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Excluir Plano</asp:LinkButton>
</asp:Content>

<asp:Content ID="aaa" ContentPlaceHolderID="cphBody" runat="server">
    <uc1:ucCadastroPC ID="cadastroPC" runat="server" />
</asp:Content>

