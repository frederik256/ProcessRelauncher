using System.ComponentModel;

namespace ProcessRelauncher
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void ProcessRelauncherInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void serviceProcessInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }
    }
}
