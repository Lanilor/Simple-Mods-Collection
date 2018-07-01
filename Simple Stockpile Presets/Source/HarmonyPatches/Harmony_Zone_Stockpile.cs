using Harmony;
using System;
using System.Collections.Generic;
using System.Text;
using RimWorld;
using Verse;
using System.Collections;
using System.Linq;

namespace SimpleStockpilePresets
{

    [HarmonyPatch(typeof(Zone_Stockpile))]
    [HarmonyPatch("GetGizmos")]
    public class Harmony_Zone_Stockpile_GetGizmos
    {

        public static void Postfix(Zone_Stockpile __instance, ref IEnumerable<Gizmo> __result)
        {
            __result = __result.Add(new Command_StorageSettingsPresets(__instance));
        }

    }

}
