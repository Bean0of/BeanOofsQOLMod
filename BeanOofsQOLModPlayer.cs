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
    class BeanOofsQOLModPlayer : ModPlayer
    {
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.Name.Contains("Music Box") && ModContent.GetInstance<ConfigClient>().MusicBoxWorksInVanity)
                {
                    UpdateAccessory(item);
                }
                else if (BeanOofsUtils.IsPartOfPDA(item) && ModContent.GetInstance<ConfigClient>().InfoAccessoryWorksInVanity)
                {
                    player.VanillaUpdateInventory(item);
                }
            }
        }

        private void UpdateAccessory(Item item)
        {
            bool idkwhattheflagsare = false;
            player.VanillaUpdateAccessory(player.whoAmI, item, false, ref idkwhattheflagsare, ref idkwhattheflagsare, ref idkwhattheflagsare);
        }
    }
}
