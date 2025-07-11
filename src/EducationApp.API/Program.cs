using EducationApp.Application.DIContainer;
using EducationApp.Application.MappingProfiles;
using EducationApp.DataAccess.Database;
using EducationApp.DataAccess.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDatabase(builder.Configuration)
    .ServiceContainer();

builder.Services.AddAutoMapper(typeof(AttendanceProfile).Assembly);

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

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<EduDbContext>();
await context.Database.MigrateAsync();

app.UseSwagger();
app.UseSwaggerUI();



// Allow CORS for all origins, methods, and headers
app.UseCors("AllowAll");



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();