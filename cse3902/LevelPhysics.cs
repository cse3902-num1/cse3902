using System;
using System.Collections.Generic;
using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.Projectiles;

namespace cse3902;

public static class LevelPhysics
{
    public static void Update(Level level)
    {
        List<Block> blocks = level.Blocks;
        List<IEnemy> enemies = level.Enemies;
        List<IItemPickup> items = level.Items;
        List<IProjectile> projectiles = level.Projectiles;
        IPlayer player = level.player;

        /* projectile collisions */
        foreach (IProjectile projectile in projectiles) {
            /* check for intersection of colliders */
            List<CollisionResult<IEnemy>> enemyResults = new List<CollisionResult<IEnemy>>();
            List<CollisionResult<IPlayer>> playerResults = new List<CollisionResult<IPlayer>>();
            switch (projectile)
            {
                case BasicBoomerangProjectile b:
                    enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, enemies);
                    playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, player);
                    break;
                case BasicDirectionalProjectile d:
                    enemyResults = CollisionDetector.DetectEnemyCollision(d.Hitbox, enemies);
                    playerResults = CollisionDetector.DetectPlayerCollision(d.Hitbox, player);
                    break;
                case Bomb b:
                    enemyResults = CollisionDetector.DetectEnemyCollision(b.Hitbox, enemies);
                    playerResults = CollisionDetector.DetectPlayerCollision(b.Hitbox, player);
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