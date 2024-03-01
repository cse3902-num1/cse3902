using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.WallClasses;
using System.Diagnostics;
using cse3902.DoorClasses;


namespace cse3902.RoomClasses
{

    public class Room
    {
        private List<IEnemy> enemies;
        private int idxEnemy;
        private List<IItemPickup> items;
        private int idxItem;
        private List<Block> blocks = new List<Block>();
        private GameContent content;

        private List<List<int>> tileIds;
        private MapLoader ml;
        private Vector2 position = new Vector2(96,96);
        private Wall wall;
        private Doors doors;

        public Room(GameContent content, IController controller, string xmlFilePath)
        {
            this.content = content;
            for (int i = 0; i < 84; i++)
            {
                Block b = new Block(content, 0, new Vector2(0, 0));
                blocks.Add(b);
            }
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

            wall = new Wall(content);
            doors = new Doors(content);

            //handle loading map
            ml = new MapLoader(xmlFilePath);
            tileIds = ml.LoadMap();
            Debug.WriteLine(tileIds[0][0]);

            int idx = 0;
            foreach (List<int> row in tileIds)
            {
                position.X = 96;

                foreach (int element in row)
                {
                    blocks[idx].BlockIndex = element;
                    blocks[idx].Position = position;

                    idx++;
                    position.X += 48;

                }
                position.Y += 48;
            }

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


            enemies[idxEnemy].Update(gameTime);
            items[idxItem].Update(gameTime);
           


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block block in blocks)
            {
                block.Draw(spriteBatch);
            }
            doors.Draw(spriteBatch);
            wall.Draw(spriteBatch);
            enemies[idxEnemy].Draw(spriteBatch);
            items[idxItem].Draw(spriteBatch);

            
           
        }


    }
}

