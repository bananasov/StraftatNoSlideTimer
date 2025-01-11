using MonoMod.Cil;

namespace StraftatSlideNoSlideTimer.Hooks;

public static class FirstPersonControllerHooks
{
    public static void Initialize()
    {
        Plugin.Log.LogInfo("Hooking FirstPersonController");
        // NOTE: This now spams audio, I don't want to fuck with IL to fix this.
        On.FirstPersonController.HandleSlide += FirstPersonControllerOnHandleSlide;
    }

    private static void FirstPersonControllerOnHandleSlide(On.FirstPersonController.orig_HandleSlide orig,
        FirstPersonController self)
    {
        self.slideTimer = 0.2f;
        orig(self);
        self.slideTimer = 0.2f;
    }
}