using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger configuration 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "House Rent Web API",
        // Description = "Employee Management API",
        // TermsOfService = new Uri("https://pragimtech.com"),
        Contact = new OpenApiContact
        {
            Name = "Sunil Chandra Karmakar",
            Email = "sunil_karmakar@ymail.com",
            Url = new Uri("https://www.facebook.com/sunilkarmakar.subo/"),
        },
        // License = new OpenApiLicense
        // {
        //     Name = "PragimTech Open License",
        //     Url = new Uri("https://pragimtech.com"),
        // }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
