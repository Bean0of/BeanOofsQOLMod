using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Items.UnobtainableItems.UltimateEmblem
{
    class UltimateEmblem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModContent.GetInstance<ConfigServer>().UnobtainableItems;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("1000000x more damage\nUnobtainable");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamageMult += 1000000;
        }
    }
}
