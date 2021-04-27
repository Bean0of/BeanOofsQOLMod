using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Items.MimicKeys
{
    class MythrilKey : ModItem
    {
		public override bool Autoload(ref string name)
		{
			return ModContent.GetInstance<ConfigServer>().MythrilKeyItem;
		}

		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(MimicSummon.tooltip);
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LightKey);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 5);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}

	class OrichalcumKey : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ModContent.GetInstance<ConfigServer>().MythrilKeyItem;
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(MimicSummon.tooltip);
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LightKey);
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 5);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
    }

	// https://github.com/tModLoader/tModLoader/blob/dfe30aae2a3ecc8f5f7bc45db2132e386ddb90f5/ExampleMod/NPCs/ExampleChestSummon.cs
	public class MimicSummon : ModPlayer
	{
		internal const string tooltip = "Place this in an empty chest to spawn a mimic";

		public int LastChest;

		// This doesn't make sense, but this is around where this check happens in Vanilla Terraria.
		public override void PreUpdateBuffs()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (player.chest == -1 && LastChest >= 0 && Main.chest[LastChest] != null)
				{
					int x2 = Main.chest[LastChest].x;
					int y2 = Main.chest[LastChest].y;
					ChestItemSummonCheck(x2, y2, mod);
				}
				LastChest = player.chest;
			}
		}

		// Allows mimic spawning in single player with autopause on
		public override void UpdateAutopause()
		{
			LastChest = player.chest;
		}

		public static bool ChestItemSummonCheck(int x, int y, Mod mod)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient || !Main.hardMode)
			{
				return false;
			}
			int num = Chest.FindChest(x, y);
			if (num < 0)
			{
				return false;
			}
			int numberKeys = 0;
			int numberOtherItems = 0;
			ushort tileType = Main.tile[Main.chest[num].x, Main.chest[num].y].type;
			int tileStyle = (int)(Main.tile[Main.chest[num].x, Main.chest[num].y].frameX / 36);
			if (TileID.Sets.BasicChest[tileType] && (tileStyle < 5 || tileStyle > 6))
			{
				for (int i = 0; i < 40; i++)
				{
					if (Main.chest[num].item[i] != null && Main.chest[num].item[i].type > ItemID.None)
					{
						if (Main.chest[num].item[i].type == ModContent.ItemType<MythrilKey>() || Main.chest[num].item[i].type == ModContent.ItemType<OrichalcumKey>())
						{
							numberKeys += Main.chest[num].item[i].stack;
						}
						else
						{
							numberOtherItems++;
						}
					}
				}
			}
			if (numberOtherItems == 0 && numberKeys == 1)
			{
				if (TileID.Sets.BasicChest[Main.tile[x, y].type])
				{
					if (Main.tile[x, y].frameX % 36 != 0)
					{
						x--;
					}
					if (Main.tile[x, y].frameY % 36 != 0)
					{
						y--;
					}
					int number = Chest.FindChest(x, y);
					for (int j = x; j <= x + 1; j++)
					{
						for (int k = y; k <= y + 1; k++)
						{
							if (TileID.Sets.BasicChest[Main.tile[j, k].type])
							{
								Main.tile[j, k].active(false);
							}
						}
					}
					for (int l = 0; l < 40; l++)
					{
						Main.chest[num].item[l] = new Item();
					}
					Chest.DestroyChest(x, y);
					NetMessage.SendData(MessageID.ChestUpdates, -1, -1, null, 1, (float)x, (float)y, 0f, number, 0, 0);
					NetMessage.SendTileSquare(-1, x, y, 3);
				}
				int npcToSpawn = NPCID.Mimic;
				int npcIndex = NPC.NewNPC(x * 16 + 16, y * 16 + 32, npcToSpawn, 0, 0f, 0f, 0f, 0f, 255);
				Main.npc[npcIndex].whoAmI = npcIndex;
				NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
				Main.npc[npcIndex].BigMimicSpawnSmoke();
			}
			return false;
		}
	}
}
