ProcessRelauncher
=================

A small service that monitors a process by processname and spawns it if not running. 
Useful for restarting applications that don't run as a service (SpamAssasin for Windows in my case).

Currently configuration is baked in because this project is a quick one-off-hack. 
Regardless, it's easily changed via ProcessRelauncher.Program and could trivially be extended to work off a config file.  
Comes with MSI project for installation. Service doesn't start on install, but is configured to come start automatically after a reboot.

Security!
=========

Set ProcessRelauncher.ProjectInstaller.serviceProcessInstaller.Account to an account with appropriately locked down credentials!
 

