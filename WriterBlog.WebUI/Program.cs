using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Business.AutoMapper;
using WriterBlog.Business.DependencyResolvers;

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



var app = builder.Build();


//void ConfigureServices(IServiceCollection services)
//{
//	services.AddControllersWithViews();
//	services.AddMvc(config =>
//	{
//		var policy = new AuthorizationPolicyBuilder()
//					.RequireAuthenticatedUser()
//					.Build();
//		config.Filters.Add(new AuthorizeFilter(policy));
//	});
//}



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=index}/{id?}");

app.Run();
