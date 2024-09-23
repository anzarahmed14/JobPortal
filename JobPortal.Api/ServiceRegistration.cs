using System.Reflection;

namespace JobPortal.Api
{
    public static class ServiceRegistration
    {
        //public static void AddScopedServices(IServiceCollection services)
        //{
        //    var assembly = Assembly.GetExecutingAssembly(); // Change this to the appropriate assembly where your services are located
        //    var serviceTypes = assembly.GetTypes()
        //        .Where(type => type.IsInterface && (type.Name.EndsWith("Service") || type.Name.EndsWith("Repository")));

        //    foreach (var serviceType in serviceTypes)
        //    {
        //        var implementationType = assembly.GetTypes()
        //            .FirstOrDefault(type => type.Name == serviceType.Name.Substring(1));

        //        if (implementationType != null)
        //        {
        //            services.AddScoped(serviceType, implementationType);
        //        }
        //    }
        //}

    }
}
