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

        public void GetDescOrder(int ProductDescriptionId)
        {

            EntityManager<ProductListing> pcat = new EntityManager<ProductListing>();
            ProductListing procat = new ProductListing();
            procat.ProductID = ProductDescriptionId;
            List<ProductListing> prodcatID = pcat.Search(procat);
            lbl_productname.Text = prodcatID[0].Name;
            lbl_productnumber.Text = prodcatID[0].ProductID.ToString();
            lbl_description.Text = prodcatID[0].Description;
            lbl_color.Text = prodcatID[0].Color;
            lbl_listprice.Text = prodcatID[0].ListPrice.ToString();
            lbl_categoryname.Text = prodcatID[0].CategoryName;
            lbl_modelname.Text = prodcatID[0].ModelName;



            //int id = ProductDescriptionId;
            //Label2.Text = ProductDescriptionId.ToString();

        }

        protected void ddlquantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(ddlquantity.SelectedValue);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");

        }

     
    }
}