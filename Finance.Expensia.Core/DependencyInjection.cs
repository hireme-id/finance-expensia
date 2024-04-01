using Finance.Expensia.Shared.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finance.Expensia.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<SecurityConfig>(options => configuration.Bind(nameof(SecurityConfig), options));


            return services;
        }
    }
}
