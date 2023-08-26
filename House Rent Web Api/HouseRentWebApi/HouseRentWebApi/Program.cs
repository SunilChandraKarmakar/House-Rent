using HouseRentWebApi.ApplicationLogic;
using HouseRentWebApi.Common;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HouseRentContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User, IdentityRole>(option => { }).AddEntityFrameworkStores<HouseRentContext>();

// Add Jwt Authencation
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("top security key..."));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = symmetricSecurityKey
                    };
                });

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddDistributedMemoryCache();

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
    // Apply custom exception handler
    app.UseCustomExceptionHandler();
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions() 
{ 
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | 
    ForwardedHeaders.XForwardedProto | 
    ForwardedHeaders.All 
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();