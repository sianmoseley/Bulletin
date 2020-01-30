<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Bulletin.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="myAccountPlaceHolder" runat="server">
    <div class="container changepassword">
        <asp:HyperLink ID="HyperLink1" NavigateURL="~/ChangePassword" runat="server" class="btn btn-success">Change my password</asp:HyperLink>
    </div>
    <br />
    <div class="container">
        <asp:HyperLink ID="HyperLink2" NavigateURL="~/UserPost" runat="server" class="btn btn-success">View my posts</asp:HyperLink>
    </div>
</asp:Content>
