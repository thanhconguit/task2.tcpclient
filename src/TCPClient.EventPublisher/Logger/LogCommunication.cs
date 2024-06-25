using Microsoft.Extensions.Logging;
using TCPClient.EventPublisher.Logger.Interface;

namespace TCPClient.EventPublisher.Logger
{
    public class LogCommunication : ILogCommunication
    {
        private readonly ILogger<LogCommunication> _logger;
        public LogCommunication(ILogger<LogCommunication> logger)
        {
            _logger = logger;
        }
        public void LogCommunicationAsync(string message)
        {
            _logger.LogInformation($"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
