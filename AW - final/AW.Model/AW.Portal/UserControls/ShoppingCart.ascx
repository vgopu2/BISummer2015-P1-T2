<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.ascx.cs" Inherits="AW.Portal.UserControls.ShoppingCart" %>
 

 <asp:gridview runat="server" ID="Gv1" AutoGenerateColumns="true" HeaderStyle-BackColor="Red" BackColor="LightBlue"
    BorderWidth="5" BorderColor="Blue">
   </asp:gridview>
<asp:Label ID="lbl_GrandTotal" runat="server" Text=""></asp:Label>

