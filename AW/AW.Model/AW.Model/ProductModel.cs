using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Model
{
    public class ProductModel
    {
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
