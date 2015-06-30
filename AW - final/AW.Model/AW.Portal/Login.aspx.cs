using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace AW.Portal
{
    public partial class Login : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["RentACarIntegratedCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aw_login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", aw_login.UserName);
            cmd.Parameters.AddWithValue("@password", aw_login.Password);
            con.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            if (value == 1)
            {
                string sqlquery = "select CustomerID from [SalesLT].[Customer] where EmailAddress = '" + aw_login.UserName + "' ";
                SqlCommand cmd1 = new SqlCommand(sqlquery, con);
                int CustomerID = Convert.ToInt32(cmd1.ExecuteScalar());
                Session["customerid"] = CustomerID;

                ////
                Dictionary<int, int> cartItems = new Dictionary<int, int>();
                Session["ShoppingCart"] = cartItems;
                FormsAuthentication.RedirectFromLoginPage(aw_login.UserName, false);
            }
            con.Close();

        }
    }
}