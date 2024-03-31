using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace cse3902
{
    public class Hud
    {
        private Sprite sprite;
        public cse3902.Player.PlayerInventory Inventory { get; set; }

        public Hud(GameContent content)
        {
            // Initialize the background sprite for the HUD
            sprite = new Sprite(content.hud, new List<Rectangle>() { new Rectangle(256, 11, 256, 56) }, new Vector2(8, 8), 3.0f);
        }

        // Update method for the HUD
        public void Update(GameTime gameTime)
        {
            // You may add update logic here if needed, 
            // such as updating HUD elements based on player state or game events
        }

        // Draw method for the HUD
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background sprite for the HUD
            sprite.Draw(spriteBatch);

            // You can add more draw calls here to render additional HUD elements
            // For example:
            // spriteBatch.DrawString(font, "Score: " + score, new Vector2(20, 20), Color.White);
            // This draws a score value at position (20, 20) on the HUD

            // Make sure to adjust the positions and content according to your HUD design
        }
    }
}

