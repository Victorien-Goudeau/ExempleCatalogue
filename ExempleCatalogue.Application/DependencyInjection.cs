namespace ExempleCatalogue.Application;

using CommandUseCase.Book;
using Microsoft.Extensions.DependencyInjection;
using QueryUseCase.Book;

public static class DependencyInjection {
    public static void AddUseCase(this IServiceCollection services) {
        services.AddScoped<QueryAllBooksHandler>();
        services.AddScoped<CommandAddBookHandler>();
    }
}
