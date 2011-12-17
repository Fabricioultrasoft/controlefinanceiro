<%@ Page Title="Contas a Pagar" 
Language="vb" 
AutoEventWireup="false" 
MasterPageFile="~/Layout/Contas.master" 
CodeBehind="ContasAPagar.aspx.vb" 
Inherits="FinanceApp.ContasAPagar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAcoes" runat="server">
    <asp:LinkButton ID="lbNovaContaAPagar" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Nova Conta a Pagar</asp:LinkButton>
    <asp:LinkButton ID="lbEditarContaAPagar" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Editar Conta a Pagar</asp:LinkButton>
    <asp:LinkButton ID="lbExcluirContaAPagar" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Excluir Conta a Pagar</asp:LinkButton>
    <asp:LinkButton ID="lbRecuperarContaAPagar" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Recuperar Conta a Pagar</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    body
</asp:Content>
