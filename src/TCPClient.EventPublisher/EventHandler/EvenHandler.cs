using System.Net.Sockets;
using System.Text;
using TCPClient.EventPublisher.EventHandler.Interface;
using TCPClient.EventPublisher.Logger.Interface;

namespace TCPClient.EventPublisher.EventHandler
{
    public class EvenHandler : IEventHandler
    {
        private readonly ILogCommunication _logger;
        private readonly ServerConfiguration _serverConfiguration;

        public EvenHandler(ILogCommunication logger, ServerConfiguration serverConfiguration)
        {
            _logger = logger;
            _serverConfiguration = serverConfiguration;
        }

        public async Task SendEventAsync(string eventData)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(_serverConfiguration.ServerIp, _serverConfiguration.Port);
                    using (var networkStream = client.GetStream())
                    {
                        var data = Encoding.UTF8.GetBytes(eventData);
                        await networkStream.WriteAsync(data, 0, data.Length);

                        // Log the sent event
                        _logger.LogCommunicationAsync($"Sent: {eventData}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCommunicationAsync($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
