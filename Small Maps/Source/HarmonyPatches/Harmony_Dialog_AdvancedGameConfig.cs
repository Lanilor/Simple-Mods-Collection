using System;
using Harmony;
using RimWorld;

namespace SmallMaps
{

    [HarmonyPatch(typeof(Dialog_AdvancedGameConfig))]
    [HarmonyPatch(new Type[] { typeof(int) })]
    public class Harmony_Dialog_AdvancedGameConfig_Ctor
    {

        public static void Postfix(Dialog_AdvancedGameConfig __instance)
        {
            Traverse.Create(__instance).Field("MapSizes").SetValue(new int[] { 50, 75, 100, 150, 200, 225, 250, 275, 300, 325, 350, 400 });
        }

    }

}
