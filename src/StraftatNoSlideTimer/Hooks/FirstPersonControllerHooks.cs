using MonoMod.Cil;

namespace StraftatNoSlideTimer.Hooks;

public static class FirstPersonControllerHooks
{
    public static void Initialize()
    {
        Plugin.Log.LogInfo("Hooking FirstPersonController");
        // NOTE: This now spams audio, I don't want to fuck with IL to fix this.
        On.FirstPersonController.HandleSlide += FirstPersonControllerOnHandleSlide;

        if (!Plugin.Settings.EnableSpammySounds.Value)
        {
            IL.FirstPersonController.HandleSlide += FirstPersonControllerOnHandleSlideIL;
        }
    }

    private static void FirstPersonControllerOnHandleSlideIL(ILContext il)
    {
        var c = new ILCursor(il);

        /*
            82	010C	ldarg.0
            83	010D	ldfld	class SlopeSlide FirstPersonController::slopeSlideScript
            84	0112	ldfld	bool SlopeSlide::sprintSlideTrigger
            85	0117	brtrue.s	88 (011F) ldarg.0
            86	0119	ldarg.0
            87	011A	call	instance void FirstPersonController::SlideAudioPlay()
         */
        var ok = c.TryGotoNext(
            MoveType.Before,
            x => x.MatchLdarg(0),
            x => x.MatchLdfld<FirstPersonController>("slopeSlideScript"),
            x => x.MatchLdfld<SlopeSlide>("sprintSlideTrigger"),
            x => x.MatchBrtrue(out _),
            x => x.MatchLdarg(0),
            x => x.MatchCall<FirstPersonController>("SlideAudioPlay")
        );

        if (ok)
        {
            Plugin.Log.LogInfo($"Matched, index: {c.Index}");
            c.RemoveRange(6);
        }
        else
        {
            Plugin.Log.LogError("Failed to match IL instructions for audio playing");
        }
    }

    private static void FirstPersonControllerOnHandleSlide(On.FirstPersonController.orig_HandleSlide orig,
        FirstPersonController self)
    {
        //self.slideTimer = 0.2f;
        orig(self);
        self.slideTimer = 0.2f;
    }
}
