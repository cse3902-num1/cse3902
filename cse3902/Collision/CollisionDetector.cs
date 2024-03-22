using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.WallClasses;
using Microsoft.Xna.Framework;

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
        }
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
    public static List<CollisionResult<Player>> DetectPlayerCollision(ICollider self, Player player) {
        List<CollisionResult<Player>> results = new List<CollisionResult<Player>>();
        if (self.IsColliding(player.Pushbox))
        {
            Vector2 depth = self.GetOverlap(player.Pushbox);
            CollisionResult<Player> result = new CollisionResult<Player>(depth, player.Pushbox, player);
            results.Add(result);
        } 
        return results;
    }
}