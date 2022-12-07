namespace ExempleCatalogue.Infrastructure;

using Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using Repository;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBookStoreRepository, BookStoreRepository>();
    }
}
