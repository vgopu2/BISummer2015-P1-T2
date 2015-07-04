using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AW.Portal
{
    /// <summary>
    /// Summary description for Details
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Details : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetModelName(string ModelName)
        {
            string cs = ConfigurationManager.ConnectionStrings["RentACarIntegratedCS"].ConnectionString;
            List<string> ModelNames = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingProductModelNames", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@ModelName", ModelName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ModelNames.Add(rdr["Name"].ToString());
                }
            }
            return ModelNames;
        }

        [WebMethod]
        public List<string> GetCategoryName(string CategoryName)
        {
            string cs = ConfigurationManager.ConnectionStrings["RentACarIntegratedCS"].ConnectionString;
            List<string> CategoryNames = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingCategoryNames", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@CategoryName", CategoryName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CategoryNames.Add(rdr["Name"].ToString());
                }
            }
            return CategoryNames;
        }

        [WebMethod]
        public List<string> GetProductName(string ProductName)
        {
            string cs = ConfigurationManager.ConnectionStrings["RentACarIntegratedCS"].ConnectionString;
            List<string> ProductNames = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingProductNames", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@ProductName", ProductName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductNames.Add(rdr["Name"].ToString());
                }
            }
            return ProductNames;
        }
    }
}
