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
using System;
using cse3902.Projectiles;


namespace cse3902.RoomClasses
{

    public class Room
    {
        public const int ROOM_WIDTH = 768;
        public const int ROOM_HEIGHT = 528;

        public Vector2 Position {set;get;}
        public List<IEnemy> Enemies;
        private int idxEnemy;
        public List<IItemPickup> Items;
        public List<IProjectile> Projectiles = new List<IProjectile>();
        public List<IParticleEffect> ParticleEffects = new List<IParticleEffect>();
        public List<Block> Blocks = new List<Block>();
        public List<Doors> doors = new List<Doors>();

        private GameContent content;

        private List<List<int>> tileIds;
        private List<List<int>> doorIds;
        private MapLoader ml;
        private MapLoader doorML;
        private Vector2 position = new Vector2(96,96);
        public Wall wall;
        private BoxCollider collider;
        public IPlayer Player;

        public Room(GameContent content, Vector2 position, string xmlFilePath, string doorFilePath, IPlayer player)
        {
            this.Position = position;
            this.content = content;
            this.Player = player;

            for (int i = 0; i < 84; i++)
            {
                Block b = new Block(content, 0, new Vector2(0, 0));
                Blocks.Add(b);
            }
            for (int i = 0; i < 4; i++)
            {
                Doors d = new Doors(content, 0, 0, this.Position);
                doors.Add(d);
            }
            Enemies = new List<IEnemy>() {};
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

            //Items[0].Position = new Vector2(300, 200) + position;
            //Items[1].Position = new Vector2(300,300) + position;
            //Items[2].Position = new Vector2(400, 400) + position;
            //Items[3].Position = new Vector2(300, 400) + position;
            //Items[4].Position = new Vector2(200, 200) + position;
            //Items[5].Position = new Vector2(100, 200) + position;
            //Items[18].Position = new Vector2(500, 400) + position;

            wall = new Wall(content, this, position);

            //handle loading map
            ml = new MapLoader(xmlFilePath);
            tileIds = ml.LoadMap();

            doorML = new MapLoader(doorFilePath);
            doorIds = doorML.LoadMap();

   
            Vector2 offset = new Vector2(0, 0);
            int idx = 0;
            position.Y = 96 + (3f * 8) + offset.Y;
            foreach (List<int> row in tileIds)
            {
                position.X = 96 + (3f * 8) + offset.X;

                foreach (int element in row)
                {
                    Blocks[idx].BlockIndex = element;
                    Blocks[idx].Position = position + this.Position;
                    if (element >= 10)
                    {
                        switch(element)
                        {
                            case 10: Enemies.Add(new Skeleton(content, this)); Enemies[idxEnemy].Position = position + this.Position; idxEnemy++; break;
                            case 11: Enemies.Add(new Dragon(content, this)); Enemies[idxEnemy].Position = position + this.Position; idxEnemy++; break;
                            case 12: Enemies.Add(new Keese(content, this)); Enemies[idxEnemy].Position = position + this.Position; idxEnemy++; break;
                            case 13: Enemies.Add(new Gel(content, this)); Enemies[idxEnemy].Position = position + this.Position; idxEnemy++; break;
                            case 14: Enemies.Add(new Goriya(content, this)); Enemies[idxEnemy].Position = position + this.Position; idxEnemy++; break;
                        }
                        Blocks[idx].BlockIndex = 0;
                    }

                    idx++;
                    position.X += 3f * 16;

                }
                position.Y += 3f * 16;
            }

            foreach (Block b in Blocks) {
                if (b.Collider is null) continue;
                BoxCollider c = (BoxCollider) b.Collider;
            }

            //regenerate items to avoid blocks:
            Random r = new Random();

            foreach (IItemPickup i in Items)
            {
                float x = r.NextSingle() * 576f;
                x += 90f;
                float y = r.NextSingle() * 308f;
                y += 90f;
                i.Position = new Vector2(x, y) + Position;

                bool isNotClose = false;
                while (!isNotClose)
                {
                    //get the current position of each blocks:
                    foreach (Block b in Blocks)
                    {
                        if (b.BlockIndex == 0) continue;
                        Vector2 blockPosition = b.Position;
                        isNotClose = true;
                        if ((blockPosition.X - i.Position.X) * (blockPosition.X - i.Position.X) + (blockPosition.Y - i.Position.Y) * (blockPosition.Y - i.Position.Y) < 3000f)
                        {
                            isNotClose = false;
                            //means block and this item are too close,regenerate new position for item
                            x = r.NextSingle() * 576f;
                            x += 90f;
                            y = r.NextSingle() * 308f;
                            y += 90f;
                            i.Position = new Vector2(x, y) + Position;
                            break;
                        }
                    }
                    
                }
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

        public void Update(GameTime gameTime, List<IController> controllers)
        {

            // Enemies[idxEnemy].Update(gameTime, controllers);
            Enemies.ForEach(e => e.Update(gameTime, controllers));
            Enemies = Enemies.Where(e => !e.IsDead).ToList();

            // Items[idxItem].Update(gameTime, controllers);
            Items.ForEach(i => i.Update(gameTime, controllers));
            Items = Items.Where(i => !i.IsDead).ToList();

            Projectiles.ForEach(p => p.Update(gameTime, controllers));
            Projectiles = Projectiles.Where(p => !p.IsDead).ToList();

            ParticleEffects.ForEach(p => p.Update(gameTime, controllers));
            ParticleEffects = ParticleEffects.Where(p => !p.IsDead).ToList();
            
            Blocks.ForEach(b => b.Update(gameTime, controllers));
            //wall.colliders.ForEach(w => w.IsColliding(Player.Pushbox){

            //}
            
            /* projectile collisions */
            foreach (IProjectile projectile in Projectiles) {
                /* check for intersection of colliders */
                List<CollisionResult<IEnemy>> enemyResults = new List<CollisionResult<IEnemy>>();
                List<CollisionResult<IPlayer>> playerResults = new List<CollisionResult<IPlayer>>();
                List<CollisionResult<Wall>> wallResults = new List<CollisionResult<Wall>>();
                switch (projectile)
                {
                    case BasicBoomerangProjectile b:
                        enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(b.Hitbox, wall);
                        playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, Player);
                        break;
                    case BasicDirectionalProjectile d:
                        enemyResults = CollisionDetector.DetectEnemyCollision(d.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(d.Hitbox, wall);
                        playerResults = CollisionDetector.DetectPlayerCollision(d.Hitbox, Player);
                        break;
                    case Bomb b:
                        enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(b.Hitbox, wall);
                        playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, Player);
                        break;
                    /* todo: check other types */
                }

                /* apply collision response */
                CollisionResolver.ResolveProjectileEnemyCollision(projectile, enemyResults);
                if (wallResults.Count > 0)
                {
                    CollisionResolver.ResolveProjectileWallCollision(projectile);
                }
                // Debug.WriteLine("project are: " + projectile.ToString());
                CollisionResolver.ResolveProjectilePlayerCollision(projectile, playerResults);

                
            }

            /* TODO: remove */
            foreach (IProjectile p in Projectiles) {
                List<CollisionResult<Block>> collisionResults = null;
                switch (p)
                {
                    case BasicBoomerangProjectile b:
                        collisionResults = CollisionDetector.DetectBlockCollision(b.Hitbox, Blocks);
                        break;
                    case BasicDirectionalProjectile d:
                        collisionResults = CollisionDetector.DetectBlockCollision(d.Hitbox, Blocks);
                        break;
                    case Bomb b:
                        collisionResults = CollisionDetector.DetectBlockCollision(b.Hitbox, Blocks);
                        break;
                }
                if (collisionResults.Count > 0) {
                    p.IsDead = true;
                }
            }

            /* enemy collisions */
            foreach (IEnemy enemy in Enemies)
            {
                if (enemy.IsGhost) { continue; }
                /* check for intersection of colliders */
                List<CollisionResult<Block>> blockResults = null;
                switch (enemy)
                {
                    case EnemyBase e:
                        blockResults = CollisionDetector.DetectBlockCollision(e.Collider, Blocks);
                        if (blockResults.Count > 0)
                        {
                            CollisionResolver.ResolveEnemyBlockCollision(enemy, blockResults);
                        }
                        break;
                    default:
                        throw new NotImplementedException("Unhandled enemy type " + enemy.GetType().Name);
                }
            }

            /* player collisions */
            /* check for intersection of colliders */
            List<CollisionResult<Block>> playerBlockCollisionResults = CollisionDetector.DetectBlockCollision(Player.Pushbox, Blocks);
            CollisionResolver.ResolvePlayerBlockCollision(Player, playerBlockCollisionResults);
           
            /* apply collision response */
            

            /* TODO: add other collision checks/responses */
            /* Player wall collision */
            List<CollisionResult<Wall>> playerWallCollisionResults = CollisionDetector.DetectWallCollision(Player.Pushbox, wall);
            CollisionResolver.ResolvePlayerWallCollision(Player, playerWallCollisionResults);

            /* Enemy wall collision */
            foreach (IEnemy enemy in Enemies)
            {
                /* check for intersection of colliders */
                List<CollisionResult<Wall>> enemyWallCollisionResults = null;
                switch (enemy)
                {
                    case EnemyBase e:
                        enemyWallCollisionResults = CollisionDetector.DetectWallCollision(e.Collider, wall);
                        //enemyResults = CollisionDetector.DetectEnemyCollision(e.Collider, Enemies);
                        // wallResults = CollisionDetector.DetectWallCollision(e.collider, wall);
                        if (enemyWallCollisionResults.Count > 0)
                        {
                            CollisionResolver.ResolveEnemyWallCollision(enemy, enemyWallCollisionResults);
                        }
                        break;
                        /* todo: check any other enemy types */
                        //}
                        /* apply collision response */

                }
            }

            /* Player enemy collision */
            foreach (IEnemy enemy in Enemies)
            {
                /* check for intersection of colliders */
                List<CollisionResult<IEnemy>> playerEnemyCollisionResults = CollisionDetector.DetectEnemyCollision(Player.Pushbox, Enemies);
                CollisionResolver.ResolvePlayerEnemyCollision(Player, playerEnemyCollisionResults);
            }

            /* Player ItemPickup collisions */
            List<CollisionResult<IItemPickup>> playerItemPickupResults = CollisionDetector.DetectItemPickupCollision(Player.Pushbox, Items);
            CollisionResolver.ResolvePlayerItemPickupCollision(Player, playerItemPickupResults);

            /* Player door collision */
            foreach (Doors door in doors)
            {
                List<CollisionResult<Doors>> playerDoorCollisionResults = CollisionDetector.DetectDoorCollision(Player.Pushbox, door);
                CollisionResolver.ResolvePlayerDoorCollision(Player, playerDoorCollisionResults);
            }

            /* Enemy door collision */
            foreach (IEnemy enemy in Enemies)
            {
                foreach (Doors door in doors)
                {
                    List<CollisionResult<Doors>> enemyDoorCollisionResults = CollisionDetector.DetectDoorCollision(enemy.collider, door);
                    CollisionResolver.ResolveEnemyDoorCollision(enemy, enemyDoorCollisionResults);
                }
            }

            /* player door collision */
            if (Player.Position.X < Position.X) {
                EventBus.EnteringDoor(Direction.Left);
            } else if (Player.Position.X >= Position.X + ROOM_WIDTH) {
                EventBus.EnteringDoor(Direction.Right);
            } else if (Player.Position.Y < Position.Y) {
                EventBus.EnteringDoor(Direction.Up);
            } else if (Player.Position.Y >= Position.Y + ROOM_HEIGHT) {
                EventBus.EnteringDoor(Direction.Down);
            }

            /* don't allow player to move through walls with no door */
            foreach (Doors door in doors) {
                if (door.Idx != 0) continue; /* only care about non-doors */
                Vector2 pos = Player.Position;
                switch (door.DoorType) {
                    case 0: /* top */
                    if (pos.Y < Position.Y + Constant.DoorColliderSize.X) pos.Y = Position.Y + Constant.DoorColliderSize.Y;
                    break;

                    case 1: /* left */
                    if (pos.X < Position.X + Constant.DoorColliderSize.X) pos.X = Position.X + Constant.DoorColliderSize.X;
                    break;

                    case 2: /* bottom */
                    if (pos.Y > Position.Y + ROOM_HEIGHT - Constant.DoorColliderSize.Y) pos.Y = Position.Y + ROOM_HEIGHT - Constant.DoorColliderSize.Y;
                    break;

                    case 3: /* right */
                    if (pos.X > Position.X + ROOM_WIDTH - Constant.DoorColliderSize.X) pos.X = Position.X + ROOM_WIDTH - Constant.DoorColliderSize.X;
                    break;
                }
                Player.Position = pos;
            }
            // Debug.WriteLine("the current length of items list in update:"+ Items.Count);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            wall.Draw(spriteBatch);
            doors.ForEach(d => d.Draw(spriteBatch));
            Blocks.ForEach(b => b.Draw(spriteBatch));
            Enemies.ForEach(e => e.Draw(spriteBatch));
            //[idxItem].Draw(spriteBatch);
            Items.ForEach(i => i.Draw(spriteBatch));
            Projectiles.ForEach(p => p.Draw(spriteBatch));
            ParticleEffects.ForEach(p => p.Draw(spriteBatch));
            // Debug.WriteLine("the current length of items list in Drawing :" + Items.Count);
        }
    }
}

