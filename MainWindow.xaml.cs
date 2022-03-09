using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serilog;
using Serilog.Core;
using Ultimate_Port_Scanner.Reporting;

namespace Ultimate_Port_Scanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Delegate to report back with one open port
        public delegate void ExecuteOnceCallback(int openPort);

        // Delegate to report back with one open port (Async)
        public delegate void ExecuteOnceAsyncCallback(int port, bool isOpen, bool isCancelled, bool isLast);

        //Logger instance (Logs to file at application directory root)
        private static readonly Logger logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("logfile.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

        // The manager instance
        IScannerManagerSingleton smc;

        // Cancellation token source for the cancel button
        private CancellationTokenSource cts;

        // Current mode of operation
        private ScannerManagerSingleton.ScanMode currentScanMode;

        //Handler for Reporting Utilities
        private static ReportingHandler _reportingHandler = new ReportingHandler();
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
