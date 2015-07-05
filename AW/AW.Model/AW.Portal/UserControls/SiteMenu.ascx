<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMenu.ascx.cs" Inherits="AW.Portal.UserControls.SiteMenu" %>

   <div id="div_afterlogin" runat="server">
<nav>
<a href="ProductBrowser.aspx">Home</a>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
<a href="Checkout.aspx">Cart</a>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
<a href="MyOrders.aspx">Previous Orders</a>  

</nav>
</div>
   <div id="div_beforelogin"  runat="server">
<nav>
<a href="Home.aspx">Home</a> 

</nav>
       </div>