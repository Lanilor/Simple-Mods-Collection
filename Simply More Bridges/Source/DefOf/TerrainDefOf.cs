using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace SimplyMoreBridges
{

    [DefOf]
    public static class TerrainDefOf
    {

        static TerrainDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(TerrainDefOf));
        }

        // Heavy bridge
        public static TerrainDef HeavyBridgeSteel;
        public static TerrainDef HeavyBridgePlasteel;
        public static TerrainDef HeavyBridgeSandstone;
        public static TerrainDef HeavyBridgeGranite;
        public static TerrainDef HeavyBridgeLimestone;
        public static TerrainDef HeavyBridgeSlate;
        public static TerrainDef HeavyBridgeMarble;

        // Deep water bridge
        public static TerrainDef DeepWaterBridgeSteel;
        public static TerrainDef DeepWaterBridgePlasteel;
        public static TerrainDef DeepWaterBridgeSandstone;
        public static TerrainDef DeepWaterBridgeGranite;
        public static TerrainDef DeepWaterBridgeLimestone;
        public static TerrainDef DeepWaterBridgeSlate;
        public static TerrainDef DeepWaterBridgeMarble;

    }

}
