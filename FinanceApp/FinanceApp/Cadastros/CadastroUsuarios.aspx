<%@ Page Title="Usuários" 
Language="vb" 
AutoEventWireup="false" 
MasterPageFile="~/Layout/Cadastro.Master" 
CodeBehind="CadastroUsuarios.aspx.vb" 
Inherits="FinanceApp.CadastroUsuarios" %>

<%@ Register Src="~/Acoes/uc_CadastroUsuario.ascx" TagName="ucCadastroUsuario" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphAcoes" runat="server">    
    <asp:LinkButton ID="lbNovoUsuario" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Novo Usuário</asp:LinkButton>
    <asp:LinkButton ID="lbEditUsuario" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Editar Usuário</asp:LinkButton>
    <asp:LinkButton ID="lbExcluirUsuario" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Excluir Usuário</asp:LinkButton>
    <asp:LinkButton ID="lbRecuperarUsuario" runat="server" Font-Underline="false" ForeColor="White" CausesValidation="false">Recuperar Usuário</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
    <uc1:ucCadastroUsuario ID="cadastroUsuario" runat="server" />
</asp:Content>
