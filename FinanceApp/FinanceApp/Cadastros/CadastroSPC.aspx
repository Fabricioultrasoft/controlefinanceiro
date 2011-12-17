<%@ Page Title="Sub-planos de Contas" 
Language="vb" 
AutoEventWireup="false" 
MasterPageFile="~/Layout/Cadastro.master" 
CodeBehind="CadastroSPC.aspx.vb" 
Inherits="FinanceApp.CadastroSPC" %>

<%@ Register Src="~/Acoes/uc_CadastroSPC.ascx" TagName="ucCadastroSPC" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAcoes" runat="server">
    <asp:LinkButton ID="lbNovoSP" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Novo Sub-Plano</asp:LinkButton>
    <asp:LinkButton ID="lbEditSP" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Editar Sub-Plano</asp:LinkButton>
    <asp:LinkButton ID="lbExcluirSP" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Excluir Sub-Plano</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <uc1:ucCadastroSPC runat="server" ID="CadastroSPC" />
</asp:Content>
