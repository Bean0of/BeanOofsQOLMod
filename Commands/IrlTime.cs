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
    class IrlTime : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "irltime";
        public override string Description => "Shows the irl time";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            DateTime now = DateTime.Now;
            string time = $"Time: {now.ToShortTimeString()}";
            caller.Reply(time, new Color(255, 240, 20));
        }
    }
}
