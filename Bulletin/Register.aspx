<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Bulletin.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="registerPlaceHolder" runat="server">
    <div class="container">
        <div class="register">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 134px; height: 35px;">Name:</td>
                    <td style="height: 35px">
                        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                        <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px; height: 35px;">Username:</td>
                    <td style="height: 35px">
                        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
                        <asp:Label ID="UsernameLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px; height: 35px;">Password:</td>
                    <td>
                        <asp:TextBox ID="Pass1TextBox" runat="server"></asp:TextBox>
                        <asp:Label ID="Pass1Label" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px; height: 35px;">Retype password:</td>
                    <td>
                        <asp:TextBox ID="Pass2TextBox" runat="server"></asp:TextBox>
                        <asp:Label ID="Pass2Label" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 134px; height: 35px;">
                        <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" class="btn btn-success" />
                    </td>
                    <td>
                        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
