using System;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public static class LevelPhysics
{
    private class PhysicsRegion
    {
        public const float SIZE = 8 * Level.TILE_SIZE; /* each region is 8x8 tiles */

        public List<Block> blocks = new List<Block>();
        public List<IEnemy> enemies = new List<IEnemy>();
        public List<IItemPickup> items = new List<IItemPickup>();
        public List<IProjectile> projectiles = new List<IProjectile>();
        public IPlayer player = null;

        public PhysicsRegion() {}

        public static PhysicsRegion WorldPositionToRegion(PhysicsRegion[,] regions, Vector2 position)
        {
            int x = (int) (position.X / SIZE);
            int y = (int) (position.Y / SIZE);
            x = Math.Clamp(x, 0, regions.GetLength(0) - 1);
            y = Math.Clamp(y, 0, regions.GetLength(1) - 1);
            return regions[x, y];
        }

        /* returns an array of regions,
           consisting of the region enclosing the current position,
           and (up to) 8 other regions around it.
           if any region would be out of bounds, it will not be in the array.
           the number of valid regions in the array is also returned. */
        public static (PhysicsRegion[], int) WorldPositionToNeighboringRegions(PhysicsRegion[,] regions, Vector2 position)
        {
            PhysicsRegion[] neighbors = new PhysicsRegion[9];

            int x = (int) (position.X / SIZE);
            int y = (int) (position.Y / SIZE);
            x = Math.Clamp(x, 0, regions.GetLength(0) - 1);
            y = Math.Clamp(y, 0, regions.GetLength(1) - 1);

            int count = 0;
            for (int rx = x - 1; rx < x + 2; rx++) {
                for (int ry = y - 1; ry < y + 2; ry++) {
                    PhysicsRegion r = GetRegionOrNull(regions, rx, ry);
                    if (r == null) continue;
                    neighbors[count] = r;
                    count++;
                }
            }
            
            return (neighbors, count);
        }

        private static PhysicsRegion GetRegionOrNull(PhysicsRegion[,] regions, int x, int y)
        {
            if (x < 0) return null;
            if (y < 0) return null;
            if (x >= regions.GetLength(0)) return null;
            if (y >= regions.GetLength(1)) return null;
            return regions[x, y];
        }

        public void Update()
        {
            /* projectile collisions */
            foreach (IProjectile projectile in projectiles) {
                /* check for intersection of colliders */
                List<CollisionResult<IEnemy>> enemyResults = new List<CollisionResult<IEnemy>>();
                List<CollisionResult<IPlayer>> playerResults = new List<CollisionResult<IPlayer>>();
                switch (projectile)
                {
                    case BasicBoomerangProjectile b:
                        enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, enemies);
                        if (player != null) playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, player);
                        break;
                    case BasicDirectionalProjectile d:
                        enemyResults = CollisionDetector.DetectEnemyCollision(d.Hitbox, enemies);
                        if (player != null) playerResults = CollisionDetector.DetectPlayerCollision(d.Hitbox, player);
                        break;
                    case Bomb b:
                        enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, enemies);
                        if (player != null) playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, player);
                        break;
                    /* todo: check other types */
                }
                CollisionResolver.ResolveProjectilePlayerCollision(projectile, playerResults);
                CollisionResolver.ResolveProjectileEnemyCollision(projectile, enemyResults);
            }

            /* TODO: remove */
            foreach (IProjectile p in projectiles) {
                List<CollisionResult<Block>> collisionResults = null;
                switch (p)
                {
                    case BasicBoomerangProjectile b:
                        collisionResults = CollisionDetector.DetectBlockCollision(b.Hitbox, blocks);
                        break;
                    case BasicDirectionalProjectile d:
                        collisionResults = CollisionDetector.DetectBlockCollision(d.Hitbox, blocks);
                        break;
                    case Bomb b:
                        collisionResults = CollisionDetector.DetectBlockCollision(b.Hitbox, blocks);
                        break;
                }
                if (collisionResults.Count > 0) {
                    p.IsDead = true;
                }
            }

            /* enemy collisions */
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.IsGhost) { continue; }
                /* check for intersection of colliders */
                List<CollisionResult<Block>> blockResults = null;
                switch (enemy)
                {
                    case EnemyBase e:
                        blockResults = CollisionDetector.DetectBlockCollision(e.Collider, blocks);
                        if (blockResults.Count > 0)
                        {
                            CollisionResolver.ResolveEnemyBlockCollision(enemy, blockResults);
                        }
                        break;
                    default:
                        throw new NotImplementedException("Unhandled enemy type " + enemy.GetType().Name);
                }
            }

            /* player-block collisions */
            if (player != null)
            {
                List<CollisionResult<Block>> playerBlockCollisionResults = CollisionDetector.DetectBlockCollision(player.Pushbox, blocks);
                CollisionResolver.ResolvePlayerBlockCollision(player, playerBlockCollisionResults);

                /* Player enemy collision */
                foreach (IEnemy enemy in enemies)
                {
                    /* check for intersection of colliders */
                    List<CollisionResult<IEnemy>> playerEnemyCollisionResults = CollisionDetector.DetectEnemyCollision(player.Pushbox, enemies);
                    CollisionResolver.ResolvePlayerEnemyCollision(player, playerEnemyCollisionResults);
                }

                /* Player ItemPickup collisions */
                List<CollisionResult<IItemPickup>> playerItemPickupResults = CollisionDetector.DetectItemPickupCollision(player.Pushbox, items);
                CollisionResolver.ResolvePlayerItemPickupCollision(player, playerItemPickupResults);
            }
        }
    }
    public static void Update(Level level)
    {
        List<Block> blocks = level.Blocks;
        List<IEnemy> enemies = level.Enemies;
        List<IItemPickup> items = level.Items;
        List<IProjectile> projectiles = level.Projectiles;
        IPlayer player = level.player;

        /* generate a grid of physics regions */
        PhysicsRegion[,] regions = new PhysicsRegion[
            (int) Math.Ceiling(Level.MAP_WIDTH * Level.TILE_SIZE / PhysicsRegion.SIZE),
            (int) Math.Ceiling(Level.MAP_HEIGHT * Level.TILE_SIZE / PhysicsRegion.SIZE)
        ]; // indexed by [x,y]
        for (int x = 0; x < regions.GetLength(0); x++) { for (int y = 0; y < regions.GetLength(1); y++) {
            regions[x, y] = new PhysicsRegion();
        }}

        /* assign every entity in the level to a region based on its position */
        /* also assign them to neighboring regions */
        foreach (Block block in blocks)
        {

            var (rlist, rcount) = PhysicsRegion.WorldPositionToNeighboringRegions(regions, block.Position);
            for (int i = 0; i < rcount; i++) rlist[i].blocks.Add(block);
        }
        foreach (IEnemy enemy in enemies)
        {
            PhysicsRegion.WorldPositionToRegion(regions, enemy.Position).enemies.Add(enemy);

        }
        foreach (IItemPickup item in items)
        {
            PhysicsRegion.WorldPositionToRegion(regions, item.Position).items.Add(item);

        }
        foreach (IProjectile projectile in projectiles)
        {
            PhysicsRegion.WorldPositionToRegion(regions, projectile.Position).projectiles.Add(projectile);

        }
        PhysicsRegion.WorldPositionToRegion(regions, player.Position).player = player;


        /* update collisions within each region */
        foreach (PhysicsRegion region in regions)
        {
            region.Update();
        }
    }
}