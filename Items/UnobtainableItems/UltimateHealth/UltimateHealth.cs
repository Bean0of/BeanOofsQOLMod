using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Items.UnobtainableItems.UltimateHealth
{
    class UltimateHealth : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("1000000x more health\nUnobtainable");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = 1000000;
        }
    }
}
