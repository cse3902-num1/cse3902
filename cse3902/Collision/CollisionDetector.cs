using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using System.Linq;

namespace cse3902;

public static class CollisionDetector
{
    /*Dectect collisions between a given collider and a list of enemy objects. 
     * and return what enermy is colliding with the object*/
    public static List<CollisionResult<IEnemy>> DetectEnemyCollision(ICollider self, List<IEnemy> enemies)
    {
        List<CollisionResult<IEnemy>> results = new List<CollisionResult<IEnemy>>();
        foreach (IEnemy enemy in enemies) {
            //Ghost enemies are excluded from detection.If a collision is detected
            if (enemy.IsGhost && self.ColliderType != ColliderType.PLAYER) { continue; }
            if (self.IsColliding(enemy.collider))
            {
                Vector2 depth = self.GetOverlap(enemy.collider);
                CollisionResult<IEnemy> result = new CollisionResult<IEnemy>(depth, enemy.collider, enemy);
                results.Add(result);
            }
        }
        return results;
    }
    // detect clission between given collider and list of blocks, return what block is colliding with object
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
    /*Dectect collisions between a given collider and player. 
     * and return player object*/
    public static List<CollisionResult<IPlayer>> DetectPlayerCollision(ICollider self, IPlayer player) {
        List<CollisionResult<IPlayer>> results = new List<CollisionResult<IPlayer>>();
        if (self.IsColliding(player.Pushbox))
        {
            //calculate overlap depth 
            Vector2 depth = self.GetOverlap(player.Pushbox);
            CollisionResult<IPlayer> result = null;
            result = new CollisionResult<IPlayer>(depth, player.Pushbox, player);
            results.Add(result);
        } 
        return results;
    }
    /*Dectect collisions between a given collider and each items. 
     * and return overlap area, what collide with item and item*/
    public static List<CollisionResult<IItemPickup>> DetectItemPickupCollision(ICollider self, List<IItemPickup> items) {
        List<CollisionResult<IItemPickup>> results = new List<CollisionResult<IItemPickup>>();
        foreach (IItemPickup item in items)
        {
            if (self.IsColliding(item.Collider)) {
                Vector2 depth = self.GetOverlap(item.Collider);
                CollisionResult<IItemPickup> result = new CollisionResult<IItemPickup>(depth, item.Collider, item);
                results.Add(result);
            }
        }
        return results;
    }
}