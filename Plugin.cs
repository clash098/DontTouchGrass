using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace DontTouchGrass
{
    [HarmonyPatch]
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        void Awake() => Harmony.CreateAndPatchAll(GetType().Assembly, Info.Metadata.GUID);
        [HarmonyPatch(typeof(VRRig), nameof(VRRig.PlayHandTapLocal)), HarmonyPostfix]
        static void GrassPatch(VRRig __instance, int audioClipIndex)
        {
            if (__instance.isLocal && audioClipIndex == 7) Application.Quit();
        }
    }
}
