using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    internal static class BeanOofsUtils
    {
        private static List<int> PDAItems = new List<int>()
        {
            // Watches
            ItemID.CopperWatch,
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
            ItemID.SilverWatch,
            ItemID.TinWatch,
            ItemID.TungstenWatch,

            // Position
            ItemID.DepthMeter,
            ItemID.Compass,

            // NPCs
            ItemID.Radar,
            ItemID.LifeformAnalyzer,
            ItemID.TallyCounter,
            ItemID.MetalDetector,

            // Player
            ItemID.Stopwatch,
            ItemID.DPSMeter,

            // Fishing
            ItemID.FishermansGuide,

            // World
            ItemID.WeatherRadio,
            ItemID.Sextant,

            // Combinations
            ItemID.GPS,
            ItemID.REK,
            ItemID.GoblinTech,
            ItemID.FishFinder,
            ItemID.PDA,

            // Wiring
            ItemID.MechanicalLens,
            ItemID.Ruler,
            ItemID.LaserRuler,
        };

        public static Mod CalamityMod { get { return ModLoader.GetMod("CalamityMod"); } }
        public static Mod Luiafk { get { return ModLoader.GetMod("Luiafk"); } }
        public static Mod MagicStorage { get { return ModLoader.GetMod("MagicStorage"); } }
        public static Mod FKBossHealthBar { get { return ModLoader.GetMod("FKBossHealthBar"); } }
        public static Mod HEROsMod { get { return ModLoader.GetMod("HEROsMod"); } }

        public static bool CalamityInstalled { get { return CalamityMod != null; } }
        public static bool LuiafkInstalled { get { return Luiafk != null; } }
        public static bool MagicStorageInstalled { get { return MagicStorage != null; } }
        public static bool FKBossHealthBarInstalled { get { return FKBossHealthBar != null; } }
        public static bool HEROsModInstalled { get { return HEROsMod != null; } }

        // https://stackoverflow.com/questions/33044848/c-sharp-lerping-from-position-to-position
        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        public static bool IsPartOfPDA(Item item)
        {
            return PDAItems.Contains(item.type);
        }
    }
}
