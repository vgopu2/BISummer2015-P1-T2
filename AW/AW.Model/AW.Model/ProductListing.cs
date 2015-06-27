using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Model
{
    public class ProductListing
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Size { get; set; }

        public decimal Weight { get; set; }

        public int ProductCategoryID { get; set; }

        public int ProductModelID { get; set; }

        public DateTime SellStartDate { get; set; }

        public DateTime SellEndDate { get; set; }

        public DateTime DiscontinuedDate { get; set; }

        public string ThumbnailPhotoFileName { get; set; }

        public string ModelName { get; set; }

        public string CategoryName { get; set; }

        public int ParentProductCategoryID { get; set; }
    }
}
