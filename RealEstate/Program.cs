using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using RealEstate.Services;
using UserManagement;
using UserManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RealEstate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IGeocodingService, GeocodingService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IListingService, ListingService>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<ISearchFilterService, SearchFilterService>();

        // Build the application.
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}

