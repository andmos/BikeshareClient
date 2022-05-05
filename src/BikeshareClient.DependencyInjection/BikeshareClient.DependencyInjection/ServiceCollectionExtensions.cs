namespace BikeshareClient.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBikeshareClient(this IServiceCollection services, string baseUrl)
    {
            services.AddHttpClient("GBFSClient", httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseUrl);
            });
            
            services.AddTransient<IBikeshareClient>(provider =>
            {
                var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("GBFSClient");
                
                return new Client("", httpClient);
            });
            return services;
    }
}
