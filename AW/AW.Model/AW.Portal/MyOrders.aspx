<%@ Page Title="" Language="C#" MasterPageFile="~/AW.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="AW.Portal.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:GridView ID="gv_Product" runat="server" AutoGenerateColumns="false"  >
                   <Columns>
                       <asp:BoundField DataField="SalesOrderID" HeaderText="SalesOrderID" />
                       <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Color" HeaderText="Color" />
                        <asp:BoundField DataField="StandardCost" HeaderText="StandardCost" />
                        <asp:BoundField DataField="Size" HeaderText="Size" />
                        <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
                        <asp:BoundField DataField="ShipDate" HeaderText="ShipDate" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />


                      

                   </Columns>
                </asp:GridView>
</asp:Content>
