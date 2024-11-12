using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.DocumentNumbering;
using Finance.Expensia.Core.Services.Employee;
using Finance.Expensia.Core.Services.Inbox;
using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.Core.Services.Rule;
using Finance.Expensia.Core.Services.Storage;
using Finance.Expensia.Core.Services.Workflow;
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
			services.Configure<StorageConfig>(options => configuration.Bind(nameof(StorageConfig), options));

			services.AddScoped<AccessControlService>();
            services.AddScoped<UserManagementService>();
            services.AddScoped<TokenService>();
            services.AddScoped<OutgoingPaymentService>();
            services.AddScoped<GoogleAuthService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<BankAliasService>();
			services.AddScoped<PartnerService>();
			services.AddScoped<CoaService>();
			services.AddScoped<CostCenterService>();
            services.AddScoped<TransactionTypeService>();
			services.AddScoped<StorageService>();
            services.AddScoped<InboxService>();
			services.AddScoped<WorkflowService>();
			services.AddScoped<WorkflowHistoryService>();
            services.AddScoped<DocumentNumberingService>();
            services.AddScoped<ApprovalRuleService>();
            services.AddScoped<TaxService>();
            services.AddScoped<CostComponentService>();
            services.AddScoped<EmployeeService>();

            services.AddHttpClient();

            return services;
        }
    }
}
