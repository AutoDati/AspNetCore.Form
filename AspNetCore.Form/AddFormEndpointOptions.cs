using System;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Form
{
    public class AddFormEndpointOptions
    {
        public AddFormEndpointOptions(params Type[] scanMarkers)
        {
            if (Assemblies == null)
                Assemblies = scanMarkers;
            else
            {
                var temp = Assemblies.ToList();
                temp.AddRange(scanMarkers.ToList());
                Assemblies = temp.ToArray();
            }
        }

        public Type[] Assemblies { get; set; }
    }
}
