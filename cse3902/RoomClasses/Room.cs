using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.WallClasses;
using System.Diagnostics;
using cse3902.DoorClasses;
using System.Linq;


namespace cse3902.RoomClasses
{

    public class Room
    {
        public List<IEnemy> Enemies;
        private int idxEnemy;
        public List<IItemPickup> Items;
        private int idxItem;
        public List<Block> Blocks = new List<Block>();
        public List<Doors> Doors = new List<Doors>();
        private GameContent content;

        private List<List<int>> tileIds;
        private List<List<int>> doorIds;
        private MapLoader ml;
        private MapLoader doorML;
        private Vector2 position = new Vector2(96,96);
        public Wall wall;

        public IPlayer Player;

        public Room(GameContent content, string xmlFilePath, string doorFilePath, IPlayer player)
        {
            this.content = content;
            this.Player = player;

            for (int i = 0; i < 84; i++)
            {
                Block b = new Block(content, 0, new Vector2(0, 0));
                Blocks.Add(b);
            }
            for (int i = 0; i < 4; i++)
            {
                Doors d = new Doors(content, 0, 0);
                Doors.Add(d);
            }
            Enemies = new List<IEnemy>()
            {
                new Skeleton(content, this),
                new Dragon(content, this),
                new Gel(content, this),
                new Keese(content, this),
                new Goriya(content, this),
            };
            idxEnemy = 0;

            Items = new List<IItemPickup>
            {
                new FiveRupiesItemPickup(content, this),
                new FireItemPickUp(content, this),
                new RupyItemPickup(content, this),
                new TriforceItemPickup(content, this),
                new MapItemPickup(content, this),
                new KeyItemPickup(content, this),
                new HeartItemPickup(content, this),
                new HeartContainerItemPickup(content, this),
                new FairyItemPickup(content, this),
                new CompassItemPickUp(content, this),
                new ClockItemPickUp(content, this),
                new BowItemPickup(content, this),
                new YellowBoomerangItemPickup(content, this),
                new BombItemPickup(content, this),
                new LifePotionItemPickup(content, this),
                new SecondPotionItemPickup(content, this),
                new LetterItemPickup(content, this),
                new FoodItemPickup(content, this),
                new SwordItemPickup(content, this),
                new WhiteSwordItemPickup (content, this),
                new MagicalSwordItemPickup(content, this),
                new MagicalShieldItemPickup(content, this),
                new BlueCandleItemPickup(content, this),
                new RedCandleItemPickup (content, this),
                new RedRingItemPickup(content, this),
                new BlueRingItemPickup (content, this),
                new PowerBraceletItemPickup(content, this),
                new RecorderItemPickup(content, this),
                new RaftItemPickup(content, this),
                new StepLadderItemPickup(content, this),
                new MagicalRodItemPickup(content, this),
                new BookOfMagicItemPickup(content, this),
                new MagicalKeyItemPickup(content, this),
            };
            idxItem = 0;

            wall = new Wall(content, this);
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
                    Blocks[idx].BlockIndex = element;
                    Blocks[idx].Position = position;

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
                    Doors[type].Idx = element;
                    Doors[type].DoorType = type;
                    type++;
                }
            }

        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isEnemyPressP()))
            {
                idxEnemy++;
                idxEnemy %= Enemies.Count;
            }
            if (controllers.Any(c => c.isEnemyPressO()))
            {
                idxEnemy--;
                if (idxEnemy < 0) idxEnemy = Enemies.Count - 1;
            }

            if (controllers.Any(c => c.isNextItemKeyPress()))
            {
                idxItem++;
                idxItem %= Items.Count;
            }

            if (controllers.Any(c => c.isPreviousItemKeyPress()))
            {
                idxItem--;
                if (idxItem < 0) idxItem = Items.Count - 1;
            }

            Enemies[idxEnemy].Update(gameTime, controllers);
            Items[idxItem].Update(gameTime, controllers);
            Blocks.ForEach(b => b.Update(gameTime, controllers));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Blocks.ForEach(b => b.Draw(spriteBatch));
            Doors.ForEach(d => d.Draw(spriteBatch));
            wall.Draw(spriteBatch);
            Enemies[idxEnemy].Draw(spriteBatch);
            Items[idxItem].Draw(spriteBatch);
        }
    }
}

