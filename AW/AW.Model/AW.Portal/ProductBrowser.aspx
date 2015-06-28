<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="ProductBrowser.aspx.cs" Inherits="AW.Portal.ProductBrowser" %>

<%@ Register Src="~/UserControls/ProductDescription.ascx" TagPrefix="uc1" TagName="ProductDescription" %>













<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div id="dialog" style="display: none">
      
</div>
    <uc1:ProductDescription runat="server" id="ProductDescri" />
   
    <table>
        <tr>
            <td style="vertical-align: top">
                <asp:Label ID="lbl_ModelName" runat="server" Text="Model Name"></asp:Label>
                <asp:TextBox ID="txt_ModelName" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label><asp:TextBox ID="txt_Category" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ProductName" runat="server" Text="Product Name"></asp:Label>
                <asp:TextBox ID="txt_ProductName" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" />
                <br />
                <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>
                <br />


            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:GridView ID="gv_Product" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gv_Product_SelectedIndexChanging"></asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
