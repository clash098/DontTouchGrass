using BepInEx;
using HarmonyLib;

namespace DontTouchGrass
{
    
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        public static bool _enabled = true;

        public void OnEnable() => _enabled = true;

        public void OnDisable() => _enabled = false;

        private void Awake() => Harmony.CreateAndPatchAll(GetType().Assembly, "com.uhclash.gorillatag.DontTouchGrass");
    }

    [HarmonyPatch(typeof(VRRig), nameof(VRRig.PlayHandTapLocal))]
    public class Patchs
    {
        [HarmonyPrefix]
        private static void Prefix(VRRig __instance, int audioClipIndex, bool isLeftHand, float tapVolume)
        {
            if (Plugin._enabled && __instance.isLocal && audioClipIndex == 7) UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.AccessViolation);
        }
    }
}
