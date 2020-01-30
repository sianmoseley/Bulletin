<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Bulletin.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="changePasswordPlaceHolder" runat="server">
    <div class="container">
        <div class="changepassword">
        <table style="width: 100%;">
            <tr>
                <td style="width: 226px; height: 35px;">Old Password:</td>
                <td>
                    <asp:TextBox ID="OldPassTextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="OldPassLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 226px; height: 35px">New Password:</td>
                <td>
                    <asp:TextBox ID="NewPass1TextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="NewPass1Label" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 226px; height: 35px">Type New Password again:</td>
                <td>
                    <asp:TextBox ID="NewPass2TextBox" runat="server"></asp:TextBox>
                    <asp:Label ID="NewPass2Label" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 226px; height: 35px">         
                </td>
                <td><asp:Button ID="ChanePassButton" runat="server" Text="Change Password" OnClick="ChanePassButton_Click" class="btn btn-success" /></td>
            </tr>
      
        </table>
        </div>
    </div>
</asp:Content>
