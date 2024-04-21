using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.RoomClasses;
using cse3902.PlayerClasses;
using System;
using cse3902.DoorClasses;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace cse3902
{
    public class Level
    {
        public const float TILE_SIZE = 16 * 3.0f;
        public enum TileType
        {
            FLOOR = 0,
            WALL = 1,
        }
        public enum EnemyType
        {
            NONE = 0,
            DRAGON = 1,
            GEL = 2,
            KEESE = 3,
            SKELETON = 4,
        }
       
        public const int MAP_WIDTH = 64;
        public const int MAP_HEIGHT = 64;
        private TileType[,] tilemap = new TileType[MAP_WIDTH, MAP_HEIGHT];
        private EnemyType[,] enemymap = new EnemyType[MAP_WIDTH, MAP_HEIGHT];
        
        private int playerSpawnX = 0;
        private int playerSpawnY = 0;

        public List<Block> Blocks;
        public List<IItemPickup> Items;
        public List<IEnemy> Enemies;
        public List<IParticleEffect> ParticleEffects;
        public List<IProjectile> Projectiles;
        public Player player;

        /* TODO: this is a temporary function to print mapdata */
        public void PrintTileMap()
        {
            // for (int x = 0; x < tilemap.GetLength(0); x++)
            // {
            //     string[] row = Enumerable.Range(0, tilemap.GetLength(1))
            //         .Select(y => tilemap[x, y])
            //         .Select(t => {
            //             switch (t) {
            //                 case TileType.FLOOR: return ".";
            //                 case TileType.WALL: return "#";
            //                 default: throw new NotImplementedException("Unhandled TileType type");
            //             }
            //         })
            //         .ToArray();
                
            //     Debug.WriteLine(string.Join(" ", row));
            // }

            for (int x = 0; x < tilemap.GetLength(0); x++)
            {
                string line = "";
                for (int y = 0; y < tilemap.GetLength(1); y++)
                {
                    line += tilemap[x, y] switch {
                        TileType.FLOOR => '.',
                        TileType.WALL => '#',
                    } + " ";
                }
                Debug.WriteLine(line);
            }
        }

        public void PrintEnemyMap()
        {
            // for (int x = 0; x < enemymap.GetLength(0); x++)
            // {
            //     string[] row = Enumerable.Range(0, enemymap.GetLength(1))
            //         .Select(y => enemymap[x, y])
            //         .Select(e => {
            //             switch (e) {
            //                 case EnemyType.NONE: return ".";
            //                 case EnemyType.DRAGON: return "D";
            //                 case EnemyType.GEL: return "G";
            //                 case EnemyType.KEESE: return "K";
            //                 case EnemyType.SKELETON: return "S";
            //                 default: throw new NotImplementedException("Unhandled EnemyType type");
            //             }
            //         })
            //         .ToArray();
                
            //     Debug.WriteLine(string.Join(" ", row));
            // }

            for (int x = 0; x < enemymap.GetLength(0); x++)
            {
                string line = "";
                for (int y = 0; y < enemymap.GetLength(1); y++)
                {
                    line += enemymap[x, y] switch {
                        EnemyType.NONE => '.',
                        EnemyType.DRAGON => 'D',
                        EnemyType.GEL => 'G',
                        EnemyType.KEESE => 'K',
                        EnemyType.SKELETON => 'S'
                    } + " ";
                }
                Debug.WriteLine(line);
            }
        }
       

        public Level(GameContent content)
        {
            /* initialize mapdata */
            Generate();
            PrintTileMap();
            PrintEnemyMap();
            Debug.WriteLine("spawnx: {0} spawny: {1}", playerSpawnX, playerSpawnY);

            // throw new NotImplementedException();

            Blocks = new List<Block>();
            Items = new List<IItemPickup>();
            Enemies = new List<IEnemy>();
            ParticleEffects = new List<IParticleEffect>();
            Projectiles = new List<IProjectile>();

            Build(content);
        }

        private void Generate()
        {
            Random random = new Random();
            int w = tilemap.GetLength(0);
            int h = tilemap.GetLength(1);

            /* fill map with walls */
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    tilemap[x, y] = TileType.WALL;
                }
            }

            /* randomly add open spaces to map interior */
            for (int x = 1; x < w - 1; x++)
            {
                for (int y = 1; y < h - 1; y++)
                {
                    if (random.NextDouble() <= 0.75)
                    {
                        tilemap[x, y] = TileType.FLOOR;
                    }
                }
            }

            /* fill enemy map with none */
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    enemymap[x, y] = EnemyType.NONE;
                }
            }

            /* randomly add enemies to open areas */
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (tilemap[x, y] != TileType.FLOOR) continue;

                    if (random.NextDouble() < 0.25)
                    {
                        Array types = Enum.GetValues(typeof(EnemyType));
                        enemymap[x, y] = (EnemyType) types.GetValue(random.Next(types.Length));
                    }
                }
            }

            /* randomly choose a starting player location */
            while (true)
            {
                playerSpawnX = random.Next(w);
                playerSpawnY = random.Next(h);

                if (tilemap[playerSpawnX, playerSpawnY] != TileType.FLOOR) continue;
                if (enemymap[playerSpawnX, playerSpawnY] != EnemyType.NONE) continue;
                enemymap[playerSpawnX, playerSpawnY] = EnemyType.DRAGON;
                break;
            }

        }

        public void Build(GameContent content)
        {
            int w = tilemap.GetLength(0);
            int h = tilemap.GetLength(1);

            /* spawn blocks */
            for (int x = 0; x < w; x++) { for (int y = 0; y < h; y++)
            {
                Vector2 pos = new Vector2(x * TILE_SIZE, y * TILE_SIZE);
                Block b = tilemap[x, y] switch {
                    TileType.FLOOR => new Block(content, BlockConstant.BLOCK_TYPE_0, pos),
                    TileType.WALL => new Block(content, BlockConstant.BLOCK_TYPE_1, pos),
                };
                Blocks.Add(b);
            }}

            /* spawn items */
            Random random = new Random();
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    if (tilemap[x, y] == TileType.FLOOR && random.NextDouble() < 0.1) // 10% chance to spawn an item on a floor tile
                    {
                        Vector2 pos = new Vector2(x * TILE_SIZE, y * TILE_SIZE);
                        IItemPickup item = RandomItem(content); // This method would determine which item to create
                        item.Position = pos;
                        Items.Add(item);
                    }
                }
            }

            /* spawn enemies */
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (enemymap[x, y] == EnemyType.NONE) continue;
                    Vector2 pos = new Vector2(x * TILE_SIZE, y * TILE_SIZE);
                    IEnemy e = enemymap[x, y] switch
                    {
                        EnemyType.DRAGON => new Dragon(content,this),
                        EnemyType.GEL => new Gel(content,this),
                        EnemyType.KEESE => new Keese(content,this),
                        EnemyType.SKELETON => new Skeleton(content, this),
                        _ => throw new NotImplementedException("Unhandled enemy type")
                    };
                    e.Position = pos;
                    Enemies.Add(e);
                }
            }


                /* spawn player */
                player = new Player(content);
            player.Position = new Vector2(playerSpawnX * TILE_SIZE, playerSpawnY * TILE_SIZE);
        }

        private IItemPickup RandomItem(GameContent content)
        {
            Random random = new Random();
            // This is a simplified example, you would implement your logic based on item rarity or other criteria
            int itemType = random.Next(0, 27); // assuming you have 27 item types as in your provided list
            switch (itemType)
            {
                case 0: 
                    return new FiveRupiesItemPickup(content, this);
              
                case 1: 
                    return new FireItemPickUp(content, this);
                case 2:
                    return new RupyItemPickup(content, this);
                case 3:
                    return new TriforceItemPickup(content, this);
                case 4:
                    return new MapItemPickup(content, this);
                case 5:
                    return new KeyItemPickup(content, this);
                case 6:
                    return new HeartItemPickup(content, this);
                case 7:
                    return new HeartContainerItemPickup(content, this);
                case 8:
                    return new FairyItemPickup(content, this);
                case 9:
                    return new CompassItemPickUp(content, this);
                case 10:
                    return new ClockItemPickUp(content, this);
                case 11:
                    return new BowItemPickup(content, this);
                case 12:
                    return new BombItemPickup(content, this);
                case 13:
                    return new LifePotionItemPickup(content, this);
                case 14:
                    return new SecondPotionItemPickup(content, this);
                case 15:
                    return new LetterItemPickup(content, this);
                case 16:
                    return new FoodItemPickup(content, this);
                case 17:
                    return new SwordItemPickup(content, this);
                case 18:
                    return new WhiteSwordItemPickup(content, this);
                case 19:
                    return new MagicalSwordItemPickup(content, this);
                case 20:
                    return new MagicalShieldItemPickup(content, this);
                case 21:
                    return new BlueCandleItemPickup(content, this);
                case 22:
                    return new RedCandleItemPickup(content, this);
                case 23:
                    return new RedRingItemPickup(content, this);
                case 24:
                    return new BlueRingItemPickup(content, this);
                case 25:
                    return new PowerBraceletItemPickup(content, this);
                case 26:
                    return new RecorderItemPickup(content, this);
                case 27:
                    return new RaftItemPickup(content, this);
                case 28:
                    return new StepLadderItemPickup(content, this);
                case 29:
                    return new MagicalRodItemPickup(content, this);
                case 30:
                    return new BookOfMagicItemPickup(content, this);
                case 31: 
                    return new MagicalKeyItemPickup(content, this);
                default: return null;
            }
        }
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            // Blocks = Blocks.Where(b => !b.IsDead).ToList();
            Items = Items.Where(i => !i.IsDead).ToList();
            Enemies = Enemies.Where(e => !e.IsDead).ToList();
            ParticleEffects = ParticleEffects.Where(p => !p.IsDead).ToList();
            Projectiles = Projectiles.Where(p => !p.IsDead).ToList();

            Blocks.ForEach(b => b.Update(gameTime, controllers));
            Items.ForEach(i => i.Update(gameTime, controllers));
            Enemies.ForEach(e => e.Update(gameTime, controllers));
            ParticleEffects.ForEach(p => p.Update(gameTime, controllers));
            Projectiles.ForEach(p => p.Update(gameTime, controllers));

            player.Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Blocks.ForEach(b => b.Draw(spriteBatch));
            Items.ForEach(i => i.Draw(spriteBatch));
            Enemies.ForEach(e => e.Draw(spriteBatch));
            ParticleEffects.ForEach(p => p.Draw(spriteBatch));
            Projectiles.ForEach(p => p.Draw(spriteBatch));

            player.Draw(spriteBatch);
        }
    }
}
