using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ultimate_Port_Scanner
{
    internal interface IScannerManagerSingleton
    {
        void ExecuteOnceAsync(string hostname, int port, int timeout, ScannerManagerSingleton.ScanMode scanMode, MainWindow.ExecuteOnceAsyncCallback callback, CancellationToken ct);
        void ExecuteRangeAsync(string hostname, int portMin, int portMax, int timeout, ScannerManagerSingleton.ScanMode scanMode, MainWindow.ExecuteOnceAsyncCallback callback, CancellationToken ct);
    }
}
