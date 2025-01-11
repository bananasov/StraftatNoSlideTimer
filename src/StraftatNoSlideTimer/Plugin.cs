using BepInEx;
using BepInEx.Logging;
using StraftatSlideNoSlideTimer.Hooks;


[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log = null!;

    private void Awake()
    {
        Log = Logger;

        FirstPersonControllerHooks.Initialize();

        Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} is loaded!");
    }
}