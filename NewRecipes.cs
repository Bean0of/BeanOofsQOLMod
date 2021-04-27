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
    internal static class NewRecipes
    {
        internal static void AddRecipes()
        {
            Mod mod = ModContent.GetInstance<BeanOofsQOLMod>();

            #region Vanity

            // TODO: Add recipes for the 3 trillion vanity sets

            #endregion

            if (ModContent.GetInstance<ConfigServer>().AncientManipulatorRecipe)
            {

                ModRecipe ancientManipulator = new ModRecipe(mod);
                ancientManipulator.AddIngredient(ItemID.LunarBar, 20);
                ancientManipulator.AddIngredient(ItemID.FragmentSolar);
                ancientManipulator.AddIngredient(ItemID.FragmentNebula);
                ancientManipulator.AddIngredient(ItemID.FragmentStardust);
                ancientManipulator.AddIngredient(ItemID.FragmentVortex);
                ancientManipulator.AddTile(TileID.LunarCraftingStation);
                ancientManipulator.SetResult(ItemID.LunarCraftingStation);
                ancientManipulator.AddRecipe();
            }

            if (BeanOofsUtils.CalamityInstalled)
            {
                if (ModContent.GetInstance<ConfigServer>().SimpleAuricTeslaRecipe)
                {
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
}
