using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AW.BusinessAccessLayer;
using AW.DataAccessLayer;
using AW.Model;


namespace AW.Portal
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntityManager<Product> mgrProduct = new EntityManager<Product>();
            List<Product> product = mgrProduct.GetAll();

            GridView1.DataSource = product;
            GridView1.DataBind();
        }
        protected void btnShowPopup_Click(object sender, EventArgs e)
        {
            string message = "Message from server side";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
    }

}