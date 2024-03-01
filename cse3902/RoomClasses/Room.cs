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
        public List<IEnemy> enemies;
        private int idxEnemy;
        public List<IItemPickup> items;
        private int idxItem;
        private List<Block> blocks = new List<Block>();
        private List<Doors> doors = new List<Doors>();
        private GameContent content;

        private List<List<int>> tileIds;
        private List<List<int>> doorIds;
        private MapLoader ml;
        private MapLoader doorML;
        private Vector2 position = new Vector2(96,96);
        private Wall wall;

        public Room(GameContent content, string xmlFilePath, string doorFilePath)
        {
            this.content = content;
            for (int i = 0; i < 84; i++)
            {
                Block b = new Block(content, 0, new Vector2(0, 0));
                blocks.Add(b);
            }
            for (int i = 0; i < 4; i++)
            {
                Doors d = new Doors(content, 0, 0);
                doors.Add(d);
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
            //doors = new Doors(content);

            //handle loading map
            ml = new MapLoader(xmlFilePath);
            tileIds = ml.LoadMap();

            doorML = new MapLoader(doorFilePath);
            doorIds = doorML.LoadMap();

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

            int type = 0;
            foreach (List<int> row in doorIds)
            {
                foreach (int element in row)
                {
                    doors[type].Idx = element;
                    doors[type].DoorType = type;
                    type++;
                }
            }

        }

        public void Update(GameTime gameTime, KeyboardController controller)
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

            enemies[idxEnemy].Update(gameTime, controller);
            items[idxItem].Update(gameTime, controller);
            blocks.ForEach(b => b.Update(gameTime, controller));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blocks.ForEach(b => b.Draw(spriteBatch));
            doors.ForEach(d => d.Draw(spriteBatch));
            wall.Draw(spriteBatch);
            enemies[idxEnemy].Draw(spriteBatch);
            items[idxItem].Draw(spriteBatch);
        }
    }
}

