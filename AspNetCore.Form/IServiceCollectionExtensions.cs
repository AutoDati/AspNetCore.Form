using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspNetCore.Form
{
    public static class IServiceCollectionExtensions
    {
        public static void AddFormEndpoint(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddSingleton(new AddFormEndpontOptions(assemblies));
        }
    }
}
