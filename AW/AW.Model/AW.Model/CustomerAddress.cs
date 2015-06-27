using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Model
{
    public class CustomerAddress
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
