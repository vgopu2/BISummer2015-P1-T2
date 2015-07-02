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
    public partial class ProductOrder : System.Web.UI.UserControl
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GetDesc(int ProductDescriptionId)
        {
           
            EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
            ProductListing procat = new ProductListing();
            procat.ProductID = ProductDescriptionId;
            List<ProductListing> prodcatID = pcat.Search(procat);
            lbl_description.Text = prodcatID[0].Description;
            lbl_productname.Text = prodcatID[0].Name;
            lbl_productnumber.Text = prodcatID[0].ProductNumber;
            lbl_color.Text = prodcatID[0].Color;
            lbl_listprice.Text = prodcatID[0].ListPrice.ToString();
            lbl_categoryname.Text = prodcatID[0].CategoryName;
            lbl_modelname.Text = prodcatID[0].ModelName;
            txt_totalprice.Text = prodcatID[0].ListPrice.ToString();
            lbl_productid.Text = prodcatID[0].ProductID.ToString();
            

          

        }

        protected void AddtoCart_Click(object sender, EventArgs e)
        {
            int abcid = Convert.ToInt32(lbl_productid.Text.ToString());
            int qty = Convert.ToInt32(Quantity.SelectedValue);
            decimal abcpri = Convert.ToDecimal(lbl_listprice.Text.ToString());
            //float abc = Convert.ToDecimal
            decimal abctot = qty * abcpri;
            Dictionary<int, int> cartItems = ( Dictionary<int,int>)  Session["ShoppingCart"];
            int Sqty;
            if (cartItems.TryGetValue(abcid, out Sqty))
            {

               // cartItems.Remove(abcid);

                //Sqty = Sqty + qty;
                cartItems[abcid]  += ( Sqty);
            }
            else
            {

                cartItems.Add(abcid, qty);
            }
            Session["ShoppingCart"] = cartItems;
            Response.Redirect("ProductBrowser.aspx");
        }
        //protected void BtnSubmit_Click(object sender, EventArgs e)
        //{

        //}
       

       
    }
}