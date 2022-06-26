using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Form
{

    [AttributeUsage(AttributeTargets.Property)]
    public class FromPropertyAttribute : Attribute
    {
        public IEnumerable<Attribute> SourceAttributes { get; private set; } = new List<Attribute>();
        public FromPropertyAttribute(Type type, string property)
        {
            var prop = type.GetProperties().FirstOrDefault(p => p.Name == property);
            if (prop != null)
                SourceAttributes = prop.GetCustomAttributes();
        }
    }
}
