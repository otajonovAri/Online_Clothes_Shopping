using System.Configuration;
using EducationApp.Application.DIContainer;
using EducationApp.Application.Helpers;
using EducationApp.Application.Helpers.GenerateJwt;
using EducationApp.DataAccess.Database;
using EducationApp.DataAccess.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration)
    .ServiceContainer()
    .AddJwtOption(builder.Configuration)
    .AddAuth(builder.Configuration);


// Json Ignore
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        x.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOption"));

builder.Services.AddSwaggerGen(c =>
{
    
        // API haqida umumiy ma'lumotlar
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Secure Login API",
            Version = "v1",
            Description = "SecureLoginApp uchun API hujjatlari",
            Contact = new OpenApiContact
            {
                Name = "Your Name",
                Email = "your.email@example.com"
            },
            License = new OpenApiLicense
            {
                Name = "Your License Name",
                Url = new Uri("https://example.com/license") // URI xatosi tuzatildi!
            }
        });

        // JWT Bearer autentifikatsiyasini qo'shish
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {your token}'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        // JWT Bearer uchun global xavfsizlik talabini qo'shish
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2", // Bu shart emas, lekin qoldirilsa zarar qilmaydi
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() // Bu yerda scope'lar bo'lishi mumkin, hozir bo'sh
                    }
        });
    
});


var app = builder.Build();

if(builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
    builder.WebHost.UseUrls($"http://*:{builder.Configuration.GetValue<int>("PORT")}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EduDbContext>();
await context.Database.MigrateAsync();
// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
