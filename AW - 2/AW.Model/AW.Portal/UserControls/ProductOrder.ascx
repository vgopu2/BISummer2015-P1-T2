<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductOrder.ascx.cs" Inherits="AW.Portal.UserControls.ProductOrder" %>

<table style="width: 100%" border="1">
    <tr>
        <td>Product Name</td>
        <td>
            <asp:Label ID="lbl_productname" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Product Number</td>
        <td>
            <asp:Label ID="lbl_productnumber" runat="server" Text=""></asp:Label></td>
    </tr>

    <tr>
        <td>Description</td>
        <td>
            <asp:Label ID="lbl_description" runat="server" Text=""></asp:Label></td>
    </tr>

    <tr>
        <td>Color</td>
        <td>
            <asp:Label ID="lbl_color" runat="server" Text=""></asp:Label></td>
    </tr>

    <tr>
        <td>List Price</td>
        <td>
            <asp:Label ID="lbl_listprice" runat="server" Text=""></asp:Label></td>
    </tr>

    <tr>
        <td>Category Name</td>
        <td>
            <asp:Label ID="lbl_categoryname" runat="server" Text=""></asp:Label></td>
    </tr>

    <tr>
        <td>Model Name</td>
        <td>
            <asp:Label ID="lbl_modelname" runat="server" Text=""></asp:Label>
 <asp:TextBox ID="txtTotalPrice" runat="server"></asp:TextBox>
        </td>
       
    </tr>

    <tr>
        <td>Quantity</td>
        <td>

            <asp:DropDownList ID="ddlquantity" runat="server"  >
                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>               
            </asp:DropDownList>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
        </td>
    </tr>
</table>
 
