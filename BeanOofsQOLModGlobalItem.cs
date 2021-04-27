using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    class BeanOofsQOLModGlobalItem : GlobalItem
    {
        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = (int)(reforgePrice * ModContent.GetInstance<ConfigServer>().ReforgePriceMultiplier);
            return true;
        }
    }
}
