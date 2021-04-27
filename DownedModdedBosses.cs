namespace BeanOofsQOLMod
{
    internal static class DownedModdedBossesCalamity
    {
        public static bool DownedDesertScourge
        {
            get { return CalamityMod.World.CalamityWorld.downedDesertScourge; }
        }

        public static bool DownedPerforators
        {
            get { return CalamityMod.World.CalamityWorld.downedPerforator; }
        }

        public static bool DownedHiveMind
        {
            get { return CalamityMod.World.CalamityWorld.downedHiveMind; }
        }

        public static bool DownedHiveOrPerforators
        {
            get { return DownedHiveMind || DownedPerforators; }
        }

        public static bool DownedCryogen
        {
            get { return CalamityMod.World.CalamityWorld.downedCryogen; }
        }

        public static bool DownedBrimstoneElemental
        {
            get { return CalamityMod.World.CalamityWorld.downedBrimstoneElemental; }
        }

        public static bool DownedDeus
        {
            get { return CalamityMod.World.CalamityWorld.downedStarGod; }
        }

        public static bool DownedProvidence
        {
            get { return CalamityMod.World.CalamityWorld.downedProvidence; }
        }

        public static bool DownedYharon
        {
            get { return CalamityMod.World.CalamityWorld.downedYharon && CalamityMod.World.CalamityWorld.buffedEclipse; }
        }
    }
}
