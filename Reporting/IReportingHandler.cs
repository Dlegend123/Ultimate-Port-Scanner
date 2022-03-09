using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ultimate_Port_Scanner.Reporting
{
    internal interface IReportingHandler
    {
        void SetReportType(Enum.ReportType reportType);
        SaveFileDialog GetSaveFileDialog();
        string BuildTextFile(TextBox mainWindowTextBox);
        int GetReportType();
        void BuildWorkBook(TextBox mainWindowTextBox, string path);
        string GetSaveFileLocation(Enum.ReportType reportType);
    }
}
