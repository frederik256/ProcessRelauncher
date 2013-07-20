using System.Diagnostics;
using System.ServiceProcess;

namespace ProcessRelauncher
{
    static class Program
    {
        static void Main()
        {
            var processStartInfo = new ProcessStartInfo
                {
                    FileName = "spamd.exe",
                    WorkingDirectory = @"C:\Program Files (x86)\JAM Software\SpamAssassin for Windows",
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

            var pm = new ProcessMonitor("spamd", processStartInfo, 20 * 1000);

            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new ProcessMonitorService(pm) 
                                              };
            ServiceBase.Run(servicesToRun);
        }
    }
}
