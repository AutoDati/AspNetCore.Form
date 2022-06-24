using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AspNetCore.Form
{
    public static class IServiceCollectionExtensions
    {
        public static void AddFormEndpoint(this IServiceCollection services, params Type[] scanMarkers)
        {

            if (!services.Any(x => x.ServiceType == typeof(AddFormEndpointOptions)))
            {
                services.AddSingleton(new AddFormEndpointOptions(scanMarkers));
            }
            else {
                var existingInstance = services.BuildServiceProvider().GetRequiredService<AddFormEndpointOptions>();
                var temp = existingInstance.Assemblies.ToList();
                temp.AddRange(scanMarkers);
                existingInstance.Assemblies = temp.ToArray();
            }
        }
    }
}
