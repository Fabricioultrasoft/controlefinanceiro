<%@ Control 
Language="vb" 
AutoEventWireup="false" 
CodeBehind="uc_CadastroPC.ascx.vb" 
Inherits="FinanceApp.uc_CadastroPC" %>

<link href="../Layout/Controls.css" type="text/css" rel="Stylesheet" />

<asp:MultiView ID="mvPlanoDecontas" runat="server">
    <%--View de Listagem--%>
    <asp:View ID="viewListagem" runat="server">
        <asp:GridView ID="gvPlanoDeContas" runat="server" AutoGenerateColumns="false">
        </asp:GridView>
    </asp:View>

    <%--View de Cadastro--%>
    <asp:View ID="viewCadastro" runat="server">
        <br />
        <label>Descrição:</label>
        <br />
        <asp:TextBox ID="txtDescricaoPlanoDeContas" runat="server" MaxLength="200">dgfdgdf</asp:TextBox>
        <br />
        <asp:LinkButton ID="lbSalvar" Text="Salvar" runat="server" CssClass="BTN SALVAR" Font-Underline="false"></asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" Text="Cancelar" runat="server" CssClass="BTN CANCELAR" Font-Underline="false"></asp:LinkButton>
    </asp:View>

    <%--View de Confirmação--%>
    <asp:View ID="viewConfirmacao" runat="server">
        <h4>Confirmação</h4>
        <br />
        <p>Confirma a inclusão do plano de contas?</p>
        <br />
        <asp:LinkButton ID="lbConfirmar" runat="server">Confirmar</asp:LinkButton>
        <asp:LinkButton ID="lbVoltar" runat="server">Cancelar</asp:LinkButton>
    </asp:View>
</asp:MultiView>
