using AW.BusinessAccessLayer;
using AW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AW.Portal.UserControls
{
    public partial class UCAddressView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerid =Convert.ToInt32( Session["customerid"].ToString());

            EntityManager<ShippingAddress> pcat = new EntityManager<ShippingAddress>();
            ShippingAddress procat = new ShippingAddress();
            procat.CustomerID = customerid;
            List<ShippingAddress> prodcatID = pcat.Search(procat);
            if (prodcatID.Count != 0)
            {
                lbl_addrL1.Text = prodcatID[0].AddressLine1;
                lbl_addrL2.Text = prodcatID[0].AddressLine2;
                lbl_city.Text = prodcatID[0].City;
                lbl_state.Text = prodcatID[0].StateProvince;
                lbl_region.Text = prodcatID[0].CountryRegion;
                lbl_postal.Text = prodcatID[0].PostalCode;
            }
        }
    }
}