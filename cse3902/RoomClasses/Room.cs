using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using System.Numerics;
using System.Diagnostics;

namespace cse3902.RoomClasses
{

    public class Room
    {
        public List<IEnemy> enemies;
        private int idxEnemy;
        public List<IItemPickup> items;
        private int idxItem;
        private IBlock block;
        List<List<int>> TileIds;
        MapLoader ml;

        public Room(GameContent content, IController controller, string xmlFilePath)
        {
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
                new FiveRupiesItemPickup(content),
                new FireItemPickUp(content),
                new RupyItemPickup(content),
                new TriforceItemPickup(content),
                new MapItemPickup(content),
                new KeyItemPickup(content),
                new HeartItemPickup(content),
                new HeartContainerItemPickup(content),
                new FairyItemPickup(content),
                new CompassItemPickUp(content),
                new ClockItemPickUp(content),
                new BowItemPickup(content),
                new YellowBoomerangItemPickup(content),
                new BombItemPickup(content),
                new LifePotionItemPickup(content),
                new SecondPotionItemPickup(content),
                new LetterItemPickup(content),
                new FoodItemPickup(content),
                new SwordItemPickup(content),
                new WhiteSwordItemPickup (content),
                new MagicalSwordItemPickup(content),
                new MagicalShieldItemPickup(content),
                new BlueCandleItemPickup(content),
                new RedCandleItemPickup (content),
                new RedRingItemPickup(content),
                new BlueRingItemPickup (content),
                new PowerBraceletItemPickup(content),
                new RecorderItemPickup(content),
                new RaftItemPickup(content),
                new StepLadderItemPickup(content),
                new MagicalRodItemPickup(content),
                new BookOfMagicItemPickup(content),
                new MagicalKeyItemPickup(content),
            };
            idxItem = 0;

          //  block = new Block(content);

            //handle loading map
            ml = new MapLoader(xmlFilePath);
            TileIds = ml.LoadMap();

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

            if (controller.isPreviousItemKeyPress())
            {
                idxItem--;
                if (idxItem < 0) idxItem = items.Count - 1;
            }


            enemies[idxEnemy].Update(gameTime,controller);
            items[idxItem].Update(gameTime, controller);
            block.Update(gameTime, controller);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            enemies[idxEnemy].Draw(spriteBatch);
            items[idxItem].Draw(spriteBatch);
            block.Draw(spriteBatch);
        }


    }
}

