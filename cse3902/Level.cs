using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.RoomClasses;
using cse3902.PlayerClasses;
using System;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace cse3902
{
    public class Level
    {
        private int hitstop_duration_ms = 0;
        private Stopwatch hitstop_timer = new Stopwatch();

        public const float TILE_SIZE = 16 * 3.0f;
        public enum TileType
        {
            FLOOR = 0,
            WALL = 1,
            ROOM_WALL = 2,
            LEVEL_WALL = 3,
        }
        public enum EnemyType
        {
            NONE = 0,
            DRAGON = 1,
            GEL = 2,
            KEESE = 3,
            SKELETON = 4,
            GORIYA = 5,
            OLD_MAN = 6,
        }
        public  int triforceCount = 0;
        public const int MAP_WIDTH = 32;
        public const int MAP_HEIGHT = 32;
        private TileType[,] tilemap = new TileType[MAP_WIDTH, MAP_HEIGHT];
        private EnemyType[,] enemymap = new EnemyType[MAP_WIDTH, MAP_HEIGHT];
        
        private int playerSpawnX = 0;
        private int playerSpawnY = 0;

        public List<Block> Blocks;
        public List<IItemPickup> Items;
        public List<IEnemy> Enemies;
        public List<IParticleEffect> ParticleEffects;
        public List<IProjectile> Projectiles;
        public IPlayer player;

        /* spawn queues */
        private List<IProjectile> newProjectiles;


        public  Sprite playerDot;
        public  Sprite enemyDot;
        public  Sprite triforceDot;

        /* TODO: this is a temporary function to print mapdata */
        public void PrintTileMap()
        {
            for (int x = 0; x < tilemap.GetLength(0); x++)
            {
                string line = "";
                for (int y = 0; y < tilemap.GetLength(1); y++)
                {
                    line += tilemap[x, y] switch {
                        TileType.FLOOR => '.',
                        TileType.WALL => '*',
                        TileType.ROOM_WALL => '#',
                        TileType.LEVEL_WALL => '%',
                    } + " ";
                }
                //Debug.WriteLine(line);
            }
        }

        public void PrintEnemyMap()
        {
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
                        EnemyType.SKELETON => 'S',
                        EnemyType.GORIYA => 'Y',
                        EnemyType.OLD_MAN => 'O',
                    } + " ";
                }
                //Debug.WriteLine(line);
            }
        }
       

        public Level(GameContent content)
        {
            /* initialize mapdata */
            Generate();
            PrintTileMap();
            PrintEnemyMap();
            //Debug.WriteLine("spawnx: {0} spawny: {1}", playerSpawnX, playerSpawnY);

            EventBus.HitStop += OnHitStop;
            hitstop_timer.Start();

            // throw new NotImplementedException();

            Blocks = new List<Block>();
            Items = new List<IItemPickup>();
            Enemies = new List<IEnemy>();
            ParticleEffects = new List<IParticleEffect>();
            Projectiles = new List<IProjectile>();

            newProjectiles = new List<IProjectile>();

            Build(content);

            playerDot = new Sprite(content.hud, new List<Rectangle>() {
                new Rectangle(519,126,3,3)
            });
            enemyDot = new Sprite(content.hud, new List<Rectangle>() {
                 new Rectangle(537,126,3,3)
            });
            triforceDot = new Sprite(content.hud, new List<Rectangle>() {
                 new Rectangle(528,126,3,3)
            });
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

            /* make outside of map a different kind of block */
            for (int x = 0; x < w; x++) {
                tilemap[x, 0] = TileType.LEVEL_WALL;
                tilemap[x, h - 1] = TileType.LEVEL_WALL;
            }
            for (int y = 0; y < h; y++) {
                tilemap[0, y] = TileType.LEVEL_WALL;
                tilemap[w - 1, y] = TileType.LEVEL_WALL;
            }

            // /* randomly add open spaces to map interior, at a certain spacing */
            const int HALL_GRID_SIZE = 2;
            const int MIN_HALL_LENGTH = 1 * HALL_GRID_SIZE;
            const int MAX_HALL_LENGTH = 5 * HALL_GRID_SIZE;
            const double HALL_PROBABILITY = 0.2;
            // for (int x = 1; x < w - 1; x += INTERIOR_SPACING)
            // {
            //     for (int y = 1; y < h - 1; y += INTERIOR_SPACING)
            //     {
            //         if (random.NextDouble() <= 0.75)
            //         {
            //             tilemap[x, y] = TileType.FLOOR;
            //         }
            //     }
            // }

            /* randomly generate hallways on a grid */
            for (int x = 1; x < w - 1; x += HALL_GRID_SIZE)
            {
                for (int y = 1; y < h - 1; y += HALL_GRID_SIZE)
                {
                    if (random.NextDouble() > HALL_PROBABILITY) continue;

                    /* generate hallway details */
                    int hdirection = random.Next(4);                 /* 0=left, 1=right, 2=up, 3=down */
                    int hlength = random.Next(MIN_HALL_LENGTH, MAX_HALL_LENGTH); /* number of tiles */

                    /* build hallway */
                    int hx = x;
                    int hy = y;
                    bool isdone = false;
                    while (!isdone && hlength > 0)
                    {
                        tilemap[hx, hy] = TileType.FLOOR;
                        switch (hdirection) {
                            case 0:
                                hx--;
                                if (hx < 1) isdone = true;
                                break;
                            case 1:
                                hx++;
                                if (hx >= w - 1) isdone = true;
                                break;
                            case 2:
                                hy--;
                                if (hy < 1) isdone = true;
                                break;
                            case 3:
                                hy++;
                                if (hy >= h - 1) isdone = true;
                                break;
                        }

                        hlength--;
                    }
                }
            }

            /* generate basic randomly-sized rooms */
            const double ROOM_PROBABILITY = 0.1;
            const int ROOM_SIZE_INCREMENT = HALL_GRID_SIZE; /* in units of tiles */
            const int MIN_ROOM_SIZE = 0; /* in units of the room size increment */
            const int MAX_ROOM_SIZE = 5;
            for (int x = 1; x < w - 1 - MIN_ROOM_SIZE * ROOM_SIZE_INCREMENT; x += HALL_GRID_SIZE) {
                for (int y = 1; y < h - 1 - MIN_ROOM_SIZE * ROOM_SIZE_INCREMENT; y += HALL_GRID_SIZE) {
                    if (random.NextDouble() > ROOM_PROBABILITY) continue;

                    /* generate room details */
                    int rw = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE + 1) * ROOM_SIZE_INCREMENT;
                    int rh = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE + 1) * ROOM_SIZE_INCREMENT;

                    /* build room */
                    for (int rx = x; rx < x + rw && rx < w - 1; rx++) {
                        for (int ry = y; ry < y + rh && ry < h - 1; ry++) {
                            tilemap[rx, ry] = TileType.FLOOR;
                        }
                    }

                    /* surround room with room wall tiles */
                    int leftx = Math.Max(x - 1, 1);
                    int rightx = Math.Min(x + rw, w - 1 - 1);
                    int topy = Math.Max(y - 1, 1);
                    int bottomy = Math.Min(y + rh, h - 1 - 1);
                    // for (int rx = Math.Max(0, x - 1); rx < x + rw && rx < w - 1; rx++) {
                    //     if (tilemap[rx, 0] == TileType.WALL) tilemap[rx, 0] = TileType.ROOM_WALL;
                    //     if (tilemap[rx, Math.Min(y + rh, h - 1)] == TileType.WALL) tilemap[rx, 0] = TileType.ROOM_WALL;
                    // }
                    for (int rx = leftx; rx < rightx; rx++) {
                        if (tilemap[rx, topy] == TileType.WALL) tilemap[rx, topy] = TileType.ROOM_WALL;
                        if (tilemap[rx, bottomy] == TileType.WALL) tilemap[rx, bottomy] = TileType.ROOM_WALL;
                    }
                    for (int ry = topy; ry < bottomy; ry++) {
                        if (tilemap[leftx, ry] == TileType.WALL) tilemap[leftx, ry] = TileType.ROOM_WALL;
                        if (tilemap[rightx, ry] == TileType.WALL) tilemap[rightx, ry] = TileType.ROOM_WALL;
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
            const double ENEMY_SPAWN_CHANCE = 0.05;
            const double GEL_SPAWN_WEIGHT = 0.3;
            const double KEESE_SPAWN_WEIGHT = 0.4;
            const double SKELETON_SPAWN_WEIGHT = 0.5;
            const double GORIYA_SPAWN_WEIGHT = 0.2;
            const double TOTAL_SPAWN_WEIGHT = GEL_SPAWN_WEIGHT + KEESE_SPAWN_WEIGHT + SKELETON_SPAWN_WEIGHT + GORIYA_SPAWN_WEIGHT;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (tilemap[x, y] != TileType.FLOOR) continue;

                    if (random.NextDouble() > ENEMY_SPAWN_CHANCE) continue;

                    /* determine enemy type */
                    EnemyType e = EnemyType.NONE;
                    double choice = random.NextDouble() * TOTAL_SPAWN_WEIGHT;

                    if (choice <= GEL_SPAWN_WEIGHT) {
                        e = EnemyType.GEL;
                        goto Done;
                    }
                    choice -= GEL_SPAWN_WEIGHT;

                    if (choice <= KEESE_SPAWN_WEIGHT) {
                        e = EnemyType.KEESE;
                        goto Done;
                    }
                    choice -= KEESE_SPAWN_WEIGHT;

                    if (choice <= SKELETON_SPAWN_WEIGHT) {
                        e = EnemyType.SKELETON;
                        goto Done;
                    }
                    choice -= SKELETON_SPAWN_WEIGHT;
                    if (choice <= GORIYA_SPAWN_WEIGHT)
                    {
                        e = EnemyType.GORIYA;
                        goto Done;
                    }
                    

                    Done:
                    enemymap[x, y] = e;
                }
            }

            /* spawns 2 dragons */
            const int DRAGON_SPAWN_COUNT = 2;
            for (int i = 0; i < DRAGON_SPAWN_COUNT; i++) {
                while (true) {
                    int dx = random.Next(1, w - 1);
                    int dy = random.Next(1, h - 1);
                    if (tilemap[dx, dy] != TileType.FLOOR) continue;
                    if (enemymap[dx, dy] != EnemyType.NONE) continue;
                    enemymap[dx, dy] = EnemyType.DRAGON;
                    break;
                }
            }

            /* spawn an old man */
            const int OLD_MAN_SPAWN_COUNT = 1;
            for (int i = 0; i < OLD_MAN_SPAWN_COUNT; i++) {
                while (true) {
                    int omx = random.Next(1, w - 1);
                    int omy = random.Next(1, h - 1);
                    if (tilemap[omx, omy] != TileType.FLOOR) continue;
                    if (enemymap[omx, omy] != EnemyType.NONE) continue;
                    enemymap[omx, omy] = EnemyType.OLD_MAN;
                    break;
                }
            }

            /* randomly choose a starting player location */
            while (true)
            {
                playerSpawnX = random.Next(w);
                playerSpawnY = random.Next(h);

                if (tilemap[playerSpawnX, playerSpawnY] != TileType.FLOOR) continue;
                if (enemymap[playerSpawnX, playerSpawnY] != EnemyType.NONE) continue;
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
                    TileType.FLOOR => new Block(content, BlockConstant.BLOCK_TYPE_FLOOR, pos),
                    TileType.WALL => new Block(content, BlockConstant.BLOCK_TYPE_WALL, pos),
                    TileType.ROOM_WALL => new Block(content, BlockConstant.BLOCK_TYPE_ROOM_WALL, pos),
                    TileType.LEVEL_WALL => new Block(content, BlockConstant.BLOCK_TYPE_LEVEL_WALL, pos),
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
                        EnemyType.DRAGON => new Dragon(content, this),
                        EnemyType.GEL => new Gel(content, this),
                        EnemyType.KEESE => new Keese(content, this),
                        EnemyType.SKELETON => new Skeleton(content, this),
                        EnemyType.GORIYA => new Goriya(content, this),
                        EnemyType.OLD_MAN => new OldMan(content, this),
                        _ => throw new NotImplementedException("Unhandled enemy type")
                    } ;
                    e.Position = pos;
                    Enemies.Add(e);
                }
            }

            /* spawn player */
            player = new Player(content, this);
            player.Position = new Vector2(playerSpawnX * TILE_SIZE, playerSpawnY * TILE_SIZE);
        }

        private IItemPickup RandomItem(GameContent content)
        {
            Random random = new Random();
     
            int itemType = random.Next(0, 27); 
            if (itemType == 3 && triforceCount >= 6)
            {
                // If 5 Triforce items already exist, choose a different item type
                return RandomItem(content); // Recursively call RandomItem to get a different item type
            }
            switch (itemType)
            {
                case 0: 
                    return new FiveRupiesItemPickup(content, this);
              
                case 1: 
                    return new FireItemPickUp(content, this);
                case 2:
                    return new RupyItemPickup(content, this);
                case 3:
                    triforceCount++;
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
                case 32:
                    return new HeartItemPickup(content, this);
                default: return null;
            }
        }
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (hitstop_timer.ElapsedMilliseconds < hitstop_duration_ms) {
                return;
            }
            hitstop_timer.Restart();
            hitstop_duration_ms = 0;

            /* dequeue things from spawn queue */
            Projectiles.AddRange(newProjectiles);
            newProjectiles.Clear();

            Blocks = Blocks.Where(b => !b.IsDead).ToList();
            Items = Items.Where(i => !i.IsDead).ToList();
            Enemies = Enemies.Where(e => !e.IsDead).ToList();
            ParticleEffects = ParticleEffects.Where(p => !p.IsDead).ToList();
            Projectiles = Projectiles.Where(p => !p.IsDead).ToList();

            Blocks.ForEach(b => b.Update(gameTime, controllers));
            Items.ForEach(i => i.Update(gameTime, controllers));
            // Enemies.ForEach(e => e.Update(gameTime, controllers));
            const float ENEMY_UPDATE_RANGE = Level.TILE_SIZE * 20;
            Enemies.ForEach(e => {
                if (Vector2.DistanceSquared(e.Position, player.Position) < ENEMY_UPDATE_RANGE * ENEMY_UPDATE_RANGE) e.Update(gameTime, controllers);
            });
            ParticleEffects.ForEach(p => p.Update(gameTime, controllers));
            Projectiles.ForEach(p => p.Update(gameTime, controllers));

            player.Update(gameTime, controllers);

            LevelPhysics.Update(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Blocks.ForEach(b => b.Draw(spriteBatch));
            Items.ForEach(i => i.Draw(spriteBatch));
            Projectiles.ForEach(p => p.Draw(spriteBatch));
            Enemies.ForEach(e => e.Draw(spriteBatch));
            ParticleEffects.ForEach(p => p.Draw(spriteBatch));

            player.Draw(spriteBatch);
        }

        public void OnHitStop(int duration_ms) {
            hitstop_duration_ms += duration_ms;
        }

        public void SpawnProjectile(IProjectile projectile) {
            newProjectiles.Add(projectile);
        }
    }
}
