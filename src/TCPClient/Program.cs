﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCPClient;
using TCPClient.EventPublisher.EventHandler.Interface;

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>() 
                .Build();
var serviceProvider = ServiceRegister.SetupDependencies(configuration);
var eventHandler = serviceProvider.GetRequiredService<IEventHandler>();
while (true)
{
    var events = EventGenerator.GenerateEvent(); // default batch number = 1
    foreach (var eventData in events)
    {
        await eventHandler.SendEventAsync(eventData);
    }

    await Task.Delay(TimeSpan.FromSeconds(5));
}