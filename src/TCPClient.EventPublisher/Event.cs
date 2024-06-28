using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient.EventPublisher
{
    public class Event 
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }

        public bool IsProcessed { get; set; }
    }
}
