using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace Ultimate_Port_Scanner.Utilities
{
    public static class HelperMethods
    {
        private static readonly Logger logger= new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("logfile.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();


        public static void PauseForXSeconds(int secondsPaused)
        {
            secondsPaused = (int)TimeSpanUtil.ConvertMillisecondsToSeconds(secondsPaused);
            System.Threading.Thread.Sleep(secondsPaused);
        }

        public static void PauseForXMinutes(int minutesPaused)
        {
            minutesPaused = (int)TimeSpanUtil.ConvertMinutesToMilliseconds(minutesPaused);
            System.Threading.Thread.Sleep(minutesPaused);
        }

        public static void LogErrors(Exception ex)
        {
            Logger.None.Debug(ex.Message);
            Logger.None.Debug(ex.StackTrace);
            Logger.None.Debug(ex.InnerException.Message);
        }

    }
}
