using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AW.BusinessAccessLayer;
using AW.DataAccessLayer;
using AW.Model;
using AW.Portal.UserControls;

namespace AW.Portal
{
    public partial class ProductBrowser : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["customerid"] == null)
                Response.Redirect("Login.aspx");
               


            if (!Page.IsPostBack)
            {
                div_ProductOrder.Visible = false;
                div_ProductBrowser.Visible = true;
            

                EntityManager<Product> mgrProduct = new EntityManager<Product>();
                List<Product> product = mgrProduct.GetAll();

                gv_Product.DataSource = product;
                gv_Product.DataBind();

              
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            int tempProdCatID = 0;
            int tempProModID = 0;

            //// to get product id from product name
            if (txt_Category.Text != "")
            {
                EntityManager<ProductCategory> pcat = new EntityManager<ProductCategory>();
                ProductCategory procat = new ProductCategory();
                procat.Name = txt_Category.Text.ToString();
                List<ProductCategory> prodcatID = pcat.Search(procat);
                tempProdCatID = prodcatID[0].ProductCategoryID;
            }
            //// to get model id from model name
            if (txt_ModelName.Text != "")
            {
                EntityManager<ProductModel> pmod = new EntityManager<ProductModel>();
                ProductModel promod = new ProductModel();
                promod.Name = txt_ModelName.Text.ToString();
                List<ProductModel> prodmodID = pmod.Search(promod);
                tempProModID = prodmodID[0].ProductModelID;
            }
            // assigning the search results
            EntityManager<Product> mgrProduct = new EntityManager<Product>();
            Product product = new Product();


            // product.ProductModelID = tempProModID;
            //product.ProductCategoryID = tempProdCatID;
            // if(txt_ProductName.Text != null)
            //product.Name = txt_ProductName.Text.ToString();
            if (txt_ModelName.Text != "")
                product.ProductModelID = tempProModID;// 127;
            if (txt_Category.Text != "")
                product.ProductCategoryID = tempProdCatID;
            if (txt_ProductName.Text != "")
                product.Name = txt_ProductName.Text.ToString();// "Rear Derailleur";

            List<Product> productlist = mgrProduct.Search(product);

            gv_Product.DataSource = productlist;
            gv_Product.DataBind();


        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                         
                    int rowindex = Convert.ToInt32(e.CommandArgument);
                    ProductOrderPage.GetDesc(rowindex);
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowProductOrder();", true);
                   // div_ProductOrder.Visible = true;
                    //div_ProductBrowser.Visible = false;
            
            }
            else if (e.CommandName == "Select")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                ProductDescri.GetDesc(id);
               
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);


            }

        }

        //protected void gv_Product_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    GridViewRow row = gv_Product.Rows[e.NewSelectedIndex];
        //    int id = Convert.ToInt32(row.Cells[1].Text);
        //    //lbltest.Text = "selected :" + id.ToString();
        //    // ProductDescription.ProductDescriptionabc(10);
        //    // this.ProductDescri.
        //    ProductDescri.GetDesc(id);
        //    // string message = "selected :" + id.ToString();
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

        //}





    }
}