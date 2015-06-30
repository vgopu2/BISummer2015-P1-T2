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
            if (!Page.IsPostBack)
            {
                EntityManager<Product> mgrProduct = new EntityManager<Product>();
                List<Product> product = mgrProduct.GetAll();

                gv_Product.DataSource = product;
                gv_Product.DataBind();
            }
            else
            {
                //if (hdnOrderPopupVisibleYN.Value == "Y")
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1();", true);
                //}
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

        protected void gv_Product_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "select")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ucProductDescri.GetDesc(id);
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

            }  

            else if (e.CommandName == "order")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ucProductOrder.GetDescOrder(id);
                //hdnOrderPopupVisibleYN.Value = "Y";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1();", true);
            }
        }



    }
}