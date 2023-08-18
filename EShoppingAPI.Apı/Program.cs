using EShoppingAPI.Apý.Middleware;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.Business.Concrete;
using EShoppingAPI.DAL.Abstract.DataManagment;
using EShoppingAPI.DAL.Concrete.EntityFramework.Context;
using EShoppingAPI.DAL.Concrete.EntityFramework.DataManagment;
using EShoppingAPI.Helper.Globals;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<EShoppingContext>();
builder.Services.AddScoped<IUnýtOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection("JWTExceptURLList"));




var app = builder.Build();

//app.UseGlobalExceptionMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
