using Autofac;
using Autofac.Extensions.DependencyInjection;
using CodersLinkProjectTest;
using Domain.IManager;
using Domain.IRepository;
using Domain.Manager;
using Domain.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(
    new MyApplicationModule()
    ));


// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Users",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
