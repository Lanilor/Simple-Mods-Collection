using RimWorld;
using Verse;

namespace ConfigurableTexturePatch
{

    [DefOf]
    public static class ThingDefOf
    {

        static ThingDefOf()
		{
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
		}

        // Item - Meal/Food
        public static ThingDef MealSimple;
        public static ThingDef MealFine;
        public static ThingDef MealLavish;
        public static ThingDef MealNutrientPaste;
        public static ThingDef MealSurvivalPack;
        public static ThingDef RawBerries;

        // Item - Resource
        public static ThingDef MedicineHerbal;
        public static ThingDef MedicineIndustrial;
        public static ThingDef MedicineUltratech;
        public static ThingDef Silver;
        public static ThingDef Gold;

        // Plant
        public static ThingDef Plant_Berry;
        public static ThingDef Plant_Healroot;
        public static ThingDef Plant_HealrootWild;

    }

}
