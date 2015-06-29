<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="ProductBrowser.aspx.cs" Inherits="AW.Portal.ProductBrowser" %>

<%@ Register Src="~/UserControls/ProductDescription.ascx" TagPrefix="uc1" TagName="ProductDescription" %>
<%@ Register Src="~/UserControls/ProductOrder.ascx" TagPrefix="uc1" TagName="ProductOrder" %>














<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="dialog" style="display: none">
        <uc1:ProductDescription runat="server" ID="ProductDescri" />
    </div>
     <div id="dialogspo" style="display: none">
            <%--<uc1:ProductOrder runat="server" id="ProductOrderPage" />--%>
        </div>
    <div id="div_ProductOrder" runat="server" >
         <uc1:ProductOrder runat="server" id="ProductOrderPage" />

        
        

    
    </div>
<div id="div_ProductBrowser" runat="server" >
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
                <asp:GridView ID="gv_Product" runat="server"  
                   OnRowCommand="GridView_RowCommand" >
                    <Columns>
                       <asp:TemplateField HeaderText=" Grid_Actions">
                    <ItemTemplate>
                         <asp:LinkButton ID="btn_order"  CommandName="Order" CommandArgument='<%# Eval("ProductID") %>' runat="server" Text="Order"></asp:LinkButton>
                       <asp:LinkButton ID="btn_select"  CommandName="Select" CommandArgument='<%# Eval("ProductID") %>' runat="server" Text="Select"></asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
