using ApiPersonajesExamenGio.Data;
using ApiPersonajesExamenGio.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlAzure");

    builder.Services.AddTransient<RepositoryPersonajes>();
    builder.Services.AddDbContext<PersonajesContext>(options =>
        options.UseSqlServer(connectionString)
    );

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options => {
        options.SwaggerDoc("v1", new OpenApiInfo {
            Title = "API PERSONAJES",
            Description = "API PERSONAJES DESCRIPCIÓN",
            Version = "v1"
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "API CRUD PERSONAJES V1");
        options.RoutePrefix = "";
    });

if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
