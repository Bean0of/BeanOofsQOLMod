using BeanOofsQOLMod.Items.DespawnBosses;
using BeanOofsQOLMod.Items.Die;
using CalamityMod.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.NPCs.Miner
{
    [AutoloadHead]
    class Miner : ModNPC
    {
        private static int totalHermes = WorldGen.genRand.Next(2,10);
        private static int totalLavaCharms = WorldGen.genRand.Next(2, 5);

        private static ushort currentShop = 0;

        private List<string> shops = new List<string>()
        {
            "Ores",
            "Gems",
            "Calamity Ores"
        };

        private List<string> names = new List<string>()
        {
            "Felix",
            "Joe",
            "Daniel",
            "Adolf",
            "Adam",
            "Elias",
            "Eric",
            "Erik",
            "Evan",
            "Ralph",
            "Arthur",
            "Alex",
            "Sam",
            "Kurt",
            "Edward"
        };

        public override bool Autoload(ref string name)
        {
            name = "Miner";
            return ModContent.GetInstance<ConfigServer>().Miner;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Demolitionist;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }
                
                foreach (Item item in player.inventory)
                {
                    if (item.Name.ToLower().Contains(" ore")) // ex: Copper Ore
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            return names[WorldGen.genRand.Next(0, names.Count - 1)];
        }

        public override string GetChat()
        {
            CountChestLoot();

            #region messages
            List<string> messages = new List<string>();
            messages.Add("Imagine if pickaxes had durability like in minecraft.");
            messages.Add("Do you have any mining potions?");
            messages.Add("Do you have any spelunker potions?");
            messages.Add("I wonder why I cant just craft our platinum bars into platinum coins...");
            messages.Add("I cant go underground to 2 miliseconds without hearing chchchchchchchch.");
            messages.Add("Metal detectors are OP.");
            messages.Add("Have you ever found a bunny underground before?");
            messages.Add("I regret picking this job...");
            messages.Add($"I have gotten a total of {totalHermes} hermes boots and {totalLavaCharms} lava charms today.");

            if (NPC.savedMech) messages.Add("I need to get a mechanical lens because these traps keep on almost killing me.");

            int goblin = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            int guythatfixesthings = NPC.FindFirstNPC(ModContent.NPCType<GuyThatFixesThings.GuyThatFixesThings>());

            if (goblin > 0 && guythatfixesthings > 0) messages.Add($"Why are {Main.npc[goblin].GivenName} and {Main.npc[guythatfixesthings].GivenName} ALWAYS fighting about things.");
            if (BeanOofsUtils.LuiafkInstalled)
            {
                messages.Add("I keep on forgetting to take off my dig faster.");
                messages.Add("Whoever made this cloud with big laser is killing my buisness!");
            }
            if (NPC.downedMechBossAny) messages.Add("I found this green heart shaped thing in the jungle... They taste like broccoli.");
            if (Main.hardMode)
            {
                messages.Add("I found a pink lollipop thing while I was in the hallow, I sold it because it did literally nothing.");
                messages.Add("Why do I have so many beam swords!?!?!??");
                messages.Add($"Did you really just ask me why my prices are so high? MAYBE if I didnt get {totalHermes} hermes boots and {totalLavaCharms} lava charms while looking for adamantite, prices would go down.");
                messages.Add("WHAT??? I CAN TELEPORT WITH THAT THING I SOLD?!?!");
            }
            else
            {
                messages.Add("Why do I have so many bone swords!?!?!??");
            }
            #endregion

            return messages[WorldGen.genRand.Next(0, messages.Count - 1)];
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = shops[currentShop];
            button2 = "Change Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                currentShop++;
                if (currentShop >= shops.Count)
                {
                    currentShop = 0;
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (currentShop == 0) // Ores
            {
                AddToShop(ItemID.CopperOre, shop.item, ref nextSlot);
                AddToShop(ItemID.TinOre, shop.item, ref nextSlot);
                AddToShop(ItemID.IronOre, shop.item, ref nextSlot);
                AddToShop(ItemID.LeadOre, shop.item, ref nextSlot);
                AddToShop(ItemID.SilverOre, shop.item, ref nextSlot);
                AddToShop(ItemID.TungstenOre, shop.item, ref nextSlot);
                AddToShop(ItemID.GoldOre, shop.item, ref nextSlot);
                AddToShop(ItemID.PlatinumOre, shop.item, ref nextSlot);

                if (NPC.downedBoss1)
                {
                    AddToShop(WorldGen.crimson ? ItemID.CrimtaneOre : ItemID.DemoniteOre, shop.item, ref nextSlot);
                    if (Main.bloodMoon) AddToShop(WorldGen.crimson ? ItemID.DemoniteOre : ItemID.CrimtaneOre, shop.item, ref nextSlot);
                }

                if (NPC.downedBoss2)
                {
                    AddToShop(ItemID.Meteorite, shop.item, ref nextSlot);
                    AddToShop(ItemID.Hellstone, shop.item, ref nextSlot, Item.buyPrice(silver: 50));
                    AddToShop(ItemID.Obsidian, shop.item, ref nextSlot, Item.buyPrice(silver: 25));
                }

                if (Main.hardMode)
                {
                    if (WorldGen.altarCount >= 1)
                    {
                        AddToShop(ItemID.CobaltOre, shop.item, ref nextSlot);
                        AddToShop(ItemID.PalladiumOre, shop.item, ref nextSlot);
                    }
                    if (WorldGen.altarCount >= 2)
                    {
                        AddToShop(ItemID.MythrilOre, shop.item, ref nextSlot);
                        AddToShop(ItemID.OrichalcumOre, shop.item, ref nextSlot);
                    }
                    if (WorldGen.altarCount >= 3)
                    {
                        AddToShop(ItemID.AdamantiteOre, shop.item, ref nextSlot);
                        AddToShop(ItemID.TitaniumOre, shop.item, ref nextSlot);
                    }
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    AddToShop(ItemID.ChlorophyteOre, shop.item, ref nextSlot);
                }

                if (NPC.downedMoonlord)
                {
                    AddToShop(ItemID.LunarOre, shop.item, ref nextSlot, Item.buyPrice(gold: 2));
                }
            }

            else if (currentShop == 1) // Gems
            {
                AddToShop(ItemID.Amethyst, shop.item, ref nextSlot);
                AddToShop(ItemID.Topaz, shop.item, ref nextSlot);
                AddToShop(ItemID.Sapphire, shop.item, ref nextSlot);
                AddToShop(ItemID.Emerald, shop.item, ref nextSlot);
                
                if (NPC.downedSlimeKing)
                {
                    AddToShop(ItemID.Ruby, shop.item, ref nextSlot);
                    AddToShop(ItemID.Diamond, shop.item, ref nextSlot);
                    AddToShop(ItemID.Amber, shop.item, ref nextSlot);
                }
            }

            else if (currentShop == 2) // Calamity
            {
                Mod calamity = BeanOofsUtils.CalamityMod;
                if (calamity != null)
                {
                    if (DownedModdedBossesCalamity.DownedDesertScourge)
                    {
                        AddToShop(calamity.GetItem("SeaPrism").item.type, shop.item, ref nextSlot);
                    }

                    if (DownedModdedBossesCalamity.DownedHiveOrPerforators)
                    {
                        AddToShop(calamity.GetItem("AerialiteOre").item.type, shop.item, ref nextSlot);
                    }

                    if (Main.hardMode)
                    {
                        if (DownedModdedBossesCalamity.DownedCryogen)
                        {
                            AddToShop(calamity.GetItem("CryonicOre").item.type, shop.item, ref nextSlot);
                        }

                        if (DownedModdedBossesCalamity.DownedBrimstoneElemental)
                        {
                            AddToShop(calamity.GetItem("CharredOre").item.type, shop.item, ref nextSlot);
                        }

                        if (NPC.downedPlantBoss)
                        {
                            AddToShop(calamity.GetItem("PerennialOre").item.type, shop.item, ref nextSlot);
                        }

                        if (NPC.downedGolemBoss)
                        {
                            AddToShop(calamity.GetItem("ChaoticOre").item.type, shop.item, ref nextSlot);
                        }

                        if (DownedModdedBossesCalamity.DownedDeus)
                        {
                            AddToShop(calamity.GetItem("AstralOre").item.type, shop.item, ref nextSlot);
                        }

                        if (NPC.downedMoonlord)
                        {
                            AddToShop(calamity.GetItem("ExodiumClusterOre").item.type, shop.item, ref nextSlot);

                            if (DownedModdedBossesCalamity.DownedProvidence)
                            {
                                AddToShop(calamity.GetItem("UelibloomOre").item.type, shop.item, ref nextSlot);
                            }

                            if (DownedModdedBossesCalamity.DownedYharon)
                            {
                                AddToShop(calamity.GetItem("AuricOre").item.type, shop.item, ref nextSlot);
                            }
                        }
                    }
                }
            }
        }

        private void AddToShop(int item, Item[] shop, ref int nextSlot, int? price = null)
        {
            foreach (Item i in shop) // Avoid multiple of the same thing
            {
                if (i.type == item)
                {
                    return;
                }
            }

            shop[nextSlot].SetDefaults(item);
            shop[nextSlot].shopCustomPrice = shop[nextSlot].value * 2;

            if (price != null)
            {
                shop[nextSlot].shopCustomPrice = price;
            }

            ++nextSlot;
        }

        private void CountChestLoot()
        {
            if (WorldGen.genRand.Next(1,5) == 1)
            {
                totalHermes++;
            }

            if (WorldGen.genRand.Next(1,10) == 1)
            {
                totalLavaCharms++;
            }
        }
    }
}
