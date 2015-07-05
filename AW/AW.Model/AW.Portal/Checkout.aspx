<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="AW.Portal.Checkout" %>

<%@ Register Src="~/UserControls/ShoppingCart.ascx" TagPrefix="uc1" TagName="ShoppingCart" %>
<%@ Register Src="~/UserControls/UCAddressView.ascx" TagPrefix="uc1" TagName="UCAddressView" %>
<%@ Register Src="~/UserControls/UCAddressEdit.ascx" TagPrefix="uc1" TagName="UCAddressEdit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="cart" runat="server" >
    <uc1:ShoppingCart runat="server" ID="ShoppingCrt" />

    <asp:Button ID="btn_Checkout" runat="server" Text="Check Out" OnClick="btn_Checkout_Click" />

    <div id="addressview" runat="server">
        <uc1:UCAddressView runat="server" id="UCAddrView" />
        <asp:Button ID="btn_AdrEdit" runat="server" Text="Edit Address" OnClick="btn_AdrEdit_Click" />
    </div>
    <div id="addressedit" runat="server">
        <uc1:UCAddressEdit runat="server" id="UCAddrEdit" />
        
    </div>
    <div id="btnfindis" runat="server"><br /><br /><br />
        <asp:Button ID="btnfinalize" runat="server" Text="Finalize Cart" OnClick="btnfinalize_Click" />
        </div>
         </div>
    <div id="cartempty" runat="server" >
        <h1> your cart is empty</h1>
        </div>
</asp:Content>
