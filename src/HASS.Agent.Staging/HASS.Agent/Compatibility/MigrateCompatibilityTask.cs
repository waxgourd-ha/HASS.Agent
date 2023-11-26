using System.Diagnostics;
using System.IO;
using HASS.Agent.Commands;
using HASS.Agent.Functions;
using HASS.Agent.MQTT;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Service;
using Microsoft.Win32;
using Serilog;


namespace HASS.Agent.Compatibility
{
    internal class MigrateCompatibilityTask : ICompatibilityTask
    {
        internal const string OldHASSAgentFolder = "LAB02 Research";
        internal const string OldServiceFolder = "HASS.Agent Satellite Service";
        internal const string OldClientFolder = "HASS.Agent";

        public string Name => Languages.Compat_MigrateTask_Name;

        private void MigrateConfig(string source, string destination)
        {
            if (string.IsNullOrEmpty(destination))
            {
                Log.Information("[COMPATTASK] Destination is not valid");
                return;
            }

            var oldConfigDir = new DirectoryInfo(Path.Combine(source, "config"));
            if (!oldConfigDir.Exists)
            {
                Log.Information("[COMPATTASK] No configuration folder found");
                return;
            }

            var oldConfigFiles = oldConfigDir.GetFiles();
            if (!oldConfigFiles.Any())
            {
                Log.Information("[COMPATTASK] No configuration files available for migration");
                return;
            }

            Directory.CreateDirectory(destination);

            foreach (var file in oldConfigFiles)
                file.CopyTo(Path.Combine(destination, file.Name), true);

            Log.Information("[COMPATTASK] Configuration migrated");
        }

        private void MigrateServiceConfig()
        {
            Log.Information("[COMPATTASK] Service configuration migration start");

            var oldServiceInstallationPath = ServiceManager.GetInstallPath(OldHASSAgentFolder, OldServiceFolder);
            if (string.IsNullOrWhiteSpace(oldServiceInstallationPath))
            {
                Log.Information("[COMPATTASK] No service installation folder found");
                return;
            }

            MigrateConfig(oldServiceInstallationPath, Path.Combine(ServiceManager.GetInstallPath(), "config"));

            Log.Information("[COMPATTASK] Service configuration migration end");
        }

        private void MigrateClientConfig()
        {
            Log.Information("[COMPATTASK] Client configuration migration start");

            var oldClientInstallPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), OldHASSAgentFolder, OldClientFolder);
            if (string.IsNullOrWhiteSpace(oldClientInstallPath))
            {
                Log.Information("[COMPATTASK] No client installation folder found");
                return;
            }

            MigrateConfig(oldClientInstallPath, Variables.ConfigPath);

            Log.Information("[COMPATTASK] Client configuration migration end");
        }

        private void MigrateRegistryConfig()
        {
            //from HKEY_CURRENT_USER\SOFTWARE\LAB02Research\HASSAgent
            //to   HKEY_CURRENT_USER\SOFTWARE\HASSAgent\Client"

            //from HKEY_LOCAL_MACHINE\SOFTWARE\LAB02Research\HASSAgent\SatelliteService"
            //to   HKEY_LOCAL_MACHINE\SOFTWARE\HASSAgent\SatelliteService

            var source = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LAB02Research\HASSAgent");
            var destination = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HASSAgent\Client", true);
            CopyRegistryKey(source, destination);
        }

        public async Task<(bool, string)> Perform()
        {
            try
            {
                var errorMessage = string.Empty;

                Log.Information("[COMPATTASK] Migration name compatibility task started");

                MigrateServiceConfig();
                MigrateClientConfig();
                MigrateRegistryConfig();

                //HelperFunctions.Restart(true);

                return string.IsNullOrWhiteSpace(errorMessage) ? (true, string.Empty) : (false, errorMessage);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[COMPATTASK] Error performing migration compatibility task: {err}", ex.Message);
                return (false, Languages.Compat_Error_CheckLogs);
            }
        }

        private void CopyRegistryKey(RegistryKey source, RegistryKey destination)
        {
            foreach (var valueName in source.GetValueNames())
                destination.SetValue(valueName, source.GetValue(valueName, null, RegistryValueOptions.DoNotExpandEnvironmentNames), source.GetValueKind(valueName));

            foreach (var name in source.GetSubKeyNames())
            {
                using var sourceSubKey = source.OpenSubKey(name, false);
                var destinationSubKey = destination.CreateSubKey(name);
                CopyRegistryKey(sourceSubKey, destinationSubKey);
            }
        }
    }
}
