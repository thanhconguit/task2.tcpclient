using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient.EventPublisher.Logger.Interface
{
    public interface ILogCommunication
    {
        Task LogCommunicationAsync(string message);
    }
}
