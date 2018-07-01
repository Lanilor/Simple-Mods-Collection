using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace SimpleStockpilePresets
{

    [StaticConstructorOnStartup]
    class Harmony
    {

        static Harmony()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.lanilor.simplestockpilepresets");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

}
