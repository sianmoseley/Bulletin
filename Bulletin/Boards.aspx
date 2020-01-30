<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Boards.aspx.cs" Inherits="Bulletin.Boards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="boardsPlaceHolder" runat="server">

    <div class="container">
        <div class="lastlogin">
        <table style="width: 100%;">
            <tr>
                <td style="width: 160px"><asp:Label ID="LastLogin" runat="server" Text="You last logged in on:" Font-Bold="True"></asp:Label></td>
                <td><asp:Label ID="LastLoginLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
      </div>
    </div>

    <div class="container">
        <div class="createboard">
        <table style="width: 100%;">
            <tr>
                <td style="width: 136px; height: 42px;" class="modal-sm"><asp:Label ID="Label1" runat="server" Text="Create a New Board:"></asp:Label></td>
                <td style="width: 168px; height: 42px;"><asp:TextBox ID="CreateBoardTextBox" runat="server" Width="161px"></asp:TextBox></td>
                <td><asp:Button ID="CreateBoardButton" runat="server" Text="Create Board" OnClick="CreateBoardButton_Click" class="btn btn-success"/></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 136px">&nbsp;</td>
                <td><asp:Label ID="CreateNewBoardLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
       </div>
    </div>
</asp:Content>
