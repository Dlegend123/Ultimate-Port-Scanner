using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Texnomic.NMap.Scanner;


namespace Ultimate_Port_Scanner.Utilities
{
    public class RemoteUtilities
    {
        private ConnectionOptions op;
        public RemoteUtilities(string Username, string Password)
        {
            op = new ConnectionOptions()
            {
                Username = Username,
                Password = Password
            };
        }
        public string RemoteShutDown(string IP_Address)
        {
            // Make a connection to a remote computer.  
            ManagementScope scope = new ManagementScope("\\\\" + IP_Address + "\\root\\cimv2", op);
            scope.Connect();
            //Query system for Operating System information  
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher query = new ManagementObjectSearcher(scope, oq);
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject obj in queryCollection)
            {
                obj.InvokeMethod("ShutDown", null); //shutdown
                return obj.ToString();
            }
            return "";
        }
        public string RemoteRestart(string IP_Address)
        {
            ManagementScope ms = new ManagementScope(IP_Address + "\\root\\cimv2", op);
            //Query remote computer across the connection
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
            ManagementObjectCollection queryCollection1 = query1.Get();

            foreach (ManagementObject mo in queryCollection1)
            {
                mo.InvokeMethod("Reboot", null);
                return mo.ToString();
            }
            return "";
        }
        public string OSDetection(string IP_Address)
        {
            var Target = new Target(IP_Address);
            var Scanner = new Scanner("\\nmap-7.92\\nmap.exe", Target)
            {
                Options = new NmapOptions() {
                    NmapFlag.TreatHostsAsOnline,
                    { NmapFlag.TopPorts, "2" },
                      NmapFlag.Reason,
                    NmapFlag.OsDetection 
                }
            };
            var Result = Scanner.PortScan(ScanType.Syn);
            List<string> osList = new List<string>();
            foreach (var Host in Result.Hosts)
            {
                foreach (var A_OS in Host.OperatingSystems)
                {
                    foreach (var OS in A_OS.Matches)
                    {
                        osList.Add($"{OS.Line}");
                    }
                }
            }
            return string.Join("\n",osList);
        }
    }
}
