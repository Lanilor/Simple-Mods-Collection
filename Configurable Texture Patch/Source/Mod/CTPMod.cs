using UnityEngine;
using Verse;

namespace ConfigurableTexturePatch
{

    public class CTPMod : Mod
    {

        public CTPModSettings settings;

        public CTPMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<CTPModSettings>();
        }

        public override string SettingsCategory() {
            return "CTP_SettingsCategory".Translate();
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            settings.DoWindowContents(rect);
            settings.Write();
        }

    }

}
