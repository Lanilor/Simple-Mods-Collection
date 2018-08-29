using UnityEngine;
using Verse;
using System;

namespace ConfigurableTexturePatch
{

    public static class Listing_StandardExtension
    {

        private const float BaseLineHeight = 30f;

        public static void GapGapLine(this Listing_Standard ls, float gapHeight = 12f)
        {
            ls.Gap(gapHeight);
            ls.GapLine(gapHeight);
            ls.Gap(gapHeight);
        }

        public static void CheckboxGroupLabeled(this Listing_Standard ls, string label, string tooltip, string cbLabel1, ref bool cbCheckOn1, string cbTooltip1, string cbLabel2, ref bool cbCheckOn2, string cbTooltip2)
        {
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            // Wrapper
            Rect rectWrapper = ls.GetRect(BaseLineHeight);
            Rect rectLeft = rectWrapper.LeftPart(0.5f).Rounded();
            Rect rectRight = rectWrapper.RightPart(0.5f).Rounded();
            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rectLeft, tooltip);
            }
            // Left
            Text.Anchor = TextAnchor.MiddleLeft;
            if (label != null)
            {
                Widgets.Label(rectLeft, label);
            }
            // Right
            Text.Anchor = TextAnchor.MiddleRight;
            // Left checkbox
            Rect rectInnerLeft = rectRight.LeftPart(0.5f).RightPartPixels(Text.CalcSize(cbLabel1).x + 24f + 12f).Rounded();
            TooltipHandler.TipRegion(rectInnerLeft, cbTooltip1);
            Widgets.CheckboxLabeled(rectInnerLeft, cbLabel1, ref cbCheckOn1);
            // Right checkbox
            Rect rectInnerRight = rectRight.RightPart(0.5f).RightPartPixels(Text.CalcSize(cbLabel2).x + 24f + 12f).Rounded();
            TooltipHandler.TipRegion(rectInnerRight, cbTooltip2);
            Widgets.CheckboxLabeled(rectInnerRight, cbLabel2, ref cbCheckOn2);
            // Restore original values
            Text.Anchor = backupAnchor;
        }

        public static void TextFieldLabeled(this Listing_Standard ls, string label, ref string val, string tooltip = null)
        {
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            // Wrapper
            Rect rectWrapper = ls.GetRect(BaseLineHeight);
            Rect rectLeft = rectWrapper.LeftPart(0.5f).Rounded();
            Rect rectRight = rectWrapper.RightPart(0.5f).Rounded();
            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rectLeft, tooltip);
            }
            // Left
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rectLeft, label);
            // Right
            val = Widgets.TextField(rectRight, val);
            // Restore original values
            Text.Anchor = backupAnchor;
        }

        public static void IntegerFieldLabeled(this Listing_Standard ls, string label, ref int val, ref string buffer, string additionalInfoCol = null, string tooltip = null)
        {
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            // Wrapper
            Rect rectWrapper = ls.GetRect(BaseLineHeight);
            Rect rectLeft = rectWrapper.LeftPart(0.5f).Rounded();
            Rect rectCenter;
            Rect rectRight = rectWrapper.RightPart((additionalInfoCol == null) ? 0.5f : 0.25f).Rounded();
            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rectLeft, tooltip);
            }
            // Left
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rectLeft, label);
            // Center
            if (additionalInfoCol != null)
            {
                rectCenter = rectWrapper.RightPart(0.5f).LeftPart(0.45f).Rounded();
                Text.Anchor = TextAnchor.MiddleRight;
                Widgets.Label(rectCenter, additionalInfoCol);
                Text.Anchor = TextAnchor.MiddleLeft;
            }
            // Right
            Widgets.TextFieldNumeric<int>(rectRight, ref val, ref buffer);
            // Restore original values
            Text.Anchor = backupAnchor;
        }

        public static void SliderLabeled(this Listing_Standard ls, string label, ref float val, float min, float max, string format = null, string tooltip = null)
        {
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            // Wrapper
            Rect rectWrapper = ls.GetRect(BaseLineHeight);
            Rect rectLeft = rectWrapper.LeftHalf();
            Rect rectRight = rectWrapper.RightHalf();
            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rectLeft, tooltip);
            }
            // Left
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rectLeft, label);
            // Right
            string sliderLabel = (format != null) ? val.ToString(format) : val.ToString();
            val = Widgets.HorizontalSlider(rectRight, val, min, max, true, sliderLabel);
            // Restore original values
            Text.Anchor = backupAnchor;
        }
        public static void SliderLabeled(this Listing_Standard ls, string label, ref int val, int min, int max, string format = null, string tooltip = null)
        {
            float valFloat = val;
            ls.SliderLabeled(label, ref valFloat, min, max, format, tooltip);
            val = (int)valFloat;
        }

    }

}
