using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace SimplyMoreBridges
{

    [StaticConstructorOnStartup]
    class Harmony
    {

        static Harmony()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.lanilor.simplymorebridges");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        // grafikfehler bei pfeilern (unterer rand dünne linie)

        // texturdesign? (gleiche farbe, etwas anderes muster besser?)

    }

}
