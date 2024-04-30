using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using cse3902.Enemy;


namespace cse3902
{
    public class Hud
    {
        public Vector2 Position {set;get;}
        GameContent content1;
        private Sprite sprite;
        private Texture2D blackBackground;
        public PlayerInventory Inventory;
        public  Level Level;
        IEnumerable<TriforceItemPickup> triforceList;
        IEnumerable<Dragon> dragonList;

        public Hud(GameContent content, Level level)
        {
            // Initialize the background sprite for the HUD
            sprite = new Sprite(content.hud, new List<Rectangle>() { Constant.HudSprite }, Constant.HudOrigin, Constant.HudScaleFactor);
            content1 = content;
            Inventory = level.player.Inventory;
            blackBackground = content.hud;


            this.Level = level;
            dragonList = Level.Enemies.OfType<Dragon>();
            triforceList = Level.Items.OfType<TriforceItemPickup>();
        }

        // Update method for the HUD
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            //update play dot on the hud
            Level.playerDot.Position = Level.player.Position / 14f + Position + new Vector2(55, 5);
            Inventory.Update(gameTime, controllers);
        }

        // Draw method for the HUD
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the background sprite for the HUD
            spriteBatch.Draw(blackBackground, Vector2.Zero + Position, new Rectangle(1,11,95,10), Color.Black, 0f, Vector2.Zero, 14.5f, SpriteEffects.None, 0f);
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
  
            //draw play dot on the hud
            Level.playerDot.Draw(spriteBatch);
            //draw triforce locaion on the hud
            foreach (TriforceItemPickup t in triforceList) {
                Level.triforceDot.Position = t.Position / 14f + Position + new Vector2(55, 5);
                Level.triforceDot.Draw(spriteBatch);
            }
            //draw dragons locaion on the hud
            foreach (Dragon dragon in dragonList) {
                Level.enemyDot.Position = dragon.Position / 14f + Position + new Vector2(55, 5);
                Level.enemyDot.Draw(spriteBatch);
            }

            Inventory.Position = Position;
            Inventory.Draw(content1, spriteBatch,Level);

        }
    }
}

