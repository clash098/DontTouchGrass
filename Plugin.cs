using BepInEx;
using HarmonyLib;
using System.Reflection;
using GorillaLocomotion;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace DontTouchGrass
{
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony harmony;

        private void OnEnable()
        {
            this.harmony = new Harmony("com.uhclash.gorillatag.DontTouchGrass");
            this.harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        private void OnDisable()
        {
            if (this.harmony == null) return;
            this.harmony.UnpatchSelf();
            this.harmony = (Harmony) null;
        }
    }

    [HarmonyPatch(typeof (VRRig), "SetHandEffectData")]
    public class SetHandEffectDataPatch
    {
        [HarmonyPrefix]
        private static void Prefix(VRRig __instance, object effectContext, int audioClipIndex, bool isDownTap, bool isLeftHand, StiltID stiltID, float handTapVolume, float handTapSpeed, Vector3 dirFromHitToHand)
        {
            if (!__instance.isLocal || audioClipIndex != 7) return;
            UnityEngine.Diagnostics.Utils.ForceCrash(ForcedCrashCategory.AccessViolation);
        }
    }
}
