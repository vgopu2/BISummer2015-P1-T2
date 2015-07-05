<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="ProductBrowser.aspx.cs" Inherits="AW.Portal.ProductBrowser" %>

<%@ Register Src="~/UserControls/ProductDescription.ascx" TagPrefix="uc1" TagName="ProductDescription" %>
<%@ Register Src="~/UserControls/ProductOrder.ascx" TagPrefix="uc1" TagName="ProductOrder" %>
<%@ Register Src="~/UserControls/Cartitems.ascx" TagPrefix="uc1" TagName="Cartitems" %>






<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowPopup() {
            $(function () {
                $("#dialog").dialog({
                    title: "Product Description",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
        function ShowProductOrder() {
            $(function () {
                $("#<%= dialogspo.ClientID %>").dialog({
                    title: "Product Order Wizard",
                    width: 900, height: 600,
                    buttons: {
                       // ok : function (){ $("#<%= ProductOrderPage.ClientID %>_AddtoCart").click();},
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true,
                    open: function (type, data) { $(this).parent().appendTo("form"); },
                    close: function (type, data) { ($(this).parent().replaceWith("")); }
                });
            });
        };


        $(function () {

            $('#<%= txt_ModelName.ClientID %>').autocomplete({
                source: function (request, response) {
                $.ajax({
                    url: "Details.asmx/GetModelName",
                    data: "{ 'ModelName': '" + request.term + "' }",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert('There is a problem processing your request');
                    }
                });
                },
                minLength: 0
            });
        });


        $(function () {

            $('#<%= txt_Category.ClientID %>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Details.asmx/GetCategoryName",
                        data: "{ 'CategoryName': '" + request.term + "' }",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert('There is a problem processing your request');
                        }
                    });
                },
                minLength: 0
            });
        });

        $(function () {

            $('#<%= txt_ProductName.ClientID %>').autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "Details.asmx/GetProductName",
                         data: "{ 'ProductName': '" + request.term + "' }",
                         type: "POST",
                         dataType: "json",
                         contentType: "application/json;charset=utf-8",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert('There is a problem processing your request');
                         }
                     });
                 },
                 minLength: 0
             });
         });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="dialog" style="display: none">
        <uc1:ProductDescription runat="server" ID="ProductDescri" />
    </div>
     <div id="dialogspo" style="display: none" runat="server">
            <uc1:ProductOrder runat="server" id="ProductOrderPage" />
        </div>
    <div id="div_ProductOrder" runat="server" >
        <%-- <uc1:ProductOrder runat="server" id="ProductOrderPage" />--%>

        
        

    
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
                <%--<asp:GridView ID="gv_Product" runat="server"  
                   OnRowCommand="GridView_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                       <asp:TemplateField HeaderText=" Grid_Actions">
                    <ItemTemplate>
                         <asp:LinkButton ID="btn_order"  CommandName="Order" CommandArgument='<%# Eval("ProductID") %>' runat="server" Text="Order"></asp:LinkButton>
                       <asp:LinkButton ID="btn_select"  CommandName="Select" CommandArgument='<%# Eval("ProductID") %>' runat="server" Text="Select"></asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
                         <asp:BoundField DataField="Name" HeaderText="Name" />
                         <asp:BoundField DataField="ProductNumber" HeaderText="ProductNumber" />
                          <asp:BoundField DataField="Color" HeaderText="Color" />
                          <asp:BoundField DataField="ListPrice" HeaderText="ListPrice" />
                          
                        
                    </Columns>
                </asp:GridView>--%>
                 <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" DataKeyField="ProductID" OnItemCommand="DataList1_ItemCommand">    
        <ItemTemplate>
            <table style="border: 1px solid">
                <tr style="height: 120px">
            <td style="vertical-align:top">
                <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="view" >View</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="purchase">Purchase</asp:LinkButton>
                    </td>
                    <td style="width: 250px; vertical-align:top">
                        <table>
                            <tr>
                    <td>
                       <b>Product Name</b> :<asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />       
                    </td>
                </tr>
                <tr>
                    
                    <td >
                        <b>Product Number</b> : <asp:Label ID="lblNumber" runat="server" Text='<%# Eval("ProductNumber") %>' />
                    </td>
                </tr>
                <tr>
                    
                    <td>
                       <b> Color</b> : <asp:Label ID="Label1" runat="server" Text='<%# Eval("Color") %>' />
                </tr>
                <tr>
                    
                    <td >
                       <b> Standard Cost </b>:<asp:Label ID="Label2" runat="server" Text='<%# Eval("StandardCost") %>' />
                    </td>
                    
                </tr>
            </table>
            </td>
                    </tr>
                </table>
        </ItemTemplate>
    </asp:DataList>

            </td>
        </tr>
    </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="cart" runat="server" >
          <uc1:Cartitems runat="server" ID="Cartitems" />
    </div>
  
        </asp:Content>