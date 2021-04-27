using Terraria.ModLoader;

namespace BeanOofsQOLMod
{
    internal static class FKBossBarSupport
    {
        public static void SetupBars()
        {
            Mod yabhb = BeanOofsUtils.FKBossHealthBar;
            if (yabhb != null)
            {
                #region Calamity
                if (BeanOofsUtils.CalamityInstalled && ModContent.GetInstance<ConfigClient>().YetAnotherBossHealthBarCalamitySupport)
                {
                    #region SCal
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("CalamitasRun").npc.type);
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("CalamitasRun2").npc.type);
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("SupremeCataclysm").npc.type);
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("SupremeCatastrophe").npc.type);
                    yabhb.Call("RegisterHealthBarMultiMini", BeanOofsUtils.CalamityMod.GetNPC("SCalWormHeart").npc.type);
                    #endregion

                    #region Providence
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("ProvSpawnDefense").npc.type);
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("ProvSpawnOffense").npc.type);
                    yabhb.Call("RegisterHealthBarMini", BeanOofsUtils.CalamityMod.GetNPC("ProvSpawnHealer").npc.type);
                    #endregion
                }
                #endregion
            }
        }
    }
}
