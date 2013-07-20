﻿using System;
using System.Diagnostics;
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

            foreach(var p in processlist)
            {
                if (p.ProcessName.ToLower().Equals(_processName)) return;
            }
            

            Process.Start(_processStartInfo);
            
            GC.Collect();
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