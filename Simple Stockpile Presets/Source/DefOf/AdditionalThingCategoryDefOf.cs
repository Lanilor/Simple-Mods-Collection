using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace SimpleStockpilePresets
{

    [DefOf]
    public static class AdditionalThingCategoryDefOf
    {

        static AdditionalThingCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(AdditionalThingCategoryDefOf));
        }

        public static ThingCategoryDef MortarShells;

    }

}
