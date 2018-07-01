using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace SimpleStockpilePresets
{

    [DefOf]
    public static class SpecialThingFilterDefOf
    {

        static SpecialThingFilterDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(SpecialThingFilterDefOf));
        }

        public static SpecialThingFilterDef AllowRotten;
        public static SpecialThingFilterDef AllowFresh;
        public static SpecialThingFilterDef AllowSmeltable;
        public static SpecialThingFilterDef AllowNonSmeltableWeapons;
        public static SpecialThingFilterDef AllowNonDeadmansApparel;
        public static SpecialThingFilterDef AllowDeadmansApparel;
        public static SpecialThingFilterDef AllowCorpsesColonist;
        public static SpecialThingFilterDef AllowCorpsesStranger;

    }

}
