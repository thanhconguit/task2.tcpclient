using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient.EventPublisher.EventHandler.Interface
{
    public interface IEventHandler
    {
        Task SendEventAsync(string eventData);
    }
}
