<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductOrder.ascx.cs" Inherits="AW.Portal.UserControls.ProductOrder" %>



<table style="width:100%"  border="1">
     <tr>
    <td>Product ID</td>
     <td><asp:Label ID="lbl_productid" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Product Name</td>
     <td><asp:Label ID="lbl_productname" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Product Number</td>
     <td><asp:Label ID="lbl_productnumber" runat="server" Text=""></asp:Label></td>
  </tr>
     <tr>
    <td>Description</td>
    <td><asp:Label ID="lbl_description" runat="server" Text=""></asp:Label></td>
  </tr>
      <tr>
    <td>Color</td>
     <td><asp:Label ID="lbl_color" runat="server" Text=""></asp:Label></td>
  </tr>
    <tr>
    <td>List Price</td>
     <td><%--<asp:Label ID="lbl_listprice" runat="server" Text=""></asp:Label>--%>
         <asp:TextBox ID="lbl_listprice" runat="server" ReadOnly="true" Text=""></asp:TextBox>
         
     </td>
  </tr>
    <tr>
    <td>Category Name</td>
     <td><asp:Label ID="lbl_categoryname" runat="server" Text=""></asp:Label></td>
  </tr>
     <tr>
    <td>ModelName</td>
     <td><asp:Label ID="lbl_modelname" runat="server" Text=""></asp:Label></td>
  </tr>
     <tr>
    <td>Quantity</td>
     <td> <asp:DropDownList id="Quantity" runat="server">

   <asp:ListItem value="1" >1</asp:ListItem>
         <asp:ListItem value="2" >2</asp:ListItem>
         <asp:ListItem value="3" >3</asp:ListItem>
         <asp:ListItem value="4" >4</asp:ListItem>
         <asp:ListItem value="5" >5</asp:ListItem>

</asp:DropDownList></td>
  </tr>
     <tr>
    <td>Total Price</td>
     <td><%--<asp:Label ID="lbl_totalprice" runat="server" Text=""></asp:Label>--%>

          
           <asp:TextBox ID="txt_totalprice" runat="server" ReadOnly="true" Text=""></asp:TextBox>
     </td>
  </tr>
    <tr>
    <td></td>
     <td>

         <asp:Button ID="AddtoCart" runat="server" Text="AddtoCart" OnClick="AddtoCart_Click"  />
          
     </td>
  </tr>

    </table>

<%--Cost Name : <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>
<asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" />--%>


    <script>
        $("#ContentPlaceHolder1_ProductOrderPage_Quantity").change(function () {
          
            var tot = $('#ContentPlaceHolder1_ProductOrderPage_lbl_listprice').val() * this.value;
            $('#ContentPlaceHolder1_ProductOrderPage_txt_totalprice').val(tot);
        });
       

            </script>