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
            // Load logging and server configurations from user secret
            var loggingConfiguration = new LogConfiguration();
            configuration.GetSection("LogConfiguration").Bind(loggingConfiguration);
            var serverConfiguration = new ServerConfiguration();
            configuration.GetSection("ServerConfiguration").Bind(serverConfiguration);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(loggingConfiguration)
                .AddSingleton(serverConfiguration)
                .AddScoped<IEventHandler, TCPClient.EventPublisher.EventHandler.EvenHandler>()
                .AddScoped<ILogCommunication, LogCommunication>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
