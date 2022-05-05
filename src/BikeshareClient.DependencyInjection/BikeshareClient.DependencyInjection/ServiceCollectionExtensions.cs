namespace BikeshareClient.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddBikeshareClient(this IServiceCollection services)
        => services.AddHttpClient<IBikeshareClient>("GbfsClient", httpClient => new Client("", httpClient));
}
