using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.OutgoingPayment;
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
            services.Configure<GoogleConfig>(options => configuration.Bind(nameof(GoogleConfig), options));

            services.AddScoped<UserService>();
            services.AddScoped<TokenService>();
            services.AddScoped<OutgoingPaymentService>();
            services.AddScoped<GoogleAuthService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<BankAliasService>();

            services.AddHttpClient();

            return services;
        }
    }
}
