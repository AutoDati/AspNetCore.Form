using System;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Form
{
    public static class TypeExtensions
    {
        public static T GetAttributeFrom<T>(this Type _, PropertyInfo property) where T : Attribute
        {
            return (T)property.GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }
    }
}
