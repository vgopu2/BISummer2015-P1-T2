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
        static decimal gtotal=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["ShoppingCart"]!=null)
                dataload();

            }


        }



        public void dataload()
        {
            Dictionary<int, int> cartItems1 = (Dictionary<int, int>)Session["ShoppingCart"];
            int prodid1;
            int prodqty1;
            int i = 0;
            List<cartitem> abccart = new List<cartitem>();
            foreach (KeyValuePair<int, int> productidQty in cartItems1)
            {
                prodid1 = productidQty.Key;
                prodqty1 = productidQty.Value;


                EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
                ProductListing procat = new ProductListing();
                procat.ProductID = prodid1;
                List<ProductListing> prodcatID = pcat.Search(procat);

                gtotal = gtotal + prodcatID[0].ListPrice;


                cartitem mycart = new cartitem()
                {
                    ID = prodid1,
                    Name = prodcatID[0].Name,
                    ProductNumber = prodcatID[0].ProductNumber,
                    Description = prodcatID[0].Description,
                    Color = prodcatID[0].Color,
                    ListPrice = prodcatID[0].ListPrice,
                    CategoryName = prodcatID[0].CategoryName,
                    ModelName = prodcatID[0].ModelName,
                    Quantity = prodqty1,
                    Totalprice = (prodcatID[0].ListPrice * prodqty1)


                };
               

                abccart.Add(mycart);
            }
            Gv1.DataSource = abccart;
            Gv1.DataBind();
            totalAmountLabel.Text = gtotal.ToString();


        }
        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {

                int rowindex = Convert.ToInt32(e.CommandArgument);
                Dictionary<int, int> cartItems = (Dictionary<int, int>)Session["ShoppingCart"];
                int Sqty;
                if (cartItems.TryGetValue(rowindex, out Sqty))
                {

                    cartItems.Remove(rowindex);
                   
                }
                Session["ShoppingCart"] = cartItems;
                dataload();

            }
        }

        protected void UpdateCart_Click(object sender, EventArgs e)
        {

        
            int rowsCount = Gv1.Rows.Count;
            GridViewRow gridRow;

            TextBox quantityTextBox;
           
            int productId;
            int quantity;
            bool success = true;
            
            for (int i = 0; i < rowsCount; i++)
            {
                // Get a row
                gridRow = Gv1.Rows[i];
                // The ID of the product being deleted
                productId =Convert.ToInt32(Gv1.DataKeys[i].Value.ToString());
                // Get the quantity TextBox in the Row
                quantityTextBox = (TextBox)gridRow.FindControl("editQuantity");
                // Get the quantity, guarding against bogus values
                if (Int32.TryParse(quantityTextBox.Text, out quantity))
                {
                    Dictionary<int, int> cartItems = (Dictionary<int, int>)Session["ShoppingCart"];
                    int Sqty;
                    if (cartItems.TryGetValue(productId, out Sqty))
                    {

                        // cartItems.Remove(abcid);

                        //Sqty = Sqty + qty;
                        cartItems[productId] = (quantity);
                    }
                    Session["ShoppingCart"] = cartItems;
                }
                else
                {
                    // if TryParse didn't succeed
                    success = false;
                }
                // Display status message
                statusLabel.Text = success ?
                  "<br />Your shopping cart was successfully updated!<br />" :
                  "<br />Some quantity updates failed! Please verify your cart!<br />";
               // Dictionary<int, int> cartItems123 = (Dictionary<int, int>)Session["ShoppingCart"];

            }
            // Repopulate the control
           // PopulateControls();
            dataload();
        }
        

    }

    public class cartitem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal ListPrice { get; set; }
        public string CategoryName { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice { get; set; }

    }

}