using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace DontTouchGrass
{
    [HarmonyPatch(typeof(VRRig), nameof(VRRig.PlayHandTapLocal))]
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        void Awake() => Harmony.CreateAndPatchAll(GetType().Assembly, Info.Metadata.GUID);
        [HarmonyPostfix]
        static void GrassPatch(VRRig __instance, int audioClipIndex)
        {
            if (__instance.isLocal && audioClipIndex == 7) UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.FatalError);
        }
    }
}
