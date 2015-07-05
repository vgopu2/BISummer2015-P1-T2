<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cartitems.ascx.cs" Inherits="AW.Portal.UserControls.Cartitems" %>
 <asp:gridview runat="server" ID="Gv1"  HeaderStyle-BackColor="Red" BackColor="LightBlue"
    BorderWidth="5" BorderColor="Blue" OnRowCommand="GridView_RowCommand" AutoGenerateColumns="false" DataKeyNames="ID">


     <Columns>
                       <asp:TemplateField HeaderText=" Actions">
                    <ItemTemplate>
                         <asp:LinkButton ID="btn_order"  CommandName="Remove" CommandArgument='<%# Eval("ID") %>' runat="server" Text="Remove"></asp:LinkButton>
                      
                     
                    </ItemTemplate>
                </asp:TemplateField>
                        
                         <asp:BoundField DataField="ProductNumber" HeaderText="Product" />
                         
                         
                        
         
         <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
          <asp:TextBox ID="editQuantity" runat="server" Width="24px" MaxLength="2"   Text='<%#Eval("Quantity")%>' />
        </ItemTemplate>
      </asp:TemplateField>
          <%--<asp:BoundField DataField="Quantity" HeaderText="Quantity" />--%>
          <asp:BoundField DataField="Totalprice" HeaderText="Totalprice" />
                          
                        
                    </Columns>
   </asp:gridview>
<br /> Total amount: <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
<br />
<asp:Button ID="UpdateCart" runat="server" Text="Update Cart" OnClick="UpdateCart_Click" />
<asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>

<asp:Label ID="lbl_GrandTotal" runat="server" Text=""></asp:Label>
<br />
<a href="../Checkout.aspx">Checkout</a>