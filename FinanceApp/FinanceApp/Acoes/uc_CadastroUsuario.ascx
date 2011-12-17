<%@ Control 
Language="vb" 
AutoEventWireup="false" 
CodeBehind="uc_CadastroUsuario.ascx.vb" 
Inherits="FinanceApp.uc_CadastroUsuario" %>

<link href="../Layout/Controls.css" type="text/css" rel="Stylesheet" />

<asp:Panel ID="pnlTitulo" runat="server" CssClass="panelTitulo">
    <asp:Label ID="lblTitulo" runat="server" CssClass="Titulo">Cadastro de Usuários</asp:Label>
    <br />
    <asp:Label ID="lblSubTitulo" runat="server" CssClass="SubTitulo">Clique em um usuário para ver os detalhes.</asp:Label>
</asp:Panel>

<asp:MultiView ID="mvUsuarios" runat="server">
    <%--View de Listagem--%>
    <asp:View ID="viewListagem" runat="server">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="grid">
            <AlternatingRowStyle BackColor="GhostWhite" />
            <HeaderStyle CssClass="gridHeader" ForeColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="gridColumn" />
                    <ItemStyle CssClass="gridCell" />
                    <HeaderTemplate><label>Usuários</label></HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="linkUsuario" runat="server" CommandArgument='<%#Eval("Id") %>'
                        Text='<%#Eval("Nome") %>' CommandName="mostrarDetalhes" ForeColor="Black" Font-Underline="false"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>

    <%--View de Cadastro--%>
    <asp:View ID="viewCadastro" runat="server">
        <div class="Container">
            <table>
                <tr>
                    <td>
                        <label>Nome:</label>
                        <br />
                        <asp:TextBox ID="txtNome" runat="server" MaxLength="150"></asp:TextBox>
                    </td>
                    <td>
                        <label>Email:</label>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" ToolTip="Preenche somente se quiser receber notificações sobre pagamentos!"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Usuário:</label>
                        <br />
                        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqvUsuario" ControlToValidate="txtUsuario" runat="server" ErrorMessage="Escreva um usuário!">*
                        </asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <label>Senha:</label>
                        <br />
                        <asp:TextBox ID="txtSenha" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqvSenha" ControlToValidate="txtSenha" runat="server" ErrorMessage="Escreva uma senha!">*
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="lbSalvar" Text="Salvar" runat="server" ForeColor="White" CssClass="BTN SALVAR" Font-Underline="false"></asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" Text="Cancelar" runat="server" ForeColor="White" CssClass="BTN CANCELAR" Font-Underline="false"></asp:LinkButton>
            <br />
            <asp:ValidationSummary ID="vsUsuario" runat="server" ShowSummary="true" />
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


