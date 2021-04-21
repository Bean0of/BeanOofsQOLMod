using BeanOofsQOLMod.Items.DespawnBosses;
using BeanOofsQOLMod.Items.Die;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.NPCs.GuyThatFixesThings
{
    [AutoloadHead]
    class GuyThatFixesThings : ModNPC
    {
        private List<string> names = new List<string>()
        {
            "Arback",
            "Dalek",
            "Darz",
            "Durnok",
            "Fahd",
            "Fjell",
            "Gnudar",
            "Grodax",
            "Knogs",
            "Knub",
            "Mobart",
            "Mrunok",
            "Negurk",
            "Nort",
            "Nuxatk",
            "Ragz",
            "Sarx",
            "Smador",
            "Stazen",
            "Stezom",
            "Tgerd",
            "Tkanus",
            "Trogem",
            "Xanos",
            "Xon"
        };

        private List<string> goblinExistsMessages = new List<string>()
        {
            "{0} the Goblin Tinkerer is an idiot.",
            "If you think you are stupid just think that {0} the Goblin Tinkerer exists.",
            "{0} the Goblin Tinkerer is obese.",
            "Dont fall for {0} the Goblin Tinkerer's scams."
        };

        private List<string> noGoblinMessages = new List<string>()
        {
            "I tied up a goblin underground, thank me later.",
            "If a goblin asks if you want to reforge an item dont do it, its a scam.",
            "I hope you havent untied any goblins recently."
        };

        public override bool Autoload(ref string name)
        {
            name = "GuyThatFixesThings";
            return ModContent.GetInstance<ConfigServer>().GuyThatFixesThings;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guy That Fixes Things");
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
            animationType = NPCID.GoblinTinkerer;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return NPC.FindFirstNPC(NPCID.Merchant) > 0;
        }

        public override string TownNPCName()
        {
            return names[WorldGen.genRand.Next(0, names.Count - 1)];
        }

        public override string GetChat()
        {
            int goblin = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            if (goblin > 0)
            {
                return string.Format(goblinExistsMessages[WorldGen.genRand.Next(0, goblinExistsMessages.Count - 1)], Main.npc[goblin].GivenName);
            }
            return noGoblinMessages[WorldGen.genRand.Next(0, noGoblinMessages.Count - 1)];
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Fix";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Main.playerInventory = true;
                Main.npcChatText = "";
                ModContent.GetInstance<BeanOofsQOLMod>().GuyThatFixesThingsInterface.SetState(new UI.GuyThatFixesThingsUI());
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Die>());
            ++nextSlot;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<DespawnBosses>());
            ++nextSlot;
        }
    }
}
