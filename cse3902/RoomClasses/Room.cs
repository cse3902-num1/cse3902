﻿using System.Collections.Generic;
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
        public List<IEnemy> Enemies;
        private int idxEnemy;
        public List<IItemPickup> Items;
        private int idxItem;
        public List<IProjectile> Projectiles = new List<IProjectile>();
        public List<IParticleEffect> ParticleEffects = new List<IParticleEffect>();
        public List<Block> Blocks = new List<Block>();
        public List<Doors> Doors = new List<Doors>();

        private GameContent content;

        private List<List<int>> tileIds;
        private List<List<int>> doorIds;
        private MapLoader ml;
        private MapLoader doorML;
        private Vector2 position = new Vector2(96,96);
        public Wall wall;
        private BoxCollider collider;
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
            position.Y = 96 + (3f * 8);
            foreach (List<int> row in tileIds)
            {
                position.X = 96 + (3f * 8);

                foreach (int element in row)
                {
                    Blocks[idx].BlockIndex = element;
                    Blocks[idx].Position = position;
                    if (element >= 10)
                    {
                        switch(element)
                        {
                            case 10: Enemies.Add(new Skeleton(content, this)); Enemies[idxEnemy].Position = position; idxEnemy++; break;
                            case 11: Enemies.Add(new Dragon(content, this)); Enemies[idxEnemy].Position = position; idxEnemy++; break;
                            case 12: Enemies.Add(new Keese(content, this)); Enemies[idxEnemy].Position = position; idxEnemy++; break;
                            case 13: Enemies.Add(new Gel(content, this)); Enemies[idxEnemy].Position = position; idxEnemy++; break;
                            case 14: Enemies.Add(new Goriya(content, this)); Enemies[idxEnemy].Position = position; idxEnemy++; break;
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
                Debug.WriteLine("block: " + c.Position + " " + c.Size);
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

            // Enemies[idxEnemy].Update(gameTime, controllers);
            Enemies.ForEach(e => e.Update(gameTime, controllers));
            Enemies = Enemies.Where(e => !e.IsDead).ToList();

            Items[idxItem].Update(gameTime, controllers);
            // Items = Items.Where(e => !e.IsDead).ToList();

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
                List<CollisionResult<IEnemy>> collisionResults = null;
                List<CollisionResult<Wall>> wallResults = null;
                switch (projectile)
                {
                    case BasicBoomerangProjectile b:
                        collisionResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(b.Hitbox, wall);
                        break;
                    case BasicDirectionalProjectile d:
                        collisionResults = CollisionDetector.DetectEnemyCollision(d.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(d.Hitbox, wall);
                        break;
                    case Bomb b:
                        collisionResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        wallResults = CollisionDetector.DetectWallCollision(b.Hitbox, wall);
                        break;
                    /* todo: check other types */
                }

                /* apply collision response */
                CollisionResolver.ResolveProjectileEnemyCollision(projectile, collisionResults);
                if (wallResults.Count > 0)
                {
                    CollisionResolver.ResolveProjectileWallCollision(projectile);
                }
                
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
                /* check for intersection of colliders */
                List<CollisionResult<Block>> blockResults = null;
                switch (enemy)
                {
                    case EnemyBase e:
                        blockResults = CollisionDetector.DetectBlockCollision(e.Collider, Blocks);
                        if (blockResults.Count > 0)
                        {
                            CollisionResolver.ResolveEnemyBlockCollision(enemy, blockResults);
                            Debug.WriteLine("enemy: " + blockResults.Count + " ");
                        }
                        break;
                    default:
                        throw new NotImplementedException("Unhandled enemy type " + enemy.GetType().Name);
                }
            }

            /* player collisions */
            /* check for intersection of colliders */
            List<CollisionResult<Block>> playerBlockCollisionResults = CollisionDetector.DetectBlockCollision(Player.Pushbox, Blocks);
            if (playerBlockCollisionResults.Count > 0) {
                Debug.WriteLine(string.Format("{0} | {1} {2} | {3} {4}", playerBlockCollisionResults.Count,
                    Player.Pushbox.Position, ((BoxCollider) Player.Pushbox).Size,
                    playerBlockCollisionResults[0].Collider.Position, ((BoxCollider) playerBlockCollisionResults[0].Collider).Size
                ));
            }
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
                            Debug.WriteLine("enemy: " + enemyWallCollisionResults.Count + " ");
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


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            wall.Draw(spriteBatch);
            Doors.ForEach(d => d.Draw(spriteBatch));
            Blocks.ForEach(b => b.Draw(spriteBatch));
            Enemies.ForEach(e => e.Draw(spriteBatch));
            Items[idxItem].Draw(spriteBatch);
            Projectiles.ForEach(p => p.Draw(spriteBatch));
            ParticleEffects.ForEach(p => p.Draw(spriteBatch));
        }
    }
}

