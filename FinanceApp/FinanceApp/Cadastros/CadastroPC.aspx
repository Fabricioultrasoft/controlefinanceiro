<%@ Page Title="Planos de Contas" 
Language="vb" 
AutoEventWireup="false" 
MasterPageFile="~/Layout/Cadastro.master" 
CodeBehind="CadastroPC.aspx.vb" 
Inherits="FinanceApp.CadastroPC" %>

<%@ Register Src="~/Acoes/uc_CadastroPC.ascx" TagName="ucCadastroPC" TagPrefix="uc1" %>

<asp:Content ID="bbb" ContentPlaceHolderID="cphAcoes" runat="server">
<ul>
    <li><asp:LinkButton ID="lbNovoPlano" runat="server" Font-Underline="false" ForeColor="Black" CausesValidation="false">Novo Plano</asp:LinkButton></li>
    <li><asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="false" ForeColor="Black" CausesValidation="false">Edit Plano</asp:LinkButton></li>
    <li><asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="false" ForeColor="Black" CausesValidation="false">Excluir Plano</asp:LinkButton></li>
</ul>
</asp:Content>

<asp:Content ID="aaa" ContentPlaceHolderID="cphBody" runat="server">
    <uc1:ucCadastroPC ID="cadastroPC" runat="server" />
</asp:Content>

