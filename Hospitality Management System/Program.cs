using Hospitality_Management_System.Services;
using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Swashbuckle.AspNetCore;
using System.Text;

namespace Hospitality_Management_System;

public class Program
{
    /// <summary>
    /// Main method of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <remarks>
    /// This method is the entry point of the application. It configures the services, sets up the database connection,
    /// and starts the web server.
    /// </remarks>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure MongoDB
        var mongoClient = new MongoClient(builder.Configuration["MongoDB:ConnectionString"]);
        var database = mongoClient.GetDatabase(builder.Configuration["MongoDB:DatabaseName"]);
        builder.Services.AddSingleton(database);

        // Test database connection
        try
        {
            var collection = database.GetCollection<BsonDocument>("test");
            collection.InsertOne(new BsonDocument());
            Console.WriteLine("Database connection successful");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database connection failed");
            Console.WriteLine(ex.Message);
            Environment.Exit(1);
        }

        // Add User Service
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<AppointmentService>();
        builder.Services.AddScoped<BillingService>();
        builder.Services.AddScoped<PatientService>();
        builder.Services.AddScoped<DoctorService>();

        // JWT Authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        // Add Swagger services
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospitality Management System API", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new[] { "Bearer" }
        }
            });
        });

        var app = builder.Build();

        // Add Swagger middleware
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospitality Management System API V1");
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(builder =>
        builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}
