using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EmptyWebAPI.Extension
{
    public class CreateShappedObjectExtension
    {
        public object CreateShappedObject(object obj, List<string> lstFields)
        {
            if (!lstFields.Any())
            {
                return obj;
            }
            else
            {
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in lstFields)
                {
                    var fieldValue = obj.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(obj, null);

                    ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
                }

                return objectToReturn;
            }
        }
    }
}