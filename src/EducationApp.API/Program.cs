using EducationApp.Application.DIContainer;
using EducationApp.DataAccess.Database;
using EducationApp.DataAccess.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration)
    .ServiceContainer();


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
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
    builder.WebHost.UseUrls($"http://*:{builder.Configuration.GetValue<int>("PORT")}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<EduDbContext>();
await context.Database.MigrateAsync();
// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();



// Allow CORS for all origins, methods, and headers
app.UseCors("AllowAll");



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
