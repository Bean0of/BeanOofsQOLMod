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
    class DebugTools : ModPlayer
    {
        public override void PostUpdate()
        {
            if (ModContent.GetInstance<Debug>().ShowInternalItemNames)
            {
                Item item = player.HeldItem;
                if (item != null && item.modItem != null)
                {
                    Main.NewText($"Internal Name: {item.modItem.Name}");
                }
            }
        }
    }
}
