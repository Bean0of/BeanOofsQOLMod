using System.Collections.Generic;
using BeanOofsQOLMod.Items.SkipEarlyGame;
using BeanOofsQOLMod.UI;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace BeanOofsQOLMod
{
	public class BeanOofsQOLMod : Mod
	{
        internal UserInterface GuyThatFixesThingsInterface;
        //internal UserInterface MusicSlotInterface;
        //internal MusicSlotUI MusicSlotUI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                GuyThatFixesThingsInterface = new UserInterface();

                //MusicSlotInterface = new UserInterface();
                //MusicSlotUI = new MusicSlotUI();
                //MusicSlotInterface.SetState(MusicSlotUI);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "BQOLMOD: Guy That Fixes Things",
                    delegate {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
                        GuyThatFixesThingsInterface.Draw(Main.spriteBatch, new GameTime());
                        //MusicSlotInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            GuyThatFixesThingsInterface?.Update(gameTime);
            //MusicSlotInterface?.Update(gameTime);
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup classBags = new RecipeGroup(() => "Skip Early Game Class Bag", new[]
            {
                ItemType("SkipEarlyGameMeleeBag"),
                ItemType("SkipEarlyGameMageBag"),
                ItemType("SkipEarlyGameRangerBag"),
                ItemType("SkipEarlyGameSummonerBag"),
                ItemType("SkipEarlyGameCalamityMeleeBag"),
                ItemType("SkipEarlyGameCalamityMageBag"),
                ItemType("SkipEarlyGameCalamityRangerBag"),
                ItemType("SkipEarlyGameCalamitySummonerBag"),
                ItemType("SkipEarlyGameCalamityRougeBag"),
            });

            RecipeGroup.RegisterGroup("BQOLMOD:Skip Early Game Class Bag", classBags);
        }

        public override void AddRecipes()
        {
            NewRecipes.AddRecipes();
        } 
    }
}