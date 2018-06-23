using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RimWorld;
using Verse;
using System.Reflection.Emit;

namespace SimpleSteelBridges
{

    [HarmonyPatch(typeof(Designator_RemoveBridge))]
    [HarmonyPatch("CanDesignateCell")]
    public class Harmony_Designator_RemoveBridge_CanDesignateCell
    {

        private static bool DesignateCellHelper(IntVec3 c, Map map)
        {
            return c.GetTerrain(map) == TerrainDefOf.SteelBridge || c.GetTerrain(map) == RimWorld.TerrainDefOf.Bridge;
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            for (int i = 0, iLen = instructions.Count(); i < iLen; i++)
            {
                CodeInstruction ci = instructions.ElementAt(i);
                if (ci.opcode == OpCodes.Call && instructions.ElementAt(i + 1).opcode == OpCodes.Ldsfld && instructions.ElementAt(i + 2).opcode == OpCodes.Beq && instructions.ElementAt(i - 1).opcode == OpCodes.Call && instructions.ElementAt(i - 4).opcode == OpCodes.Brfalse)
                {
                    yield return new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Harmony_Designator_RemoveBridge_CanDesignateCell), "DesignateCellHelper"));
                    yield return new CodeInstruction(OpCodes.Brtrue, instructions.ElementAt(i + 2).operand);
                    i += 2;
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
