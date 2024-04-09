using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace cse3902
{
    public class Hud
    {
        GameContent content1;
        private Sprite sprite;
        public PlayerInventory Inventory;

        public Hud(GameContent content, Level level)
        {
            // Initialize the background sprite for the HUD
            sprite = new Sprite(content.hud, new List<Rectangle>() { Constant.HudSprite }, Constant.HudOrigin, Constant.HudScaleFactor);
            content1 = content;
            Inventory = level.player.Inventory;
        }

        // Update method for the HUD
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            // You may add update logic here if needed, 
            // such as updating HUD elements based on player state or game events
        }

        // Draw method for the HUD
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background sprite for the HUD
            sprite.Draw(spriteBatch);
            Inventory.Draw(content1, spriteBatch);
        }
    }
}

