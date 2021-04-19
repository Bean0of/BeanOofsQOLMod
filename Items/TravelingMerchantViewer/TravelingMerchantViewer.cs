using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Items.TravelingMerchantViewer
{
    class TravelingMerchantViewer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows you to see what a traveling merchant has anywhere.");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noUseGraphic = true;
            item.value = Item.buyPrice(gold: 2);
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer && Main.netMode != NetmodeID.Server)
            {
                foreach (NPC npc in Main.npc)
                {
                    if (npc.type == NPCID.TravellingMerchant && npc.life > 0 && npc.active)
                    {
                        Main.NewText($"[c/00FF00:{npc.GivenName} the Traveling Merchant has:]");
                        foreach (int item in Main.travelShop)
                        {
                            if (item != 0) Main.NewText($"[i/s1:{item}]");
                        }
                        Main.NewText($"[i/s1:{item.type}]");
                    }
                }
            }

            return true;
        }
    }
}
