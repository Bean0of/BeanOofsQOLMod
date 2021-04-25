using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    internal static class BeanOofsUtils
    {
        public static Mod CalamityMod { get { return ModLoader.GetMod("CalamityMod"); } }
        public static Mod Luiafk { get { return ModLoader.GetMod("Luiafk"); } }
        public static Mod MagicStorage { get { return ModLoader.GetMod("MagicStorage"); } }
        public static Mod FKBossHealthBar { get { return ModLoader.GetMod("FKBossHealthBar"); } }

        public static bool CalamityInstalled { get { return CalamityMod != null; } }
        public static bool LuiafkInstalled { get { return Luiafk != null; } }
        public static bool MagicStorageInstalled { get { return MagicStorage != null; } }
        public static bool FKBossHealthBarInstalled { get { return FKBossHealthBar != null; } }

        // https://stackoverflow.com/questions/33044848/c-sharp-lerping-from-position-to-position
        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}
