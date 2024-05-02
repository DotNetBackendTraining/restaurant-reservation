using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Presentation.Extensions;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Test.Common.Fixtures;

/// <summary>
/// Complete test setup, with all dependencies, and sample database.
/// </summary>
public class FullTestSetupFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public FullTestSetupFixture()
    {
        var serviceCollection = new ServiceCollection();
        InjectConfiguration(serviceCollection); // Test configuration
        serviceCollection.InjectDatabase();
        serviceCollection.InjectDomain();
        serviceCollection.InjectApplication();
        serviceCollection.InjectPresentation();
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private void InjectConfiguration(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<DatabaseFixture>();
        serviceCollection.AddSingleton<IDbContextFactory>(p =>
            p.GetRequiredService<DatabaseFixture>().ContextFactory);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        ServiceProvider.GetRequiredService<DatabaseFixture>().Dispose();
    }
}