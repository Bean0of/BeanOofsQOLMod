using BeanOofsQOLMod.Items.TravelingMerchantViewer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.NPCs
{
    class NPCChanges : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if 
                (
                    npc.boss &&
                    Main.autoSave &&
                    ModContent.GetInstance<ConfigServer>().AutoSaveAfterBoss
                )
                {
                    WorldGen.saveAndPlay();
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.TravellingMerchant)
            {
                AddToShop(ModContent.ItemType<TravelingMerchantViewer>(), shop.item, ref nextSlot);
            }
            else if (type == NPCID.DyeTrader)
            {
                if (ModContent.GetInstance<ConfigServer>().ImprovedDyeTrader == false) return;

                SwapPositions(shop.item, 0, 2);

                AddToShop(3560, shop.item, ref nextSlot);
                AddToShop(3028, shop.item, ref nextSlot);
                AddToShop(3041, shop.item, ref nextSlot);
                AddToShop(3040, shop.item, ref nextSlot);
                AddToShop(3025, shop.item, ref nextSlot);
                AddToShop(3190, shop.item, ref nextSlot);
                AddToShop(3027, shop.item, ref nextSlot);
                AddToShop(3026, shop.item, ref nextSlot);
                AddToShop(3554, shop.item, ref nextSlot);
                AddToShop(3553, shop.item, ref nextSlot);
                AddToShop(3555, shop.item, ref nextSlot);
                AddToShop(2872, shop.item, ref nextSlot);
                AddToShop(3534, shop.item, ref nextSlot);
                AddToShop(2871, shop.item, ref nextSlot);

                if (Main.hardMode)
                {
                    AddToShop(3039, shop.item, ref nextSlot);
                    AddToShop(3038, shop.item, ref nextSlot);
                    AddToShop(3598, shop.item, ref nextSlot);
                    AddToShop(3597, shop.item, ref nextSlot);
                    AddToShop(3600, shop.item, ref nextSlot);
                    AddToShop(3042, shop.item, ref nextSlot);
                    AddToShop(3533, shop.item, ref nextSlot);
                    AddToShop(3561, shop.item, ref nextSlot);

                    if (NPC.downedMechBossAny)
                    {
                        AddToShop(2883, shop.item, ref nextSlot);
                        AddToShop(2869, shop.item, ref nextSlot);
                        AddToShop(2873, shop.item, ref nextSlot);
                        AddToShop(2870, shop.item, ref nextSlot);
                    }

                    if (NPC.downedPlantBoss)
                    {
                        AddToShop(2878, shop.item, ref nextSlot);
                        AddToShop(2879, shop.item, ref nextSlot);
                        AddToShop(2884, shop.item, ref nextSlot);
                        AddToShop(2885, shop.item, ref nextSlot);
                    }

                    if (NPC.downedMartians)
                    {
                        AddToShop(2864, shop.item, ref nextSlot);
                        AddToShop(3556, shop.item, ref nextSlot);
                    }

                    if (NPC.downedMoonlord)
                    {
                        AddToShop(3024, shop.item, ref nextSlot);
                    }
                }
            }
        }

        private void AddToShop(int item, Item[] shop, ref int nextSlot)
        {
            foreach (Item i in shop) // Avoid multiple of the same thing
            {
                if (i.type == item)
                {
                    return;
                }
            }

            shop[nextSlot].SetDefaults(item);
            ++nextSlot;
        }

        private void SwapPositions(Item[] shop, int i1, int i2)
        {
            Item temp = shop[i1];
            shop[i1] = shop[i2];
            shop[i2] = temp;
        }
    }
}
