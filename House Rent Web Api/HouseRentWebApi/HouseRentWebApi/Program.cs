using HouseRentWebApi.ApplicationLogic;
using HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic.Model;
using HouseRentWebApi.Common;
using HouseRentWebApi.Domain;
using HouseRentWebApi.Shared.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HouseRentContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User, IdentityRole>(option => { }).AddEntityFrameworkStores<HouseRentContext>();

// Add JWT
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    byte[] key = System.Text.Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]!);
    Console.WriteLine("JWT Key: " + Convert.ToBase64String(key));
    string isSuer = builder.Configuration["JWTConfig:Issuer"];
    string audience = builder.Configuration["JWTConfig:Audience"];

    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidIssuer = isSuer,
        ValidAudience = audience,
        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 }
    };
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddDistributedMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration 
builder.Services.AddOpenApiDocument((configuration =>
{
    configuration.Version = "v1";
    configuration.Title = "House Rent Web API";

    configuration.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Description = "Type into the textbox: {your JWT token}."
    });

    configuration.OperationProcessors.Add(
        new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
}));

// Add CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.SetIsOriginAllowed(_ => true);
        policy.AllowCredentials();
    });
});

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

app.UseCors("CorsPolicy");

app.UseCors("AllowHeaders");

app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.MapControllers();

app.Run();