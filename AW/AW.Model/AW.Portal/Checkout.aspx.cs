using AW.BusinessAccessLayer;
using AW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AW.Portal
{
    
    public partial class Checkout : System.Web.UI.Page
    {
      //  public static DateTime Today { get; }
       static int customerid;
       static int shippingid;
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, int> cartItems1 = (Dictionary<int, int>)Session["ShoppingCart"];
            if (cartItems1.Count == 0)
            {
                cart.Visible = false;
            }
            else
            {
                cartempty.Visible = false;
            }

            if (!IsPostBack)
            {
                addressview.Visible = false;
                addressedit.Visible = false;
                btnfindis.Visible = false;
            }
           
        }



        protected void btn_Checkout_Click(object sender, EventArgs e)
        {
            string abc = "";
           // Response.Redirect("Checkout.aspx");
            customerid = Convert.ToInt32(Session["customerid"].ToString());

            EntityManager<ShippingAddress> pcat = new EntityManager<ShippingAddress>();
            ShippingAddress procat = new ShippingAddress();
            procat.CustomerID = customerid;
            List<ShippingAddress> prodcatID = pcat.Search(procat);
            shippingid = prodcatID[0].AddressID;
            if (prodcatID.Count != 0)
            {
                abc = prodcatID[0].AddressLine1;
            }
            if (abc == "")
            {
                addressedit.Visible = true;
            }
            else
            {

               
                addressview.Visible = true;
            }
            btnfindis.Visible = true;
            btn_Checkout.Visible = false;
        }

        protected void btn_AdrEdit_Click(object sender, EventArgs e)
        {
            addressview.Visible = false;
            addressedit.Visible = true;

        }

      

        protected void btnfinalize_Click(object sender, EventArgs e)
        {

           
          
           

            EntityManager<SalesOrderHeader> sodr = new EntityManager<SalesOrderHeader>();
            SalesOrderHeader SalOdr = new SalesOrderHeader();
            SalOdr.OrderDate = DateTime.Today;
            SalOdr.DueDate = DateTime.Today.AddDays(7);
            SalOdr.ShipDate = DateTime.Today.AddDays(3);
            SalOdr.Status = 1;
            SalOdr.CustomerID = customerid;
            SalOdr.ShipToAddressID = shippingid;
            SalOdr.BillToAddressID = shippingid;
            SalOdr.ShipMethod = "CARGO TRANSPORT 5";
            SalOdr.ModifiedDate = DateTime.Today;
            //SalOdr.TotalDue = 2123.213M;

            List<SalesOrderHeader> Salorder = sodr.Insert(SalOdr);

            EntityManager<SalesOrderHeader> sodr1 = new EntityManager<SalesOrderHeader>();
            SalesOrderHeader SalOdr1 = new SalesOrderHeader();
            SalOdr1.CustomerID = customerid;
            List<SalesOrderHeader> Salorder1 = sodr1.Search(SalOdr);

        
            int salesodrid = Salorder1.Max(r => r.SalesOrderID);

            Dictionary<int, int> cartItems2 = (Dictionary<int, int>)Session["ShoppingCart"];

            foreach (KeyValuePair<int, int> productidQty1 in cartItems2)
            {
               int prodid1 = productidQty1.Key;
               int  prodqty1 = productidQty1.Value;


                EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
                ProductListing procat = new ProductListing();
                procat.ProductID = prodid1;
                List<ProductListing> prodcatID = pcat.Search(procat);



                EntityManager<SalesOrderDetail> sodrd = new EntityManager<SalesOrderDetail>();
                SalesOrderDetail SalOdrd = new SalesOrderDetail();
                SalOdrd.SalesOrderID = salesodrid;
                SalOdrd.OrderQty = Convert.ToInt16( prodqty1);
                SalOdrd.ProductID = prodid1;
                SalOdrd.UnitPrice = prodcatID[0].ListPrice;

                List<SalesOrderDetail> Salorderd = sodrd.Insert(SalOdrd);

               // cartItems2.Remove(prodid1);
            }
            cartItems2.Clear();
            Session["ShoppingCart"] = cartItems2;
            

            Response.Redirect("ProductBrowser.aspx");
       
        }
       
    }
      
   
}