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
            foreach (List<int> row in tileIds)
            {
                position.X = 96;

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
                switch (projectile)
                {
                    case BasicBoomerangProjectile b:
                        collisionResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        break;
                    case BasicDirectionalProjectile d:
                        collisionResults = CollisionDetector.DetectEnemyCollision(d.Hitbox, Enemies);
                        break;
                    case Bomb b:
                        collisionResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, Enemies);
                        break;
                    /* todo: check other types */
                }

                /* apply collision response */
                CollisionResolver.ResolveProjectileEnemyCollision(projectile, collisionResults);
            }

            /* enemy collisions */
            foreach (IEnemy enemy in Enemies) {
                /* check for intersection of colliders */
                List<CollisionResult<Block>> blockResults = null; 
                List<CollisionResult<IEnemy>> enemyResults = null;
                //switch (enemy)
                //{
                //    case EnemyBase e:
                        blockResults = CollisionDetector.DetectBlockCollision(enemy.collider, Blocks);
                        enemyResults = CollisionDetector.DetectEnemyCollision(enemy.collider, Enemies);
                //        break;
                    /* todo: check any other enemy types */
                //}
                /* apply collision response */
                CollisionResolver.ResolveEnemyBlockCollision(enemy, blockResults, enemyResults);
            }

            /* player collisions */
            /* check for intersection of colliders */
            foreach (Block block in Blocks)
            {

                List<CollisionResult<Block>> playerBlockCollisionResults = CollisionDetector.DetectBlockCollision(Player.Pushbox, Blocks);
                CollisionResolver.ResolvePlayerBlockCollision(Player, playerBlockCollisionResults);
            }
           
            /* apply collision response */
            

            /* TODO: add other collision checks/responses */
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

