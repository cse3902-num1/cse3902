using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;

namespace cse3902;

public static class CollisionResolver
{
    public static void ResolveProjectileEnemyCollision(IProjectile projectile, List<CollisionResult<IEnemy>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        /* call something like OnHit() on the projectile, passing in the enemy (or list of enemies? or the collision result?) */
    }

    public static void ResolvePlayerBlockCollision(IPlayer player, List<CollisionResult<Block>> results)
    {
        /* TODO: get collision result with largest area and use it to calculate how much to move the player back */
    }
}