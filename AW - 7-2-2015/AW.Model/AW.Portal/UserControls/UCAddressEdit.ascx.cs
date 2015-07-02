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
    public partial class UCAddressEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerid = Convert.ToInt32(Session["customerid"].ToString());

            EntityManager<ShippingAddress> pcat = new EntityManager<ShippingAddress>();
            ShippingAddress procat = new ShippingAddress();
            procat.CustomerID = customerid;
            List<ShippingAddress> prodcatID = pcat.Search(procat);
            if (prodcatID.Count != 0)
            {
                txt_addrL1.Text = prodcatID[0].AddressLine1;
                txt_addrL2.Text = prodcatID[0].AddressLine2;
                txt_city.Text = prodcatID[0].City;
                txt_state.Text = prodcatID[0].StateProvince;
                txt_region.Text = prodcatID[0].CountryRegion;
                txt_postal.Text = prodcatID[0].PostalCode;
            }
        }
     
    }
}