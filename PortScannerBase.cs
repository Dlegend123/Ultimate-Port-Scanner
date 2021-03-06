using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ultimate_Port_Scanner
{
    public abstract class PortScannerBase
    {
        // Hostname and port properties for scanning
        public string Hostname { get; set; }
        public int Port { get; set; }

        // Timeout property that specifies how long to wait for an answer
        public int Timeout { get; set; }

        // Base construcor - just set up default values for properties
        public PortScannerBase()
        {
            Hostname = "127.0.0.1";
            Port = 22;
            Timeout = 1000;
        }

        // Check that the hostname is listening on the port - asynchronously
        public abstract Task<bool> CheckOpenAsync(CancellationToken ct);
    }
}
