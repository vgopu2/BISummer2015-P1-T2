﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace AW.BusinessAccessLayer
{
    public abstract class TypeManager<T>
    {
        Type _entityType;
        PropertyInfo[] _propertyInfos;
        protected string _typeName;


        public TypeManager()
        {
            _entityType = typeof(T);
            _typeName = _entityType.Name;
            _propertyInfos = _entityType.GetProperties();
        }

        protected T GetInstance()
        {
            return (T)Activator.CreateInstance(_entityType);
        }

        protected bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }
        protected string MakeWhereClause(T filterEntity)
        {
            StringBuilder whereClause = new StringBuilder();
            //List<String> ls = new List<string>();
            //String.Join(" AND ", ls.ToArray());
            whereClause.Append(" where 1=1 ");
            const string FILTER_FORMAT_STR = " AND {0} = '{1}'";
            const string FILTER_FORMAT_NUM = " AND {0} = {1}";

            foreach (PropertyInfo pi in _propertyInfos)
            {


                object value = _entityType.GetProperty(pi.Name).GetValue(filterEntity, null);
                if (value != null && !String.IsNullOrEmpty(value.ToString()))
                {
                    if (IsNumericType(pi.PropertyType) )
                    {
                        if (value.ToString() != "0")
                        {
                            whereClause.Append(String.Format(FILTER_FORMAT_NUM, pi.Name, value.ToString()));
                        }
                    }
                    else
                    {
                        if ( value.ToString() != "1/1/0001 12:00:00 AM" &&  value.ToString() != "00000000-0000-0000-0000-000000000000")
                        whereClause.Append(String.Format(FILTER_FORMAT_STR, pi.Name, value.ToString()));
                    }
                }
            }

            return whereClause.ToString();
        }
        protected List<T> BindEntity(DataTable dt)
        {

            List<T> entities = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                dynamic entity = GetInstance();
                foreach (DataColumn dc in dt.Columns)
                {
                    string propertyName = dc.ColumnName;
                    //if (propertyName.Equals(string.Concat(_typeName, "ID")))
                    //{
                    //    propertyName = "ID";
                    //}
                   // class have this static property name stored in _pair.Key 
                    if (dr[dc] != null && dr[dc] != System.DBNull.Value)
                    {
                        _entityType.GetProperty(propertyName).SetValue(entity, dr[dc], null);
                    }
                }
                entities.Add(entity);
            }
            return entities;
        }
    }
}