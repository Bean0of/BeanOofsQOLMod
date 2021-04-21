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

        [DefaultValue(true)]
        public bool SkipEarlyGameBag;

        [DefaultValue(true)]
        public bool ImprovedDyeTrader;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool GuyThatFixesThings;

        [DefaultValue(true)]
        public bool AutoSaveAfterBoss;
    }

    class ConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(false)]
        public bool ShowInternalItemNames;
    }
}
