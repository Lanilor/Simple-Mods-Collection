using System.Reflection;
using Harmony;
using Verse;

namespace SmallMaps
{

    [StaticConstructorOnStartup]
    class Harmony
    {

        static Harmony()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.lanilor.smallmaps");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
        }

    }

}
