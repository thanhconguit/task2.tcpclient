using Microsoft.Extensions.DependencyInjection;
using TCPClient.EventPublisher.EventHandler.Interface;
using TCPClient.EventPublisher.Logger.Interface;
using TCPClient.EventPublisher.Logger;
using Microsoft.Extensions.Configuration;
using TCPClient.EventPublisher.EventHandler;


namespace TCPClient
{
    public static class ServiceRegister
    {
        public static ServiceProvider SetupDependencies(IConfiguration configuration)
        {
            // Load server configurations from user secret
            var serverConfiguration = new ServerConfiguration();
            configuration.GetSection("ServerConfiguration").Bind(serverConfiguration);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(serverConfiguration)
                .AddLogging()
                .AddScoped<ILogCommunication, LogCommunication>()
                .AddScoped<IEventHandler, TCPClient.EventPublisher.EventHandler.EvenHandler>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
