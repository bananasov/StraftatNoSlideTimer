using BepInEx.Configuration;

namespace StraftatNoSlideTimer.Settings;

public class StraftatNoSlideTimerSettings(ConfigFile config)
{
    public ConfigEntry<bool> EnableSpammySounds = config.Bind<bool>("Audio", "EnableSpammySounds", false, "Enable or disable spamming sounds when sliding");
}
