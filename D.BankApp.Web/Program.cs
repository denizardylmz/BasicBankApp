using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.UnitOfWorks;
using D.BankApp.Web.Mapping;
using D.BankApp.Web.Repositories;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using AppContext = D.BankApp.Web.Datas.Context.BankContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BankContext>(options => options.UseNpgsql(Configurations.ConnectionString));


builder.Services.AddScoped<IUow2, Uow2>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(ConcreteRepository<>));
//builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
//builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IAccountMapper, AccountMapper>();


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