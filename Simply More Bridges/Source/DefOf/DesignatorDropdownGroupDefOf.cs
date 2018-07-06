using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace SimplyMoreBridges
{

    [DefOf]
    public static class DesignatorDropdownGroupDefOf
    {

        static DesignatorDropdownGroupDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DesignatorDropdownGroupDefOf));
        }

        public static DesignatorDropdownGroupDef Bridge_Heavy;
        public static DesignatorDropdownGroupDef Bridge_DeepWater;

    }

}
