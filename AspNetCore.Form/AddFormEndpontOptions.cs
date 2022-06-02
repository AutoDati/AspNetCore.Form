using System.Reflection;

namespace AspNetCore.Form
{
    public class AddFormEndpontOptions
    {
        public AddFormEndpontOptions(Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }

        public Assembly[] Assemblies { get; set; }
    }
}
