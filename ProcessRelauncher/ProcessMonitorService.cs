using System.ServiceProcess;

namespace ProcessRelauncher
{
    public partial class ProcessMonitorService : ServiceBase
    {
        private readonly ProcessMonitor _pm;

        public ProcessMonitorService(ProcessMonitor pm)
        {
            _pm = pm;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _pm.Start();
        }

        protected override void OnStop()
        {
            _pm.Dispose();
        }
    }
}
