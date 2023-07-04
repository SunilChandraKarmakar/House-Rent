using HouseRentWebApi.Common;
using HouseRentWebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HouseRentContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Add services to the container.
builder.Services.AddControllers();

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

builder.Services.AddIdentity<User, IdentityRole>(option => { }).AddEntityFrameworkStores<HouseRentContext>();

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

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();