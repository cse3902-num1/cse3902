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

            enemies = new List<IEnemy>()
            {
                new Skeleton(content),
                new Dragon(content),
                new Gel(content),
                new Keese(content),
                new Goriya(content),
            };
            idxEnemy = 0;

            items = new List<IItemPickup>
            {
                new PurpleRupeeItemPickup(content),
                new FireItemPickUp(content),
                new PurpleRupeeItemPickup(content),
                new YellowRupeeItemPickup(content),
                new YellowTriangleItemPickUp(content),
                new PurpleTriangleItemPickUp(content),
                new YellowDragonItemPickUp(content),
                new YellowKeyItemPickUp(content),
                new RedHeartItemPickUp(content),
                new BlueHeartItemPickUp(content),
                new RedHeartContainerItemPickUp(content),
                new FairyTailItemPickUp(content),
                new CompassItemPickUp(content),
                new ClockItemPickUp(content),
                new ArrowItemPickUp(content),
                new YellowBoomerangItemPickup(content),
                new BombItemPickup(content),
            };
            idxItem = 0;

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

            if (controller.isNextItemKeyPress())
            {
                idxItem++;
                idxItem %= items.Count;
            }

            if(controller.isPreviousItemKeyPress()) 
            {
                idxItem--;
                if (idxItem < 0) idxItem = items.Count - 1;
            }

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
