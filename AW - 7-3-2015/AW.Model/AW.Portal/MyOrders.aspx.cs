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
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int customerid = Convert.ToInt32(Session["customerid"].ToString());

            EntityManager<Order1> pcat = new EntityManager<Order1>();
            Order1 procat = new Order1();
            procat.CustomerID = customerid;
            List<Order1> prodcatID = pcat.Search(procat);

            gv_Product.DataSource = prodcatID;
            gv_Product.DataBind();

        }
    }
}