using AW.BusinessAccessLayer;
using AW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AW.Portal.UserControls
{
    public partial class ShoppingCart : System.Web.UI.UserControl
    {
        DataTable tb = new DataTable();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                createtable();

                Dictionary<int, int> cartItems = (Dictionary<int, int>)Session["ShoppingCart"];
                int prodid;
                int prodqty;
                decimal grandtotal = 0;
                // List<cartitem> crtitem = new List<cartitem>();

                foreach (KeyValuePair<int, int> productidQty in cartItems)
                {
                    prodid = productidQty.Key;
                    prodqty = productidQty.Value;


                    EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
                    ProductListing procat = new ProductListing();
                    procat.ProductID = prodid;
                    List<ProductListing> prodcatID = pcat.Search(procat);



                    int ID = prodid;
                    string Name = prodcatID[0].Name;
                    string ProductNumber = prodcatID[0].ProductNumber;
                    string Description = prodcatID[0].Description;
                    string Color = prodcatID[0].Color;
                    decimal ListPrice = prodcatID[0].ListPrice;
                    string CategoryName = prodcatID[0].CategoryName;
                    string ModelName = prodcatID[0].ModelName;
                    int Quantity = prodqty;
                    decimal Totalprice = prodqty * prodcatID[0].ListPrice;
                    grandtotal = grandtotal + Totalprice;

                    tb = (DataTable)ViewState["table1"];
                    dr = tb.NewRow();
                    dr["Product Name"] = Name;
                    dr["Number"] = ProductNumber;
                    dr["Description"] = Description;
                    dr["color"] = Color;

                    dr["List Price"] = ListPrice;
                    dr["Category Name"] = CategoryName;
                    dr["Model Name"] = ModelName;


                    dr["Quantity"] = Quantity;
                    dr["Total Price"] = Totalprice;
                    tb.Rows.Add(dr);
                    Gv1.DataSource = tb;
                    Gv1.DataBind();


                }

                lbl_GrandTotal.Text = "Grand Total of your cart Items =" + grandtotal.ToString();
            }
        }
        public void createtable()
        {

            tb.Columns.Add("Product Name", typeof(string));
            tb.Columns.Add("Number", typeof(string));
            tb.Columns.Add("Description", typeof(string));
            tb.Columns.Add("color", typeof(string));
            tb.Columns.Add("List Price", typeof(string));
            tb.Columns.Add("Category Name", typeof(string));
            tb.Columns.Add("Model Name", typeof(string));
            tb.Columns.Add("Quantity", typeof(string));
            tb.Columns.Add("Total Price", typeof(string));
           
        
            Gv1.DataSource = tb;
            Gv1.DataBind();
            ViewState["table1"] = tb;
        }

       
    }
    //public class cartitem
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string ProductNumber { get; set; }
    //    public string Description { get; set; }
    //    public string Color { get; set; }
    //    public decimal ListPrice { get; set; }
    //    public string CategoryName { get; set; }
    //    public string ModelName { get; set; }
    //    public int Quantity { get; set; }
    //    public decimal Totalprice { get; set; }

    //}

}