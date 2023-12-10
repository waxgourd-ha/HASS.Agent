using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;

namespace HASS.Agent.Shared.Managers;
public static class HardwareManager
{
	private static Computer s_computer;
	public static void Initialize()
	{
		//Note(Amadeo): for "performance" reasons only GPU is selected below, enable additional ones if required by new sensors/commands
		s_computer = new Computer()
		{
			IsCpuEnabled = false,
			IsGpuEnabled = true,
			IsMemoryEnabled = false,
			IsMotherboardEnabled = false,
			IsControllerEnabled = false,
			IsNetworkEnabled = false,
			IsStorageEnabled = false,
		};

		s_computer.Open();
	}

	public static IList<IHardware> Hardware => s_computer.Hardware;

	public static void Shutdown() => s_computer?.Close();
}
