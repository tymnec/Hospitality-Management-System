using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Swashbuckle.AspNetCore;
using System.Text;
using Hospitality_Management_System.Persistence;

namespace Hospitality_Management_System;

using MongoDB.Bson;
using MongoDB.Driver;

public class Program
{
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

        builder.Services.AddSingleton<HospitalityContext>();

        builder.Services.AddScoped<IDoctorDataAccess, DoctorEF>();
        builder.Services.AddScoped<IPatientDataAccess, PatientEF>();
        builder.Services.AddScoped<IAppointmentDataAccess, AppointmentEF>();
        builder.Services.AddScoped<IBillingDataAccess, BillingEF>();

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

