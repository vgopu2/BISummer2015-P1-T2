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
    public partial class ProductDescription : System.Web.UI.UserControl
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
            Label2.Text = prodcatID[0].Description;


            //int id = ProductDescriptionId;
            //Label2.Text = ProductDescriptionId.ToString();
            
        }

       
    }
}