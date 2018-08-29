using System.Reflection;
using Harmony;
using Verse;

namespace ConfigurableTexturePatch
{

    [StaticConstructorOnStartup]
    class Harmony
    {

        static Harmony()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.lanilor.configurabletexturepatch");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

}
