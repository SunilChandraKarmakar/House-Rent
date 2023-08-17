using HouseRentWebApi.ApplicationLogic;
using HouseRentWebApi.Common;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HouseRentContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User, IdentityRole>(option => { }).AddEntityFrameworkStores<HouseRentContext>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

// Add CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration 
builder.Services.AddSwaggerDocument((configuration =>
{
    configuration.Version = "v1";
    configuration.Title = "House Rent Web API";
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

// Apply custom exception handler
app.UseCustomExceptionHandler();

app.UseCors("AllowOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();