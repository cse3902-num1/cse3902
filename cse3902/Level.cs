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
        private IBlock block;

        public Level(GameContent content, IController controller)
        {
            player = new Player(content);
            player.Position = new Vector2(100, 100);

            enemies = new List<IEnemy>()
            {
                new Skeleton(content),
                new Dragon(content),
                new Gel(content),
                new Keese(content),
                new Goriya(content),
            };
            idxEnemy = 0;

            block = new Block(content);

            /* TODO: create items */
        }

        public void Update(GameTime gameTime, IController controller)
        {
            if (controller.isEnemyPressP())
            { 
                idxEnemy++;
                idxEnemy %= enemies.Count;
            }
            if (controller.isEnemyPressO())
            {
                idxEnemy--;
                if (idxEnemy < 0) idxEnemy = enemies.Count - 1;
            }

            player.Update(gameTime, controller);
            enemies[idxEnemy].Update(gameTime);
            block.Update(gameTime, controller);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            enemies[idxEnemy].Draw(spriteBatch);
            block.Draw(spriteBatch);
        }
    }
}
