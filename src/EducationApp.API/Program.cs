using EducationApp.Application.DIContainer;
using EducationApp.Application.MappingProfiles;
using EducationApp.DataAccess.Database;
using EducationApp.DataAccess.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration)
    .ServiceContainer();


// Json Ignore Reference Loop Handling
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });


// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
    builder.WebHost.UseUrls($"http://*:{builder.Configuration.GetValue<int>("PORT")}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EduDbContext>();
await context.Database.MigrateAsync();
// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
