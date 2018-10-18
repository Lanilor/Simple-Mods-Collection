using System.Collections.Generic;
using Harmony;
using UnityEngine;
using Verse;

namespace ConfigurableTexturePatch
{

    public class CTPModSettings : ModSettings
    {

        public const float GapHeight = 10f;

        public const string PathMealSimple = "Things/Item/Meal/Simple";
        public const string PathMealFine = "Things/Item/Meal/Fine";
        public const string PathMealLavish = "Things/Item/Meal/Lavish";
        public const string PathMealNutrientPaste = "Things/Item/Meal/NutrientPaste";
        public const string PathMealSurvivalPack = "Things/Item/Meal/SurvivalPack";
        public const string PathRawBerries = "Things/Item/Resource/PlantFoodRaw/Berries";
        public const string PathMedicineHerbal = "Things/Item/Resource/Medicine/MedicineHerbal";
        public const string PathMedicineIndustrial = "Things/Item/Resource/Medicine/MedicineIndustrial";
        public const string PathMedicineUltratech = "Things/Item/Resource/Medicine/MedicineUltratech";
        public const string PathSilver = "Things/Item/Resource/Silver";
        public const string PathGold = "Things/Item/Resource/Gold";
        public const string PathPlantBerry = "Things/Plant/BerryPlant";
        public const string PathPlantHealroot = "Things/Plant/Healroot";

        private static int DefaultMeal = 0;
        private static int DefaultRawBerries = 0;
        private static int DefaultMedicine = 0;
        private static int DefaultSilver = 0;
        private static int DefaultGold = 0;
        private static int DefaultPlantBerry = 0;
        private static int DefaultPlantHealroot = 0;

        public static int valueMeal = DefaultSilver;
        public static int valueRawBerries = DefaultRawBerries;
        public static int valueMedicine = DefaultSilver;
        public static int valueSilver = DefaultSilver;
        public static int valueGold = DefaultGold;
        public static int valuePlantBerry = DefaultPlantBerry;
        public static int valuePlantHealroot = DefaultPlantHealroot;

        public CTPModSettings() : base()
        {
            LongEventHandler.QueueLongEvent(FinalizeInit, "CTP_LoadingTextures", false, null);
        }

        public static void FinalizeInit()
        {
            InitTexture(ThingDefOf.MealSimple, PathMealSimple, valueMeal);
            InitTexture(ThingDefOf.MealFine, PathMealFine, valueMeal);
            InitTexture(ThingDefOf.MealLavish, PathMealLavish, valueMeal);
            InitTexture(ThingDefOf.MealNutrientPaste, PathMealNutrientPaste, valueMeal);
            InitTexture(ThingDefOf.MealSurvivalPack, PathMealSurvivalPack, valueMeal);
            InitTexture(ThingDefOf.RawBerries, PathRawBerries, valueRawBerries);
            InitTexture(ThingDefOf.MedicineHerbal, PathMedicineHerbal, valueMedicine);
            InitTexture(ThingDefOf.MedicineIndustrial, PathMedicineIndustrial, valueMedicine);
            InitTexture(ThingDefOf.MedicineUltratech, PathMedicineUltratech, valueMedicine);
            InitTexture(ThingDefOf.Silver, PathSilver, valueSilver);
            InitTexture(ThingDefOf.Gold, PathGold, valueGold);
            InitTexture(ThingDefOf.Plant_Berry, PathPlantBerry, valuePlantBerry);
            InitTexture(ThingDefOf.Plant_Healroot, PathPlantHealroot, valuePlantHealroot);
            InitTexture(ThingDefOf.Plant_HealrootWild, PathPlantHealroot, valuePlantHealroot);
        }

        private static void InitTexture(ThingDef def, string pathPart, int val)
        {
            if (val > 0)
            {
                def.graphicData.texPath = pathPart + "_V" + val;
                Traverse.Create(def.graphicData).Method("Init").GetValue();
            }
        }

        /*private static void InitTexturePlant(ThingDef def, string pathPart, int val, bool immature, bool leafless)
        {
            if (val > 0 && def.plant != null)
            {
                string path = pathPart + "_V" + val;
                def.graphicData.texPath = path;
                if (immature)
                {
                    Traverse.Create(def.plant).Field("immatureGraphicPath").SetValue(path + "_Immature");
                }
                if (leafless)
                {
                    Traverse.Create(def.plant).Field("leaflessGraphicPath").SetValue(path + "_Leafless");
                }
                Traverse.Create(def.graphicData).Method("Init").GetValue();
                def.plant.PostLoadSpecial(def);
            }
        }*/

        public void DoWindowContents(Rect rect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(rect);
            ls.Gap(GapHeight);
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;

            // Item - Meal
            if (ls.ButtonTextLabeled("CTP_Meal".Translate(), ("CTP_Meal_" + valueMeal).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_Meal_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MealSimple, PathMealSimple);
                    SetTexture(ThingDefOf.MealFine, PathMealFine);
                    SetTexture(ThingDefOf.MealLavish, PathMealLavish);
                    SetTexture(ThingDefOf.MealNutrientPaste, PathMealNutrientPaste);
                    SetTexture(ThingDefOf.MealSurvivalPack, PathMealSurvivalPack);
                    valueMeal = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Meal_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MealSimple, PathMealSimple + "_V1");
                    SetTexture(ThingDefOf.MealFine, PathMealFine + "_V1");
                    SetTexture(ThingDefOf.MealLavish, PathMealLavish + "_V1");
                    SetTexture(ThingDefOf.MealNutrientPaste, PathMealNutrientPaste + "_V1");
                    SetTexture(ThingDefOf.MealSurvivalPack, PathMealSurvivalPack + "_V1");
                    valueMeal = 1;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Meal_2").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MealSimple, PathMealSimple + "_V2");
                    SetTexture(ThingDefOf.MealFine, PathMealFine + "_V2");
                    SetTexture(ThingDefOf.MealLavish, PathMealLavish + "_V2");
                    SetTexture(ThingDefOf.MealNutrientPaste, PathMealNutrientPaste + "_V2");
                    SetTexture(ThingDefOf.MealSurvivalPack, PathMealSurvivalPack + "_V2");
                    valueMeal = 2;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.Gap(GapHeight);
            if (ls.ButtonTextLabeled("CTP_RawBerries".Translate(), ("CTP_RawBerries_" + valueRawBerries).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_RawBerries_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.RawBerries, PathRawBerries);
                    valueRawBerries = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_RawBerries_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.RawBerries, PathRawBerries + "_V1");
                    valueRawBerries = 1;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.GapGapLine(GapHeight);

            // Item - Resource
            if (ls.ButtonTextLabeled("CTP_Medicine".Translate(), ("CTP_Medicine_" + valueMedicine).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_Medicine_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MedicineHerbal, PathMedicineHerbal);
                    SetTexture(ThingDefOf.MedicineIndustrial, PathMedicineIndustrial);
                    SetTexture(ThingDefOf.MedicineUltratech, PathMedicineUltratech);
                    valueMedicine = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Medicine_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MedicineHerbal, PathMedicineHerbal + "_V1");
                    SetTexture(ThingDefOf.MedicineIndustrial, PathMedicineIndustrial + "_V1");
                    SetTexture(ThingDefOf.MedicineUltratech, PathMedicineUltratech + "_V1");
                    valueMedicine = 1;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Medicine_2").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MedicineHerbal, PathMedicineHerbal + "_V2");
                    SetTexture(ThingDefOf.MedicineIndustrial, PathMedicineIndustrial + "_V2");
                    SetTexture(ThingDefOf.MedicineUltratech, PathMedicineUltratech + "_V2");
                    valueMedicine = 2;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Medicine_3").Translate(), delegate
                {
                    SetTexture(ThingDefOf.MedicineHerbal, PathMedicineHerbal + "_V3");
                    SetTexture(ThingDefOf.MedicineIndustrial, PathMedicineIndustrial + "_V3");
                    SetTexture(ThingDefOf.MedicineUltratech, PathMedicineUltratech + "_V3");
                    valueMedicine = 3;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.Gap(GapHeight);
            if (ls.ButtonTextLabeled("CTP_Silver".Translate(), ("CTP_Silver_" + valueSilver).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_Silver_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Silver, PathSilver);
                    valueSilver = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Silver_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Silver, PathSilver + "_V1");
                    valueSilver = 1;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Silver_2").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Silver, PathSilver + "_V2");
                    valueSilver = 2;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.Gap(GapHeight);
            if (ls.ButtonTextLabeled("CTP_Gold".Translate(), ("CTP_Gold_" + valueGold).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_Gold_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Gold, PathGold);
                    valueGold = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_Gold_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Gold, PathGold + "_V1");
                    valueGold = 1;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.GapGapLine(GapHeight);

            // Plant
            if (ls.ButtonTextLabeled("CTP_PlantBerry".Translate(), ("CTP_PlantBerry_" + valuePlantBerry).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_PlantBerry_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Plant_Berry, PathPlantBerry);
                    valuePlantBerry = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_PlantBerry_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Plant_Berry, PathPlantBerry + "_V1");
                    valuePlantBerry = 1;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }
            ls.Gap(GapHeight);
            if (ls.ButtonTextLabeled("CTP_PlantHealroot".Translate(), ("CTP_PlantHealroot_" + valuePlantHealroot).Translate()))
            {
                List<FloatMenuOption> menuEntries = new List<FloatMenuOption>();
                menuEntries.Add(new FloatMenuOption(("CTP_PlantHealroot_0").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Plant_Healroot, PathPlantHealroot);
                    SetTexture(ThingDefOf.Plant_HealrootWild, PathPlantHealroot);
                    valuePlantHealroot = 0;
                }));
                menuEntries.Add(new FloatMenuOption(("CTP_PlantHealroot_1").Translate(), delegate
                {
                    SetTexture(ThingDefOf.Plant_Healroot, PathPlantHealroot + "_V1");
                    SetTexture(ThingDefOf.Plant_HealrootWild, PathPlantHealroot + "_V1");
                    valuePlantHealroot = 1;
                }));
                Find.WindowStack.Add(new FloatMenu(menuEntries));
            }

            // Restore original values
            Text.Anchor = backupAnchor;
            ls.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref valueMeal, "valueMeal", DefaultMeal);
            Scribe_Values.Look(ref valueRawBerries, "valueRawBerries", DefaultRawBerries);
            Scribe_Values.Look(ref valueMedicine, "valueMedicine", DefaultMedicine);
            Scribe_Values.Look(ref valueSilver, "valueSilver", DefaultSilver);
            Scribe_Values.Look(ref valueGold, "valueGold", DefaultGold);
            Scribe_Values.Look(ref valuePlantBerry, "valuePlantBerry", DefaultPlantBerry);
            Scribe_Values.Look(ref valuePlantHealroot, "valuePlantHealroot", DefaultPlantHealroot);
        }

        private void SetTexture(ThingDef def, string path)
        {
            def.graphicData.texPath = path;
            Traverse.Create(def.graphicData).Method("Init").GetValue();

            // Redraw all items if playing
            if (Current.ProgramState == ProgramState.Playing)
            {
                List<Map> maps = Find.Maps;
                foreach (Map map in maps)
                {
                    List<Thing> things = map.listerThings.ThingsOfDef(def);
                    foreach (Thing t in things)
                    {
                        t.Notify_ColorChanged();
                    }
                }
            }
        }

        /*private void SetTexturePlant(ThingDef def, string path, bool immature, bool leafless)
        {
            def.graphicData.texPath = path;
            if (immature)
            {
                Traverse.Create(def.plant).Field("immatureGraphicPath").SetValue(path + "_Immature");
            }
            if (leafless)
            {
                Traverse.Create(def.plant).Field("leaflessGraphicPath").SetValue(path + "_Leafless");
            }
            Traverse.Create(def.graphicData).Method("Init").GetValue();
            def.plant.PostLoadSpecial(def);

            // Redraw all items if playing
            if (Current.ProgramState == ProgramState.Playing)
            {
                List<Map> maps = Find.Maps;
                foreach (Map map in maps)
                {
                    List<Thing> things = map.listerThings.ThingsOfDef(def);
                    foreach (Thing t in things)
                    {
                        t.Notify_ColorChanged();
                    }
                }
            }
        }*/

    }

}
