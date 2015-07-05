using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AW.Portal.UserControls
{
    public partial class SiteMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerid"] == null)
            {
                div_afterlogin.Visible = false;

            }
            else
            {
                div_beforelogin.Visible = false;
            }

        }
        
    }
}