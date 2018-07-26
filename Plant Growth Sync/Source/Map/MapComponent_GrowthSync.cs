using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace PlantGrowthSync
{

    public class MapComponent_GrowthSync : MapComponent
    {

        private const float SyncRatePerFullGrowth = 0.15f;

        public MapComponent_GrowthSync(Map map) : base(map)
		{
		}

        public override void MapComponentTick()
        {
            // TickLong
            if (Find.TickManager.TicksGame % 2000 != 0)
            {
                return;
            }
            List<Zone> allZones = map.zoneManager.AllZones;
            foreach (Zone z in allZones)
            {
                // Skip wrong or useless cases
                if (z.GetType() != typeof(Zone_Growing))
                {
                    continue;
                }
                Zone_Growing zg = (Zone_Growing)z;
                /*if (!z2.allowGrowthSync)
                {
                    continue;
                }*/
                /*var extVals = z2.GetPlantDefToGrow().GetModExtension<ModExtension_Plant>() ?? ModExtension_Plant.defaultValues;
                if (!extVals.syncGrowthIfCrop) {
                    continue;
                }*/
                float growthSyncStep = SyncRatePerFullGrowth / (zg.GetPlantDefToGrow().plant.growDays * 30);
                IEnumerable<Thing> allThings = zg.AllContainedThings;
                // Sum up all plant growth
                List<Plant> plantsInZone = new List<Plant>();
                float avg = 0;
                foreach (Thing thing in allThings)
                {
                    if (thing.GetType() == typeof(Plant)) {
                        Plant plant = (Plant)thing;
                        // Is plant wanted in this zone (isCrop) and growing?
                        if (plant.IsCrop && plant.LifeStage == PlantLifeStage.Growing)
                        {
                            avg += plant.Growth;
                            plantsInZone.Add(plant);
                        }
                    }
                }
                // Calculate average
                avg = avg / plantsInZone.Count;
                // Get ups and downs and process/clean near avg plants
                int ups = 0;
                int downs = 0;
                for (int i = plantsInZone.Count - 1; i >= 0; i--)
                {
                    if (Math.Abs(avg - plantsInZone[i].Growth) <= growthSyncStep)
                    {
                        plantsInZone[i].Growth = avg;
                        plantsInZone.RemoveAt(i);
                        continue;
                    }
                    if (plantsInZone[i].Growth < avg)
                    {
                        ups++;
                    }
                    if (plantsInZone[i].Growth > avg)
                    {
                        downs++;
                    }
                }
                // Calculate step balance factor
                float upBalance = 1f;
                float downBalance = 1f;
                if (ups > 0 && downs > 0)
                {
                    if (ups > downs)
                    {
                        upBalance = (float)downs / ups;
                    }
                    else
                    {
                        downBalance = (float)ups / downs;
                    }
                }
                // Use on plants
                foreach (Plant plant in plantsInZone)
                {
                    if (plant.Growth < avg)
                    {
                        plant.Growth += growthSyncStep * upBalance;
                    }
                    if (plant.Growth > avg)
                    {
                        plant.Growth -= growthSyncStep * downBalance;
                    }
                }
            }
        }

    }

}
