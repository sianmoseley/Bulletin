<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardPost.aspx.cs" Inherits="Bulletin.BoardPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="boardPostPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="boardPostPlaceHolder2" runat="server">
    <div class="container">
        <div class="newpostcreator">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 108px">Add new post:</td>
                    <td style="width: 303px" class="modal-sm">
    <asp:TextBox ID="NewPostTextBox" runat="server" Height="25px" Width="293px"></asp:TextBox></td>
                    <td><asp:Button ID="NewPostButton" runat="server" Text="Add New Post" OnClick="NewPostButton_Click" class="btn btn-success btn-sm" />
    <asp:Label ID="NewPostLabel" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div></div>
    <br />
</asp:Content>
