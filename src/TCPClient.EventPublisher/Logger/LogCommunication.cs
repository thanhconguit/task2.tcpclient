using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPClient.EventPublisher.Logger.Interface;

namespace TCPClient.EventPublisher.Logger
{
    public class LogCommunication : ILogCommunication
    {
        private readonly string _logFilePath;

        public LogCommunication (LogConfiguration logConfiguration)
        {
            _logFilePath = logConfiguration.FilePath; 
        }
        public async Task LogCommunicationAsync(string message)
        {
            await File.AppendAllTextAsync(_logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
