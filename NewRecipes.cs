using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    internal static class NewRecipes
    {
        internal static void AddRecipes()
        {
            if (BeanOofsUtils.CalamityInstalled)
            {
                Mod mod = ModContent.GetInstance<BeanOofsQOLMod>();

                ModRecipe simpleAuricTesla = new ModRecipe(mod);
                simpleAuricTesla.AddIngredient(BeanOofsUtils.CalamityMod.GetItem("AuricOre"), 20);
                simpleAuricTesla.AddIngredient(BeanOofsUtils.CalamityMod.GetItem("HellcasterFragment"));
                simpleAuricTesla.AddTile(BeanOofsUtils.CalamityMod.GetTile("DraedonsForge"));
                simpleAuricTesla.SetResult(BeanOofsUtils.CalamityMod.GetItem("AuricBar"), 2);
                simpleAuricTesla.AddRecipe();
            }
        }
    }
}
