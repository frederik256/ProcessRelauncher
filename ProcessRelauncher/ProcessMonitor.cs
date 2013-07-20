using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ProcessRelauncher
{
    public class ProcessMonitor : IDisposable
    {
        private Timer _timer;
        private readonly int _monitoringPollingIntervalMs;
        private readonly ProcessStartInfo _processStartInfo;
        private readonly string _processName;

        public ProcessMonitor(string processName, ProcessStartInfo launcher, int monitoringPollingIntervalMs)
        {
            _processStartInfo = launcher;
            _processName = processName.ToLower();
            _monitoringPollingIntervalMs = monitoringPollingIntervalMs;
        }

        public void Monitor(object o)
        {            
            Process[] processlist = Process.GetProcesses();            

            if (processlist.Any(theprocess => theprocess.ProcessName.ToLower().Equals(_processName)))
            {
                Console.WriteLine(_processName + " is running");
                return;
            }

            Process.Start(_processStartInfo);
            
            Console.WriteLine("Spawning " + _processName);
        }

        public void Start()
        {
            if (_timer != null) return;

            _timer = new Timer(this.Monitor, null, 0, _monitoringPollingIntervalMs);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}