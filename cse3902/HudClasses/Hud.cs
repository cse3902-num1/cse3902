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
        public Vector2 Position {set;get;}
        GameContent content1;
        private Sprite sprite;
        private Texture2D blackBackground;
        public PlayerInventory Inventory;

        public Hud(GameContent content, Level level)
        {
            // Initialize the background sprite for the HUD
            sprite = new Sprite(content.hud, new List<Rectangle>() { Constant.HudSprite }, Constant.HudOrigin, Constant.HudScaleFactor);
            content1 = content;
            Inventory = level.player.Inventory;
            blackBackground = content.hud;
        }

        // Update method for the HUD
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            Inventory.Update(gameTime, controllers);
        }

        // Draw method for the HUD
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background sprite for the HUD
            spriteBatch.Draw(blackBackground, Vector2.Zero + Position, new Rectangle(1,11,95,10), Color.Black, 0f, Vector2.Zero, 14.5f, SpriteEffects.None, 0f);
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
            Inventory.Position = Position;
            Inventory.Draw(content1, spriteBatch);
        }
    }
}

