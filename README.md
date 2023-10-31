<a href="https://github.com/LAB02-Research/HASS.Agent/">
    <img src="https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/logo_128.png" alt="HASS.Agent logo" title="HASS.Agent" align="right" height="128" /></a>

# HASS.Agent Project

This project is a fork of the [original HASS.Agent](https://github.com/LAB02-Research/HASS.Agent) created by [Sam](https://github.com/LAB02-Research).

The Purpose of this project is to provide updates/features/fixes until development on the original project resumes. For now, all released from this repository will be marked as beta.

At first all PRs made by me will be merged, but in time, I'll approach authors of other PRs for permission to also include them in here.

**NOTE**: I did my best to always maintain backward compatibility but this ***cannot be guaranteed***, please report any issues you may encounter.

## Installation

**I do hope to improve this process in the future**

**Step 0:** I cannot stress this enough - ***backup the config folder of your current HASS.Agent installation before reading further***
<br><br><br>
The original HASS.Agent repository is not available as far as I'm informed.<br>
There are two options to approach this:
- creating a new installer
- going with "patch it over" approach

Currently the recommended option is the "patch it over". HASS.Agent is capable of functioning without the installer but the installer takes care of some dependencies that might need to be installed manually otherwise.
<br>
1. Download and install HASS.Agent from [the official release](https://github.com/LAB02-Research/HASS.Agent/releases) (usually in **"C:\Users\<username>\AppData\Roaming\LAB02 Research\HASS.Agent\"**)
2. Download and install WindowsAppSDK ([explanation why](https://github.com/LAB02-Research/HASS.Agent.Staging/pull/18))
for HASS.Agent 2023.10.0 - https://aka.ms/windowsappsdk/1.3/1.3.230724000/windowsappruntimeinstall-x64.exe
3. Make sure the HASS.Agent service is stopped
<br><img src="https://github.com/amadeo-alex/HASS.Agent/assets/68441479/38590ab0-7d42-4790-9629-73596725d75e" height="350px" />
4. Close/Exit out of the HASS.Agent
<br><img src="https://github.com/amadeo-alex/HASS.Agent/assets/68441479/38939e3d-6dff-447c-a497-78def5fa41ff" height="350px" />
5. Download the release package from this repository
6. Copy/Replace the downloaded files over the installed ones (again, usually in **"C:\Users\<username>\AppData\Roaming\LAB02 Research\HASS.Agent\"**)
7. Launch HASS.Agent and verify that you're using the unofficial beta version by navigating to help window - "u" in the version postfix
<img src="https://github.com/amadeo-alex/HASS.Agent/assets/68441479/19edc4f6-e674-4238-8d11-d50c16feb8a9" height="350px" />
<img src="https://github.com/amadeo-alex/HASS.Agent/assets/68441479/05df8795-b8f6-4a9e-b666-a55b89196a3e" height="350px" />

----

"Project" differences from the base project:
1. No separation between "HASS.Agent" and "HASS.Agent.Staging" - since I have no access to the original repositories, it'll be easier for me to maintain it this way
2. No documentation available yet - best case scenario the descriptions in the application should be sufficient but even so, I'd like to have unofficial documentation created at some point
3. The update functionality present in UI does not work with the unofficial version, yet

----

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


Note: it's best to have `enable extended logging` enabled, which will also reflect on the satellite service (as long as it's started in console mode instead of service mode). But that'll also generate false positives, so primarily focus on the issue at hand.

----

Documentation for the original project is available here: [https://hassagent.readthedocs.io/en/latest/development/introduction/](https://hassagent.readthedocs.io/en/latest/development/introduction/)

----

Thanks! If you need more info, please join on [Discord](https://discord.gg/nMvqzwrVBU).
