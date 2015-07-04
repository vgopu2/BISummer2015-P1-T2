using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Model
{
    public class Order1
    {


        public string Name { get; set; }


        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Size { get; set; }
        public int ParentProductCategoryID { get; set; }

        public int SalesOrderID { get; set; }

        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }

        public decimal UnitPrice { get; set; }
        public int CustomerID { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }

    }
}
