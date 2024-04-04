
using Finance.Expensia.Core;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared;
using Finance.Expensia.Web.Extensions.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterShared(builder.Host, builder.Configuration);
builder.Services.AddControllersWithViews();
builder.AddController();
builder.AddFluentValidation();
builder.AddHealthCheck();
builder.AddCors();
builder.Services.RegisterDataAccess(builder.Configuration);
builder.Services.RegisterCore(builder.Configuration);
builder.AddUserManagement();

var app = builder.Build();

app.UseDbContext<ApplicationDbContext>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Account}/{controller=Login}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
