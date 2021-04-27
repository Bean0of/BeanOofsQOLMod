/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Map;

namespace BeanOofsQOLMod
{
    internal static class MapBackup
    {
        private static Preferences File
        {
            get 
            {
                string path = Path.Combine(Main.SavePath, "Map Backups", $"{Path.GetFileNameWithoutExtension(Main.playerPathName)}_{Path.GetFileNameWithoutExtension(Main.worldPathName)}.tmap");
                return new Preferences(path);
            }
        }

        internal const int thisVersion = 1;

        public static bool LoadMap()
        {
            if (Main.dedServ) return false;

            Preferences file = File;

            int version = 1;


            if (file.Load())
            {
                file.Get("Version", ref version);

                if (version == 1)
                {
                    ushort[][] rows = new ushort[][] { };
                    file.Get("MapData", ref rows);

                    if (rows != null)
                    {
                        Main.Map.Clear();

                        int y = 0;
                        foreach (ushort[] row in rows)
                        {
                            for (ushort x = 0; x < Main.maxTilesX; x++)
                            {
                                bool revealed = false;
                                if (row.Contains(x))
                                {
                                    revealed = !revealed;
                                }
                                if (revealed)
                                {
                                    Main.Map.Update(x, y, 255);
                                }
                            }

                            y++;
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public static string SaveMap()
        {
            if (Main.dedServ) return string.Empty;

            Preferences file = File;
            file.AutoSave = false;
            file.Put("Version", thisVersion);
            SetMapData(file);
            file.Save();

            return GetPath();
        }

        private static void SetMapData(Preferences file)
        {
            List<ushort[]> rows = new List<ushort[]>();

            for (ushort y = 0; y < Main.maxTilesY; y++)
            {
                List<ushort> row = new List<ushort>();
                bool preRevealed = false;
                for (ushort x = 0; x < Main.maxTilesX; x++)
                {
                    bool revealed = Main.Map.IsRevealed(x, y) && WorldGen.InWorld(x, y);

                    if (preRevealed != revealed)
                    {
                        row.Add(x);
                        preRevealed = revealed;
                    }
                }

                rows.Add(row.ToArray());
            }

            file.Put("MapData", rows.ToArray());
        }

        private static string GetPath()
        {
            return Path.Combine(Main.SavePath, "Map Backups", $"{Path.GetFileNameWithoutExtension(Main.playerPathName)}_{Path.GetFileNameWithoutExtension(Main.worldPathName)}.tmap");
        }
    }
}
*/