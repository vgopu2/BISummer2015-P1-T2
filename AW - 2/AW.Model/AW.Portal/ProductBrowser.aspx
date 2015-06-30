<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="ProductBrowser.aspx.cs" Inherits="AW.Portal.ProductBrowser" %>

<%@ Register Src="~/UserControls/ProductDescription.ascx" TagPrefix="uc1" TagName="ProductDescription" %>
<%@ Register Src="~/UserControls/ProductOrder.ascx" TagPrefix="uc1" TagName="ProductOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    function ShowPopup() {
        $(function () {
            $("#selectDialog").dialog({
                title: "Product Description", height: 600, width: 600,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };

    function ShowPopup1() {
        $(function () {
            $("#<%= orderDialog.ClientID %>").dialog({
                title: "Product Order", height: 600, width: 600,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };

    $(function() {
        var ddlQty = '#<%= ucProductOrder.ClientID + "_" %>ddlquantity';
        var txtTotal = '#<%= ucProductOrder.ClientID + "_" %>txtTotalPrice';
        var txtListPrice = '#<%= ucProductOrder.ClientID + "_" %>lbl_listprice';
        $(ddlQty).change(
            function () {
                alert($(txtListPrice).html());
                $(txtTotal).val(($(ddlQty).val()) * ($(txtListPrice).html()));

            })
    });
  

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnOrderPopupVisibleYN" Value="N" runat="server" />
    <div id="selectDialog" style="display: none">
        <uc1:ProductDescription runat="server" ID="ucProductDescri" />
    </div>
    <div id="orderDialog" style="display: none"  runat="server">
        <uc1:ProductOrder runat="server" ID="ucProductOrder" />
    </div>

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
                <asp:GridView ID="gv_Product" runat="server" OnRowCommand="gv_Product_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_select" runat="server" CommandName="select" Text="Select" CommandArgument='<%# Eval("ProductID") %>' />
                                <asp:LinkButton ID="btn_order" runat="server" CommandName="order" Text="Order" CommandArgument='<%# Eval("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
