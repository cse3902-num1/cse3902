using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;

namespace cse3902;

public static class CollisionDetector
{
    public static List<CollisionResult<IEnemy>> DetectEnemyCollision(ICollider self, List<IEnemy> enemies)
    {
        foreach (IEnemy enemy in enemies) {
            /* TODO: get the overlap between the "self" collider and the enemy's collider, and use it to construct a new CollisionResult instance */
            /* TODO: add the collision result instance to a list */
        }
        /* TODO: return the list */
        return new List<CollisionResult<IEnemy>>();
    }

    public static List<CollisionResult<Block>> DetectBlockCollision(ICollider self, List<Block> blocks)
    {
        return new List<CollisionResult<Block>>();
    }

    /* TODO: add other collision detection methods */
}