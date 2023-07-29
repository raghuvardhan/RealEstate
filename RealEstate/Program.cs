using RealEstate.Services;
using UserManagement;

namespace RealEstate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IListingService, ListingService>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<ISearchFilterService, SearchFilterService>();
        builder.Services.AddScoped<IGeocodingService, GeocodingService>();

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

