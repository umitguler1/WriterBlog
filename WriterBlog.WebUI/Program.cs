using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.AutoMapper;
using WriterBlog.Business.DependencyResolvers;
using WriterBlog.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoFaac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BusinessModule()));



//Mapper
MapperConfiguration mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
//Context
builder.Services.AddDbContext<Context>();
builder.Services.AddSession();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
var app = builder.Build();



void ConfigureServices(IServiceCollection services)
{
	services.AddControllersWithViews();
	services.AddMvc(config =>
	{
		var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
		config.Filters.Add(new AuthorizeFilter(policy));
	});
	
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); //Kimlik doðrulama
app.UseAuthorization(); //Yetki doðrulama

app.UseSession();
app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=index}/{id?}");

app.Run();
