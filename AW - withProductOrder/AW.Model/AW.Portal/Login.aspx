<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AW.Portal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="aw_login" runat="server" OnAuthenticate="aw_login_Authenticate"></asp:Login>
</asp:Content>
