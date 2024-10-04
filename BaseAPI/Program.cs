
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;
using Mongo.Services;
using Business.Interface;
using Business;
using Repository.Generic;
using Repository.Interface;
using BaseAPI.Infrastructure;

internal class Program
{
    public static void Main(string[] args)
    {
        string appName = "Template de comunicação com banco mongo";
        string appVersion = "v1";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
        builder.Services.AddSingleton<MongoDBService>();

        builder.Services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            })
        );


        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddScoped<ICrudBusiness, CrudBusiness>();

        // 
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = appName,
                Version = appVersion,
                Description = $"Modelo para API com MongoDB",
                Contact = new OpenApiContact
                {
                    Name = "Gabriel Henrique",
                    Email = "gabrielhosws4@gmail.com"
                }
            });
        });

        // Serviço de Versionamento da API

        builder.Services.AddApiVersioning();

        var app = builder.Build();

        app.UseRouting();

        app.UseCors();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{appName} - {appVersion}"); });
        }


        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);

        // Configure the HTTP request pipeline.


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    
}
