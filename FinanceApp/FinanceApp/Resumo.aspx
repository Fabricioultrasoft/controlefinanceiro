<%@ Page Title="Resumo" 
Language="vb" 
AutoEventWireup="false"
MasterPageFile="~/Layout/Basic.Master"
CodeBehind="Resumo.aspx.vb" Inherits="FinanceApp.Resumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSubmenu" runat="server">
    <ul>
        <li>Resumo<br />Contas</li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBodyContainer" runat="server">
    <div class="body">    
        Hello
    </div>
</asp:Content>
