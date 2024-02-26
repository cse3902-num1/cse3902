using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;

namespace cse3902
{
    public class Level
    {
        private Player player;

        private List<IEnemy> enemies;
        private int idxEnemy;
        private List<IItemPickup> items;
        private int idxItem;
        private IBlock block;

        public Level(GameContent content, IController controller)
        {
            player = new Player(content);
            player.Position = new Vector2(100, 100);

             
        }

        public void Update(GameTime gameTime, IController controller)
        {
           
            //add room update
            player.Update(gameTime, controller);
            enemies[idxEnemy].Update(gameTime);
            items[idxItem].Update(gameTime);
            block.Update(gameTime, controller);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            enemies[idxEnemy].Draw(spriteBatch);
            items[idxItem].Draw(spriteBatch);
            block.Draw(spriteBatch);
        }
    }
}
