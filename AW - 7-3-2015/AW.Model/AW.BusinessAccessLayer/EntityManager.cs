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
        private string _insQry;
        
       public EntityManager()
        {
            _selQry = GetSelectedQuery();
            _insQry = GetInsertedQuery();
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
            else if (_typeName == "Order1")
            {
                selQry = "SELECT *  FROM [SalesLT].[vOrder1]";
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
            else if (_typeName == "ProductModel")
            {
                selQry = "SELECT *  FROM [SalesLT].[ProductModel]";
            }
            else if (_typeName == "ShippingAddress")
            {
                selQry = "SELECT *  FROM [SalesLT].[vOfficeAddress]";
            }
            return selQry;
        }
        protected string GetInsertedQuery()
        {
            string insQry = "";
            if (_typeName == "Customer")
            {
                insQry = "INSERT INTO [SalesLT].[Customer]";
            }
            else if (_typeName == "Product")
            {
                insQry = "INSERT INTO [SalesLT].[Product]";
            }
            else if (_typeName == "Order")
            {
                insQry = "INSERT INTO [SalesLT].[vOrder]";
            }
            else if (_typeName == "ProductDescription")
            {
                insQry = "INSERT INTO [SalesLT].[ProductDescription]";
            }
            else if (_typeName == "Address")
            {
                insQry = "INSERT INTO [SalesLT].[Address]";
            }
            else if (_typeName == "CustomerAddress")
            {
                insQry = "INSERT INTO [SalesLT].[CustomerAddress]";
            }
            else if (_typeName == "ProductCategory")
            {
                insQry = "INSERT INTO [SalesLT].[ProductCategory]";
            }
            else if (_typeName == "SalesOrderDetail")
            {
                insQry = "INSERT INTO [SalesLT].[SalesOrderDetail]";
            }
            else if (_typeName == "SalesOrderHeader")
            {
                insQry = "INSERT INTO [SalesLT].[SalesOrderHeader]";
            }
            else if (_typeName == "ProductListing")
            {
                insQry = "INSERT INTO [SalesLT].[vProductListing]";
            }
            else if (_typeName == "ProductModel")
            {
                insQry = "INSERT INTO [SalesLT].[ProductModel]";
            }
            else if (_typeName == "ShippingAddress")
            {
                insQry = "INSERT INTO [SalesLT].[vOfficeAddress]";
            }
            return insQry;
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
        private List<T> ExecuteQryins(string insertClause = "")
        {
            List<T> retVal = new List<T>();
            DataSet ds = DALHelper.GetDataset(_insQry + insertClause);
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
        public List<T> Insert(T filterEntity)
        {
            string insertClause = MakeInsertClause(filterEntity);
            return ExecuteQryins(insertClause);
        }
        public List<T> Search(T filterEntity)
        {
            string whereClause = MakeWhereClause(filterEntity);
            return ExecuteQry(whereClause);
        }
    }
}
