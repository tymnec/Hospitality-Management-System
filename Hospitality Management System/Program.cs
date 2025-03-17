using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;

namespace Hospitality_Management_System;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure MongoDB
        var mongoClient = new MongoClient(builder.Configuration["MongoDB:ConnectionString"]);
        var database = mongoClient.GetDatabase(builder.Configuration["MongoDB:DatabaseName"]);
        builder.Services.AddSingleton(database);

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

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}
