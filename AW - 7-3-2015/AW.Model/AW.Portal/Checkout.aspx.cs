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
        protected void Page_Load(object sender, EventArgs e)
        {
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
            int customerid = Convert.ToInt32(Session["customerid"].ToString());

            EntityManager<ShippingAddress> pcat = new EntityManager<ShippingAddress>();
            ShippingAddress procat = new ShippingAddress();
            procat.CustomerID = customerid;
            List<ShippingAddress> prodcatID = pcat.Search(procat);
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

            Dictionary<int, int> cartItems1 = (Dictionary<int, int>)Session["ShoppingCart"];
            int prodid1;
            int prodqty1;
          
           
            foreach (KeyValuePair<int, int> productidQty in cartItems1)
            {
                prodid1 = productidQty.Key;
                prodqty1 = productidQty.Value;


                EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
                ProductListing procat = new ProductListing();
                procat.ProductID = prodid1;
                List<ProductListing> prodcatID = pcat.Search(procat);


                
            }
           

           // ShoppingCrt.
            //EntityManager<ShippingAddress> pcat = new EntityManager<ShippingAddress>();
            //ShippingAddress procat = new ShippingAddress();
            //procat.CustomerID = 10;
            //procat.AddressLine1 = "sdfag";

            //List<ShippingAddress> prodcatID = pcat.Insert(procat);
        }
    }
}