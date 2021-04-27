using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace BeanOofsQOLMod
{
    class ConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(1f)]
        [Increment(0.1f)]
        [DrawTicks]
        [Range(0.1f, 1f)]
        public float ReforgePriceMultiplier;

        [DefaultValue(true)]
        public bool SkipEarlyGameBag;

        [DefaultValue(true)]
        public bool ImprovedDyeTrader;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool GuyThatFixesThings;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool Miner;

        [DefaultValue(true)]
        public bool AutoSaveAfterBoss;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool SpawnMeteorButtonHEROsMod;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool DespawnBossesItem;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool DieItem;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool MerchantViewerItem;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool MythrilKeyItem;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool UnobtainableItems;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool SimpleAuricTeslaRecipe;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool AncientManipulatorRecipe;
    }

    class ConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(false)]
        public bool ShowInternalItemNames;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool YetAnotherBossHealthBarCalamitySupport;

        [DefaultValue(true)]
        public bool MusicBoxWorksInVanity;

        [DefaultValue(true)]
        public bool InfoAccessoryWorksInVanity;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool IrlTimeCommand;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool WikiCommand;
    }
}
