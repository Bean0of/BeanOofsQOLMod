using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    internal static class HEROsModExtensions
    {
        private const string permission = "BeanOofsQOLMod";

        public static void Setup(Mod mod)
        {
            Mod HEROsMod = BeanOofsUtils.HEROsMod;

            if (HEROsMod != null)
            {
                HEROsMod.Call("AddPermission", permission, permission);

                if (!Main.dedServ)
                {
                    if (ModContent.GetInstance<ConfigServer>().SpawnMeteorButtonHEROsMod)
                    {
                        HEROsMod.Call(
                            "AddSimpleButton",
                            permission,
                            mod.GetTexture("SpawnMeteorIcon"),
                            (Action)Pressed,
                            (Action<bool>)ChangePermission,
                            (Func<string>)Tooltip
                        );
                    }
                }
            }
        }

        public static string Tooltip()
        {
            return "Spawn Meteor";
        }

        public static void Pressed()
        {
            WorldGen.dropMeteor();
        }

        public static void ChangePermission(bool p) { }
    }
}
