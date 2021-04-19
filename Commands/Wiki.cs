using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Commands
{
    class Wiki : ModCommand
    {
        private Dictionary<string, string> wikis = new Dictionary<string, string>()
        {
            { "vanilla", "https://terraria.fandom.com/wiki/Terraria_Wiki" },
            { "calamity", "https://calamitymod.fandom.com/wiki/Calamity_Mod_Wiki" },
            { "thorium", "https://thoriummod.fandom.com/wiki/Thorium_Mod_Wiki" },
            { "fargosouls", "https://terrariamods.fandom.com/wiki/Fargo%27s_Mod" },
        };

        public override CommandType Type => CommandType.Chat;
        public override string Command => "wiki";
        public override string Description => "/wiki for vanilla or /wiki [calamity/thorium/fargosouls] for modded";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            string wikiToUse = null;
            if (args.Length > 0)
            {
                wikiToUse = args[0];
            }
            else
            {
                wikiToUse = "vanilla";
            }

            if (wikiToUse != null)
            {
                string wikiUrl;

                if (wikis.TryGetValue(wikiToUse, out wikiUrl))
                {
                    System.Diagnostics.Process.Start(wikiUrl);
                }
            }
        }
    }
}
