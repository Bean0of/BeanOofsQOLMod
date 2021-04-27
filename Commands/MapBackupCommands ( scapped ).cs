/*
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BeanOofsQOLMod.Commands
{
    class SaveMap : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "savemap";
        public override string Description => "Saves the map to a tmap file.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            string path = MapBackup.SaveMap();
            caller.Reply($"Successfully saved map to {path}", new Color(0,255,0));
        }
    }

    class LoadMap : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "loadmap";
        public override string Description => "Loads a tmap file.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            bool success = MapBackup.LoadMap();
            if (success) caller.Reply($"Successfully restored map!", new Color(0, 255, 0));
            else caller.Reply("Unable to load map.", new Color(255, 0, 0));
        }
    }
}
*/