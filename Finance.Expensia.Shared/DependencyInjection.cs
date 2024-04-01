using Finance.Expensia.Shared.Objects;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using Microsoft.Extensions.Hosting;

namespace Finance.Expensia.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterShared(this IServiceCollection services, IHostBuilder host, IConfiguration configuration)
        {
            var googleCountAppSettings = configuration.GetSection("GoogleCloud");
            var googleServiceAccount = googleCountAppSettings.GetValue<string>("ServiceAccount");
            var googleCloudStorageBucketName = googleCountAppSettings.GetValue<string>("GoogleCloudStorageBucketName");
            var googleProjectId = googleCountAppSettings.GetValue<string>("ProjectId");

            if (!string.IsNullOrEmpty(googleServiceAccount))
            {
                var decodedServiceAccount = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(googleServiceAccount));

                //FirebaseApp.Create(new AppOptions
                //{
                //    Credential = GoogleCredential.FromJson(decodedServiceAccount)
                //});

                //services.Configure<GoogleCloudConfig>(configOp =>
                //{
                //    configOp.GoogleCredentialJson = decodedServiceAccount;
                //    configOp.GoogleCloudStorageBucketName = googleCloudStorageBucketName;
                //});

                var loggerConfig = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithExceptionDetails()
                    .ReadFrom.Configuration(configuration)
                    .WriteTo.Console();

                Log.Logger = loggerConfig.CreateLogger();

                host.UseSerilog();

                services.AddHttpLogging(logging =>
                {
                    logging.LoggingFields = HttpLoggingFields.RequestBody | HttpLoggingFields.ResponseBody | HttpLoggingFields.Duration;
                });
            }

            services.AddScoped<CurrentUserAccessor>();

            return services;
        }
    }
}
