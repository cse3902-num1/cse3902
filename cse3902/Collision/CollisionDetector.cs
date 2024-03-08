using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.WallClasses;
using Microsoft.Xna.Framework;
using static System.Reflection.Metadata.BlobBuilder;

namespace cse3902;

public static class CollisionDetector
{
    public static List<CollisionResult<IEnemy>> DetectEnemyCollision(ICollider self, List<IEnemy> enemies)
    {
        List<CollisionResult<IEnemy>> results = new List<CollisionResult<IEnemy>>();
        foreach (IEnemy enemy in enemies) {
            if (self.IsColliding(enemy.collider))
            {
                Vector2 depth = self.GetOverlap(enemy.collider);
                CollisionResult<IEnemy> result = new CollisionResult<IEnemy>(depth, enemy.collider, enemy);
                results.Add(result);
            }
            /* TODO: get the overlap between the "self" collider and the enemy's collider, and use it to construct a new CollisionResult instance */
            /* TODO: add the collision result instance to a list */
        }
        /* TODO: return the list */
        return results;
    }

    public static List<CollisionResult<Block>> DetectBlockCollision(ICollider self, List<Block> blocks)
    {
        List<CollisionResult<Block>> results = new List<CollisionResult<Block>>();
        foreach (Block b in blocks) {
            if (self.IsColliding(b.Collider)) {
                Vector2 depth = self.GetOverlap(b.Collider);
                CollisionResult<Block> result = new CollisionResult<Block>(depth, b.Collider, b);
                results.Add(result);
            }
        }
        return results;
    }

    /* TODO: add other collision detection methods */
    public static List<CollisionResult<Wall>> DetectWallCollision(ICollider self, Wall wall)
    {
        List<CollisionResult<Wall>> results = new List<CollisionResult<Wall>>();
        foreach (BoxCollider w in wall.colliders)
        {
          
                if (self.IsColliding(w))
                {
                    Vector2 depth = self.GetOverlap(w);
                    CollisionResult<Wall> result = new CollisionResult<Wall>(depth, w,wall);
                    results.Add(result);
                }
            
        }
        return results;
    }
    
}