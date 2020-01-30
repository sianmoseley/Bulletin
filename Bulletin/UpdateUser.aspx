<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Bulletin.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="updateUserPlaceHolder" runat="server">
    <div class="container">
        <div class="updateuser">
            <h1>Update User</h1>
        <table style="width: auto;" class="table">
            <tr>
                <td style="width: 178px; height: 27px;">Name:</td>
                <td style="height: 27px">
                    <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 27px;">Username:</td>
                <td style="height: 30px">
                    <asp:Label ID="UsernameLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height: 27px;">User Type</td>
                <td style="height: 27px">
                    <asp:RadioButtonList ID="RoleRadio" runat="server" AutoPostBack="True" Width="175px" RepeatDirection="Horizontal">
                        <asp:ListItem>ADMIN</asp:ListItem>
                        <asp:ListItem>USER</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 178px; height:100px;">
                    <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" OnClick="DeleteUserButton_Click" class="btn btn-danger"/>
                </td>
                <td>
                    <asp:Button ID="UpdateUserButton" runat="server" Text="Update User" OnClick="UpdateUserButton_Click" class="btn btn-success"/>
                </td>
            </tr>
        </table>
        </div>
     </div>

    
</asp:Content>
