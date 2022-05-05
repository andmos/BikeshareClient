namespace BikeshareClient.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddFolkeregisterClient(this IServiceCollection services)
        => services.AddHttpClient<IBikeshareClient, Client>();
}
