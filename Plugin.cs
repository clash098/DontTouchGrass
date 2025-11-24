using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace DontTouchGrass
{
    [HarmonyPatch(typeof(VRRig), nameof(VRRig.PlayHandTapLocal))]
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake() => Harmony.CreateAndPatchAll(GetType().Assembly, Info.Metadata.GUID);
        private static bool Prefix(VRRig __instance, int audioClipIndex)
        {
            if (!__instance.isLocal || audioClipIndex != 7) return true;
            
            Debug.Log("we fucking exploded into smithereens");
            UnityEngine.Diagnostics.Utils.ForceCrash(0);
            
            return false;
        }
    }
}
