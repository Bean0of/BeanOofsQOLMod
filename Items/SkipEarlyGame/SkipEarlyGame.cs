using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BeanOofsQOLMod;

namespace BeanOofsQOLMod.Items.SkipEarlyGame
{
    class SkipEarlyGamePlayer : ModPlayer
    {
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            if (ModContent.GetInstance<ConfigServer>().SkipEarlyGameBag == false) return;

            if (!mediumcoreDeath)
            {
                Item bag = new Item();
                bag.SetDefaults(ModContent.ItemType<SkipEarlyGame>());
                items.Add(bag);
            }
        }
    }

    public static class SkipEarlyGameUtils
    {
        private static Dictionary<int, int> vanillaItems = new Dictionary<int, int> // id, stack
        {
            { ItemID.TungstenPickaxe, 1 },
            { ItemID.TungstenAxe, 1 },
            { ItemID.TungstenHammer, 1 },
            { ItemID.EmeraldHook, 1 },
            { ItemID.HermesBoots, 1 },
            { ItemID.BandofRegeneration, 1 },
            { ItemID.CloudinaBottle, 1 },
            { ItemID.LesserHealingPotion, 30 },
            { ItemID.ShinePotion, 5 },
            { ItemID.IronskinPotion, 5 },
            { ItemID.RegenerationPotion, 5 },
            { ItemID.LifeCrystal, 15 },
            { ItemID.MagicMirror, 1 },
            { ItemID.SlimeCrown, 1 },
            { ItemID.GoblinBattleStandard, 1 },
            { ItemID.Chest, 10 },
            { ItemID.Furnace, 1 },
            { ItemID.IronAnvil, 1 },
            { ItemID.Wood, 999 },
            { ItemID.PiggyBank, 1 },
            { ItemID.GoldCoin, 10 }
        };

        public static void ModAdditions(Player player)
        {
            foreach (int item in vanillaItems.Keys)
            {
                player.QuickSpawnItem(item, vanillaItems[item]);
            }

            if (BeanOofsUtils.LuiafkInstalled)
            {
                Dictionary<int, int> luiafkItems = new Dictionary<int, int> // id, stack
                {
                    { BeanOofsUtils.Luiafk.GetItem("PrisonBuilder").item.type, 1 },
                    { BeanOofsUtils.Luiafk.GetItem("ArenaBuilder").item.type, 1 },
                    { BeanOofsUtils.Luiafk.GetItem("Hellevator").item.type, 1 }
                };

                foreach (int item in luiafkItems.Keys)
                {
                    player.QuickSpawnItem(item, luiafkItems[item]);
                }
            }

            if (BeanOofsUtils.MagicStorageInstalled)
            {
                Dictionary<int, int> magicStorageItems = new Dictionary<int, int> // id, stack
                {
                    { BeanOofsUtils.MagicStorage.GetItem("StorageHeart").item.type, 1 },
                    { BeanOofsUtils.MagicStorage.GetItem("CraftingAccess").item.type, 1 },
                    { BeanOofsUtils.MagicStorage.GetItem("StorageUnit").item.type, 20 }
                };

                foreach (int item in magicStorageItems.Keys)
                {
                    player.QuickSpawnItem(item, magicStorageItems[item]);
                }
            }
        }
    }

    class SkipEarlyGame : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows you to skip early game so you can get right into action!\nCraft this into a class bag to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe classBagToBase = new ModRecipe(mod);
            classBagToBase.AddRecipeGroup("BQOLMOD:Skip Early Game Class Bag");
            classBagToBase.SetResult(this);
            classBagToBase.AddRecipe();
        }
    }

    #region Vanilla

    class SkipEarlyGameMeleeBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.Starfury, 1 },
            { ItemID.EnchantedSword, 1 },
            { ItemID.TungstenHelmet, 1 },
            { ItemID.TungstenChainmail, 1 },
            { ItemID.TungstenGreaves, 1 },
            { ItemID.FeralClaws, 1 },
        };

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item,items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameMageBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.EmeraldStaff, 1 },
            { ItemID.TungstenHelmet, 1 },
            { ItemID.TungstenChainmail, 1 },
            { ItemID.TungstenGreaves, 1 },
            { ItemID.NaturesGift, 1 },
            { ItemID.LesserManaPotion, 30 },
            { ItemID.ManaCrystal, 9 },
        };

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameRangerBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.Musket, 1 },
            { ItemID.MusketBall, 999 },
            { ItemID.TungstenHelmet, 1 },
            { ItemID.TungstenChainmail, 1 },
            { ItemID.TungstenGreaves, 1 },
        };

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameSummonerBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.SlimeStaff, 1 },
            { ItemID.TungstenHelmet, 1 },
            { ItemID.TungstenChainmail, 1 },
            { ItemID.TungstenGreaves, 1 },
            { ItemID.ManaCrystal, 9 },
        };

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    #endregion

    #region Calamity

    class SkipEarlyGameCalamityMeleeBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.Starfury, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("Cnidarian").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("SeashellBoomerangMelee").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideHelm").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideBreastplate").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideLeggings").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("LuxorsGift").item.type, 1 },
            { ItemID.FeralClaws, 1 },
        };

        public override bool Autoload(ref string name)
        {
            return BeanOofsUtils.CalamityInstalled;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameCalamityMageBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { BeanOofsUtils.CalamityMod.GetItem("CoralSpout").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("FrostBolt").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideMask").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideBreastplate").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideLeggings").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("LuxorsGift").item.type, 1 },
            { ItemID.NaturesGift, 1 },
            { ItemID.LesserManaPotion, 30 },
            { ItemID.MagicPowerPotion, 5 },
            { ItemID.ManaRegenerationPotion, 5 },
            { ItemID.ManaCrystal, 9 },
        };

        public override bool Autoload(ref string name)
        {
            return BeanOofsUtils.CalamityInstalled;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameCalamityRangerBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { ItemID.Minishark, 1 },
            { ItemID.MusketBall, 999 },
            { ItemID.FrostburnArrow, 999 },
            { BeanOofsUtils.CalamityMod.GetItem("Seabow").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideVisage").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideBreastplate").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideLeggings").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("LuxorsGift").item.type, 1 },
            { ItemID.ArcheryPotion, 5 },
        };

        public override bool Autoload(ref string name)
        {
            return BeanOofsUtils.CalamityInstalled;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameCalamitySummonerBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { BeanOofsUtils.CalamityMod.GetItem("WulfrumController").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("StormjawStaff").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideHelmet").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideBreastplate").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideLeggings").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("LuxorsGift").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("WulfrumBattery").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("SpiritGenerator").item.type, 1 }, // I SPENT 2 HOURS TO GET THIS TO WORK FOR IT TO JUST BE "SpiritGenerator" INSTEAD OF "SpiritGlyph"
            { ItemID.SummoningPotion, 5 },
            { ItemID.ManaCrystal, 9 },
        };

        public override bool Autoload(ref string name)
        {
            return BeanOofsUtils.CalamityInstalled;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class SkipEarlyGameCalamityRougeBag : ModItem
    {
        private static Dictionary<int, int> items = new Dictionary<int, int> // id, stack
        {
            { BeanOofsUtils.CalamityMod.GetItem("SeashellBoomerang").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("Crystalline").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideHeadgear").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideBreastplate").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("VictideLeggings").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("LuxorsGift").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("CoinofDeceit").item.type, 1 },
            { BeanOofsUtils.CalamityMod.GetItem("RaidersTalisman").item.type, 1 },
            { ItemID.InvisibilityPotion, 5 },
        };

        public override bool Autoload(ref string name)
        {
            return BeanOofsUtils.CalamityInstalled;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right Click to open");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            foreach (int item in items.Keys)
            {
                player.QuickSpawnItem(item, items[item]);
            }
            SkipEarlyGameUtils.ModAdditions(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SkipEarlyGame>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    #endregion
}
