ProcessRelauncher
=================

A tiny service that monitors a process by processname and spawns it if not running. Useful for restarting applications that don't run as a service.  (SpamAssasin for Windows in my case)
Currently configuration is baked in but easily changed via ProcessRelauncher.Program.
Comes with MSI project for installation.
Make sure you set ProcessRelauncher.ProjectInstaller.serviceProcessInstaller.Account to an account with appropriately locked down credentials.
 

