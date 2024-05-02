using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Application.Services;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Repositories;
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

    public static void InjectDomain(this IServiceCollection collection)
    {
        collection.AddScoped<ICommandRepository<Employee>, CommandRepository<Employee>>();
        collection.AddScoped<IQueryRepository<Employee>, QueryRepository<Employee>>();
        collection.AddScoped<IEmployeeService, EmployeeService>();

        collection.AddScoped<ICommandRepository<Reservation>, CommandRepository<Reservation>>();
        collection.AddScoped<IQueryRepository<Reservation>, QueryRepository<Reservation>>();
        collection.AddScoped<IReservationService, ReservationService>();

        collection.AddScoped<ICommandRepository<Order>, CommandRepository<Order>>();
        collection.AddScoped<IQueryRepository<Order>, QueryRepository<Order>>();
        collection.AddScoped<IOrderService, OrderService>();
    }

    public static void InjectPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<IGenericController, GenericController>();
    }
}