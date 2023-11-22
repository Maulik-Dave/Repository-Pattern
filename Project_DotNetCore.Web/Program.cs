using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Project_DotNetCore.Base.Modules.Core.Data;
using Project_DotNetCore.Base.Modules.Core.Helpers;
using Project_DotNetCore.Base.Modules.Core.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//Register health check services
builder.Services.AddHealthChecks()
     .AddCheck("test health check", () => HealthCheckResult.Healthy("Server is healthy"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Custom configurations bind
var config = new AppConfiguration();
builder.Configuration.Bind("DefaultConnectionString", builder.Configuration.GetConnectionString("DefaultConnectionString"));
builder.Configuration.Bind("App", config);
builder.Services.AddSingleton(config);

builder.Services.AddDbContext<SqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("Project_DotNetCore.Base")), ServiceLifetime.Transient);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModuleWeb());
}));

builder.Services.AddAutoMapper(typeof(SqlContext));


var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
