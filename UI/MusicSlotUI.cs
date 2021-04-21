using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace BeanOofsQOLMod.UI
{
    internal class MusicSlotUI : UIState
    {
        public VanillaItemSlotWrapper itemSlot;

        public override void OnInitialize()
        {

            itemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.TrashItem, 0.85f)
            {
                
                Left = { Pixels = 50 },
                Top = { Pixels = 270 },
                ValidItemFunc = item => item.IsAir || !item.IsAir && item.Name.Contains("Music Box")
            };

            Append(itemSlot);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Main.playerInventory) return;

            base.Draw(spriteBatch);
        }
    }
}
