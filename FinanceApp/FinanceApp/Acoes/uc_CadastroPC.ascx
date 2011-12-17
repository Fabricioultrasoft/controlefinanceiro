<%@ Control 
Language="vb" 
AutoEventWireup="false" 
CodeBehind="uc_CadastroPC.ascx.vb" 
Inherits="FinanceApp.uc_CadastroPC" %>

<link href="../Layout/Controls.css" type="text/css" rel="Stylesheet" />

<asp:Panel ID="pnlTitulo" runat="server" CssClass="panelTitulo">    
    <asp:Label ID="lblTitulo" runat="server" CssClass="Titulo">Cadastro de Plano de Contas</asp:Label>
    <br />
    <asp:Label ID="lblSubTitulo" runat="server" CssClass="SubTitulo">Clique em um plano de contas para ver os detalhes.</asp:Label>   
</asp:Panel>

<asp:MultiView ID="mvPlanoDecontas" runat="server">
    <%--View de Listagem--%>
    <asp:View ID="viewListagem" runat="server">
        <asp:GridView ID="gvPlanoDeContas" runat="server" AutoGenerateColumns="false" CssClass="grid">
            <AlternatingRowStyle BackColor="GhostWhite" />
            <HeaderStyle CssClass="gridHeader" ForeColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="gridColumn" />
                    <ItemStyle CssClass="gridCell" />
                    <HeaderTemplate><label>Planos de Contas</label></HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkPlano" runat="server" CommandArgument='<%#Eval("Id") %>'
                         Text='<%#Eval("Descricao") %>' CommandName="mostrarDetalhes" ForeColor="Black" Font-Underline="false"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>

    <%--View de Cadastro--%>
    <asp:View ID="viewCadastro" runat="server">
        <div class="Container">
            <label>Descrição:</label>
            <br />
            <asp:TextBox ID="txtDescricaoPlanoDeContas" runat="server" MaxLength="200"></asp:TextBox>
            <asp:LinkButton ID="lbSalvar" Text="Salvar" runat="server" ForeColor="White" CssClass="BTN SALVAR" Font-Underline="false"></asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" Text="Cancelar" runat="server" ForeColor="White" CssClass="BTN CANCELAR" Font-Underline="false"></asp:LinkButton>
            <br />
            <asp:Label ID="lblErro" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </asp:View>

    <%--View de Confirmação--%>
    <asp:View ID="viewConfirmacao" runat="server">
        <div class="Container">
            <label class="TituloContainer">Confirmação</label>
            <br />
            <asp:Label ID="lblConfirmText" runat="server"></asp:Label>
            <br />
            <asp:LinkButton ID="lbConfirmar" runat="server" CssClass="BTN SALVAR" ForeColor="White" Font-Underline="false">Confirmar</asp:LinkButton>
            <asp:LinkButton ID="lbVoltar" runat="server" CssClass="BTN CANCELAR" ForeColor="White" Font-Underline="false">Cancelar</asp:LinkButton>
        </div>
    </asp:View>
</asp:MultiView>
