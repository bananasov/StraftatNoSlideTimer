using BepInEx;
using BepInEx.Logging;
using StraftatNoSlideTimer.Settings;

using StraftatNoSlideTimer.Hooks;

namespace StraftatNoSlideTimer;


[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log = null!;
    internal static StraftatNoSlideTimerSettings Settings = null!;

    private void Awake()
    {
        Log = Logger;
        Settings = new StraftatNoSlideTimerSettings(Config);

        FirstPersonControllerHooks.Initialize();

        // Log our awake here, so we can see it in LogOutput.txt file
        Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");
    }
}
