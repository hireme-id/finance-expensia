using Finance.Expensia.DataAccess;
using Finance.Expensia.Web.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Finance.Expensia.Web.Extensions.StartupExtensions
{
	public static class WebApplicationBuilderExtensions
	{
		public static WebApplicationBuilder AddController(this WebApplicationBuilder builder)
		{
			builder.Services.AddAntiforgery(options =>
			{
				options.SuppressXFrameOptionsHeader = true;
			});

			builder.Services.AddControllersWithViews(
				options =>
				{
					options.Filters.Add<AuthorizationFilter>();
					options.Filters.Add<TransactionFilter<ApplicationDbContext>>();
				})
			.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			return builder;
		}

		public static WebApplicationBuilder AddFluentValidation(this WebApplicationBuilder builder)
		{
			// Register all validator to the service container
			var validators = Assembly.GetExecutingAssembly()
									 .GetTypes()
									 .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IValidator).IsAssignableFrom(x))
									 .ToList();

			foreach (var validator in validators)
			{
				var baseType = validator.BaseType;
				var genericArgsBaseType = baseType?.GetGenericArguments().FirstOrDefault();

				if (genericArgsBaseType != null)
				{
					var genericValidatorType = typeof(IValidator<>).MakeGenericType(genericArgsBaseType);
					builder.Services.AddScoped(genericValidatorType, validator);
				}
			}

			// Run validation using fluentvalidation every request in controller
			builder.Services.AddFluentValidationAutoValidation();

			return builder;
		}

		public static WebApplicationBuilder AddHealthCheck(this WebApplicationBuilder builder)
		{
			builder.Services.AddHealthChecks();

			return builder;
		}

		public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
		{
			var allowedHosts = builder.Configuration.GetValue<string>("AllowedHosts") ?? "*";

			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			return builder;
		}

		public static WebApplicationBuilder AddUserManagement(this WebApplicationBuilder builder)
		{
			var securityConfig = builder.Configuration.GetSection("SecurityConfig");

			builder.Services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = securityConfig.GetValue<string>("Issuer"),
						ValidAudience = securityConfig.GetValue<string>("Audience"),
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityConfig.GetValue<string>("SecretKey") ?? string.Empty)),
						ClockSkew = TimeSpan.Zero
					};
				});

			builder.Services.AddAuthorization();

			return builder;
		}
	}
}
