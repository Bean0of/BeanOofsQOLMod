using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    class BeanOofsQOLModPlayer : ModPlayer
    {
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.Name.Contains("Music Box"))
                {
                    bool r = false;
                    player.VanillaUpdateAccessory(player.whoAmI, item, false, ref r, ref r, ref r);
                }
            }
        }
    }
}
