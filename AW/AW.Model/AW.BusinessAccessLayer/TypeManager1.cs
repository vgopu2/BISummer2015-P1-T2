using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AW.BusinessAccessLayer
{
    public abstract class TypeManager1<T>
    {
        Type _entityType;
        PropertyInfo[] _propertyinfo;
        protected string _typeName;
    }

}
