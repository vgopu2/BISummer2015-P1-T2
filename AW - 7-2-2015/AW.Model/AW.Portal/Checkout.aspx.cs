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

        }
    }
}