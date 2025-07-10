using EducationApp.Application.DIContainer;
using EducationApp.Application.Helpers;
using EducationApp.Application.Helpers.GenerateJwt;
using EducationApp.Application.Helpers.Seeder;
using EducationApp.Application.Services.Interfaces;
using EducationApp.Application.Services;
using EducationApp.DataAccess.Database;
using EducationApp.DataAccess.DependencyInjection;
using Microsoft.OpenApi.Models;
using EducationApp.Application.Settings;
using Microsoft.Extensions.Options;
using Minio;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDatabase(builder.Configuration)
    .ServiceContainer()
    .AddJwtOption(builder.Configuration)
    .AddAuth(builder.Configuration);

// Json Ignore
//builder.Services.AddControllers()
//    .AddJsonOptions(x =>
//    {
//        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//        x.JsonSerializerOptions.WriteIndented = true;
//    });
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Allow Frontend CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOption"));

// Minio
builder.Services.AddSingleton<IFileStorageService, MinioFileStorageService>();
builder.Services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));

builder.Services.AddSingleton<IMinioClient>(sp =>
{
	var minioSettings = sp.GetRequiredService<IOptions<MinioSettings>>().Value;

	// MinioClient obyektini yaratish
	var client = new MinioClient()
		.WithEndpoint(minioSettings.Endpoint)
		.WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey);

	// Agar SSL yoqilgan bo'lsa
	if (minioSettings.UseSSL)
	{
		client = client.WithSSL();
	}

	return client.Build(); // MinioClient ni qurish
});

builder.Services.AddSwaggerGen(c =>
{

    // API haqida umumiy ma'lumotlar
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EducationApi",
        Version = "v1"
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

if (builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
    builder.WebHost.UseUrls($"http://*:{builder.Configuration.GetValue<int>("PORT")}");

//var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EduDbContext>();
//await context.Database.MigrateAsync();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EduDbContext>();
    await PermissionSeeder.SeedPermissionsAsync(db);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();