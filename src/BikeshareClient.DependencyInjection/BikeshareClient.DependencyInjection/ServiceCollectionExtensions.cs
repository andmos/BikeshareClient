namespace BikeshareClient.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddBikeshareClient(this IServiceCollection services, string baseUrl)
        => services.AddHttpClient<IBikeshareClient>("GbfsClient", httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            new Client(string.Empty, httpClient);
        });
}
