using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Items.Die
{
    class Die : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("I recommend not using this in a hardcore world.");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.buyPrice(gold: 2);
        }

        public override bool UseItem(Player player)
        {
            player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} had an opinion on twitter.com"), 6942069420.0, 0, false);

            return true;
        }
    }
}
