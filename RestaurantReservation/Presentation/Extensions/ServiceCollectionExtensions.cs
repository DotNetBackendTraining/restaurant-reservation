using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Controllers;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Presentation.Services;

namespace RestaurantReservation.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void InjectConfiguration(this IServiceCollection collection, IConfiguration databaseConfiguration)
    {
        collection.AddSingleton<IDbContextFactory>(_ => new DefaultDbContextFactory(databaseConfiguration));
    }

    public static void InjectDatabase(this IServiceCollection collection)
    {
        collection.AddScoped<RestaurantReservationDbContext>(p => p.GetRequiredService<IDbContextFactory>().Create());
    }

    public static void InjectPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<IGenericController, GenericController>();
    }
}