using Hospitality_Management_System.Persistence;

namespace Hospitality_Management_System;

using MongoDB.Bson;
using MongoDB.Driver;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


     
        // Add services to the container.

        builder.Services.AddControllersWithViews();

        builder.Services.AddSingleton<HospitalityContext>();

        builder.Services.AddScoped<IDoctorDataAccess, DoctorEF>();
        builder.Services.AddScoped<IPatientDataAccess, PatientEF>();
        builder.Services.AddScoped<IAppointmentDataAccess, AppointmentEF>();
        builder.Services.AddScoped<IBillingDataAccess, BillingEF>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();



        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");


        app.Run();
    }
}