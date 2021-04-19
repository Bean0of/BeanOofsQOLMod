using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace BeanOofsQOLMod.Items.DespawnBosses
{
    class DespawnBosses : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Despawns bosses NOT kill them");
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
            foreach (NPC npc in Main.npc)
            {
                if (npc.boss)
                {
                    npc.active = false;
                }
            }

            return true;
        }
    }
}
