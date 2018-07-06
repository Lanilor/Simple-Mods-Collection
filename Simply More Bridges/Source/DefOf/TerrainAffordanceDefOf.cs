using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace SimplyMoreBridges
{

    [DefOf]
    public static class TerrainAffordanceDefOf
    {

        static TerrainAffordanceDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(TerrainAffordanceDefOf));
		}

        public static TerrainAffordanceDef Bridgeable;
        public static TerrainAffordanceDef BridgeableDeep;

    }

}
