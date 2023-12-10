<a href="https://github.com/LAB02-Research/HASS.Agent/">
    <img src="https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/logo_128.png" alt="HASS.Agent logo" title="HASS.Agent" align="right" height="128" /></a>

# HASS.Agent Project

This project is a fork of the [original HASS.Agent](https://github.com/LAB02-Research/HASS.Agent) created by [Sam](https://github.com/LAB02-Research).

The Purpose of this project is to provide updates/features/fixes until development on the original project resumes.

At first all PRs made by me will be merged, but in time, I'll approach authors of other PRs for permission to also include them in here.

**NOTE**: I did my best to always maintain backward compatibility but this ***cannot be guaranteed***, please report any issues you may encounter.

## Installation

### Installer

**Will be detailed and moved to the documentation soon :)**

1. Download and run the installer exe from the releases page
2. Launch HASS.Agent either manually or as a last step of installation

The installer will also offer and install the required x64 .net runtime. 

### Manual

Note: Both Client and Satellite Service ***may*** function without installation as a portable applications.

**The recommended and official way is to use the installer.**

1. Download Client/Satellite Service ZIP files from the releases page
2. Extract the files to separate folders (Client and Satellite Service)
3. [Register](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/sc-create) the service in elevated cmd
```
sc.exe create hass.agent.svc binPath= "<absolute path to HASS.Agent.Satellite.Service.exe>"
```
4. Run "HASS.Agent.exe"

----

"Project" differences from the base project:
1. No separation between "HASS.Agent" and "HASS.Agent.Staging" - since I have no access to the original repositories, it'll be easier for me to maintain it this way
2. No documentation available yet - best case scenario the descriptions in the application should be sufficient but even so, I'd like to have unofficial documentation created at some point
3. The update functionality present in UI does not work with the unofficial version, yet

----

**Will be moved to the documentation soon :)**

Major feature changes compared to the original project:
1. [Virtual desktop sensor and command](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/12)
2. [Quick Action carousel/circular navigation](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/15)
3. [Notification library change an improvements including possible Win11 fix](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/18)
4. [Application volume controls (per application control, audio output command, audio sensor overhaul)](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/19)
5. [Internal device sensors - sensors present on the device running HASS.Agent](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/21)
6. [Ignore availability option for sensors](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/22)
6. [Radio (BT/WiFi/Broadband) control command](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/23)
7. [LastActive sensor refresh upon wake from sleep/hibernation](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/9)

Major bug fix changes compared to the original project:
1. [GPU temperature and load sensor returns proper values when encountering an error](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/10)
2. [Key commands emulation not actually "releases" the key after "pressing it"](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/13)
3. [PowerShell command action parameters now include check culture config missing on some systems](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/14)
4. [PerformanceCounter sensors do not call NextValue twice causing values to be borked](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/16)
5. [Adjustments per Home Assistant 2023.8 MQTT changes regarding sensor/device naming convention](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/20)

----

This project contains the latest code of all three parts of the HASS.Agent platform:


| Project | Description |
|---|---|
| HASS.Agent | Main client, containing the UI, runs in userspace, by default without elevation |
| HASS.Agent.Satellite.Service | Windows client, runs under SYSTEM account |
| HASS.Agent.Shared | Library, contains all commands, sensors, shared functions and enums |

<br/>


Note: when reporting issues it's best to have `enable extended logging` enabled.

----

Documentation for the original project is available here: [https://hassagent.readthedocs.io/en/latest/development/introduction/](https://hassagent.readthedocs.io/en/latest/development/introduction/)

----

Thanks! If you need more info, please join on [Discord](https://discord.gg/nMvqzwrVBU).
