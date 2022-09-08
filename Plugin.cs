using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace FakUPunch
{
    [BepInPlugin("Radsi", "FakUPunch", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static AssetBundle punchbundle;

        private void Awake()
        {
            punchbundle = AssetBundle.LoadFromMemory(Resource1.punchanimation);
            new Harmony("radsi.fakupunch").PatchAll();
        }

        [HarmonyPatch(typeof(Punch), "Start")]
        public static class patchAnimOnStart
        {
            public static void Postfix(Punch __instance)
            {
                if(__instance.type == FistType.Standard)
                {
                    __instance.anim.runtimeAnimatorController = punchbundle.LoadAsset<RuntimeAnimatorController>("Punch");
                }
            }
        }

        [HarmonyPatch(typeof(Punch), "OnEnable")]
        public static class patchAnimOnEnable
        {
            public static void Postfix(Punch __instance)
            {
                if (__instance.type == FistType.Standard)
                {
                    __instance.anim.runtimeAnimatorController = punchbundle.LoadAsset<RuntimeAnimatorController>("Punch");
                }
            }
        }

        [HarmonyPatch(typeof(Punch), "EquipAnimation")]
        public static class patchAnimOnEA
        {
            public static void Postfix(Punch __instance)
            {
                if (__instance.type == FistType.Standard)
                {
                    __instance.anim.runtimeAnimatorController = punchbundle.LoadAsset<RuntimeAnimatorController>("Punch");
                }
            }
        }
    }
}
