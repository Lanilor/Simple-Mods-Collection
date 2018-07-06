using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RimWorld;
using Verse;

namespace SimplyMoreBridges
{

    [HarmonyPatch(typeof(GenConstruct))]
    [HarmonyPatch("CanPlaceBlueprintAt")]
    public class Harmony_GenConstruct_CanPlaceBlueprintAt
    {

        public static void Postfix(ref AcceptanceReport __result, BuildableDef entDef, IntVec3 center, Map map)
        {
            TerrainDef terrainDef = entDef as TerrainDef;
            if (terrainDef == null)
            {
                return;
            }
            TerrainAffordanceDef neededAffordance = map.terrainGrid.TerrainAt(center).terrainAffordanceNeeded;
            if (neededAffordance == TerrainAffordanceDefOf.Bridgeable || neededAffordance == TerrainAffordanceDefOf.BridgeableDeep)
            {
                __result = new AcceptanceReport("NoFloorsOnBridges".Translate());
            }
        }

    }

}
