<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bulletin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="loginPlaceHolder" runat="server">

    <div class="container">
        <table class="login" style="width: 100%;">
            
            <tr>
                <td style="width: 71px; height: 35px;">Username:</td>
                <td style="height: 35px">
                    <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="UserLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 71px; height: 42px;">Password:</td>
                <td style="height: 42px">
                    <asp:TextBox ID="PassTextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="PassLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 71px">
                    <asp:HyperLink ID="RegisterLink" NavigateURL="~/Register.aspx" runat="server">Register</asp:HyperLink>
                </td>
                <td>
                    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" class="btn btn-success" />
                </td>
            </tr>
        </table>
    </div>    
</asp:Content>
