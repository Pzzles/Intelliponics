using Intelliponics.Data;
using Intelliponics.Repositories.Implementations;
using Intelliponics.Repositories.Implementations.API;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Repositories.Interfaces.API;
using Intelliponics.Services.Implementations;
using Intelliponics.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IntelliponicsConnection")));

//Repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShippingRepository, ShippingRepository>();

//Services
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShippingService, ShippingService>();

//API Repositories
builder.Services.AddHttpClient<ILoadSheddingRepository, LoadSheddingRepository>();

//API Services
builder.Services.AddScoped<ILoadSheddingService, LoadSheddingService>();


//Config
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
