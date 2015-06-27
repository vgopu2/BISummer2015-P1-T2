using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AW.DataAccessLayer;

namespace AW.BusinessAccessLayer
{
   public class EntityManager<T> : TypeManager<T>
    {
        private string _selQry;
        
       public EntityManager()
        {
            _selQry = GetSelectedQuery();
        }
        protected string GetSelectedQuery()
        {
            string selQry = "";
            if (_typeName == "Customer")
            {
                selQry = "SELECT *  FROM [SalesLT].[Customer]";
            }
            else if (_typeName == "Product")
            {
                selQry = "SELECT *  FROM [SalesLT].[Product]";
            }
            else if (_typeName == "Order")
            {
                selQry = "SELECT *  FROM [SalesLT].[vOrder]";
            }
            else if (_typeName == "ProductDescription")
            {
                selQry = "SELECT *  FROM [SalesLT].[ProductDescription]";
            }
            else if (_typeName == "Address")
            {
                selQry = "SELECT *  FROM [SalesLT].[Address]";
            }
            else if (_typeName == "CustomerAddress")
            {
                selQry = "SELECT *  FROM [SalesLT].[CustomerAddress]";
            }
            else if (_typeName == "ProductCategory")
            {
                selQry = "SELECT *  FROM [SalesLT].[ProductCategory]";
            }
            else if (_typeName == "SalesOrderDetail")
            {
                selQry = "SELECT *  FROM [SalesLT].[SalesOrderDetail]";
            }
            else if (_typeName == "SalesOrderHeader")
            {
                selQry = "SELECT *  FROM [SalesLT].[SalesOrderHeader]";
            }
            else if (_typeName == "ProductListing")
            {
                selQry = "SELECT *  FROM [SalesLT].[vProductListing]";
            }
            return selQry;
        }

        private List<T> ExecuteQry(string whereClause = "")
        {
            List<T> retVal = new List<T>();
            DataSet ds = DALHelper.GetDataset(_selQry + whereClause);
            if (ds != null && ds.Tables.Count > 0)
            {
                retVal = BindEntity(ds.Tables[0]);
            }
            return retVal;
        }

        public List<T> GetAll()
        {
            return ExecuteQry();
        }

        public List<T> Search(T filterEntity)
        {
            string whereClause = MakeWhereClause(filterEntity);
            return ExecuteQry(whereClause);
        }
    }
}
