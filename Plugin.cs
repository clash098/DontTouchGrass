using BepInEx;
using UnityEngine;
using System.Diagnostics;

namespace DontTouchGrass
{
    [BepInPlugin("com.uhclash.gorillatag.DontTouchGrass", "Don't Touch Grass", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    { 
        void Update()
        {
            if (!GorillaTagger.Instance) return;

            CheckHandForGrass(GorillaTagger.Instance.leftHandTransform);
            CheckHandForGrass(GorillaTagger.Instance.rightHandTransform);
        }

        void CheckHandForGrass(Transform handTransform)
        {
            RaycastHit hit;
            if (Physics.Raycast(handTransform.position, -handTransform.up, out hit, 0.2f))
            {
                if (hit.collider.gameObject.name.ToLower() == "pit ground")
                {
                    System.Threading.Thread.Sleep(100);
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}