using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RimWorld;
using Verse;
using System.Reflection.Emit;

namespace SimplyMoreBridges
{

    [HarmonyPatch(typeof(TerrainGrid))]
    [HarmonyPatch("SetTerrain")]
    public class Harmony_TerrainGrid_SetTerrain
    {

        private static bool SetTerrainHelper(TerrainDef terrain)
        {
            return terrain.passability != Traversability.Impassable || terrain.affordances.Contains(TerrainAffordanceDefOf.BridgeableDeep);
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            for (int i = 0, iLen = instructions.Count(); i < iLen; i++)
            {
                CodeInstruction ci = instructions.ElementAt(i);
                if (ci.opcode == OpCodes.Ldelem_Ref && instructions.ElementAt(i + 1).opcode == OpCodes.Ldfld && instructions.ElementAt(i + 2).opcode == OpCodes.Ldc_I4_2 && instructions.ElementAt(i + 3).opcode == OpCodes.Beq)
                {
                    yield return ci;
                    yield return new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Harmony_TerrainGrid_SetTerrain), "SetTerrainHelper"));
                    yield return new CodeInstruction(OpCodes.Brfalse, instructions.ElementAt(i + 3).operand);
                    i += 3;
                }
                else
                {
                    yield return ci;
                }
            }
            yield break;
        }

    }

}
