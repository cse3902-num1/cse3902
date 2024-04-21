using System.Collections.Generic;
using cse3902.DoorClasses;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public static class CollisionDetector
{
    public static List<CollisionResult<IEnemy>> DetectEnemyCollision(ICollider self, List<IEnemy> enemies)
    {
        List<CollisionResult<IEnemy>> results = new List<CollisionResult<IEnemy>>();
        foreach (IEnemy enemy in enemies) {
            if (enemy.IsGhost) { continue; }
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

    public static List<CollisionResult<IPlayer>> DetectPlayerCollision(ICollider self, IPlayer player) {
        List<CollisionResult<IPlayer>> results = new List<CollisionResult<IPlayer>>();
        if (self.IsColliding(player.Pushbox))
        {
            Vector2 depth = self.GetOverlap(player.Pushbox);
            CollisionResult<IPlayer> result = null;
            switch (player) {
                case Player p:
                    result = new CollisionResult<IPlayer>(depth, player.Pushbox, p);
                    break;
            }
            results.Add(result);
        } 
        return results;
    }

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

    public static List<CollisionResult<Doors>> DetectDoorCollision(ICollider self, Doors door)
    {
        List<CollisionResult<Doors>> results = new List<CollisionResult<Doors>>();
        foreach (BoxCollider d in door.colliders)
        {
            if (self.IsColliding(d))
            {
                Vector2 depth = self.GetOverlap(d);
                CollisionResult<Doors> result = new CollisionResult<Doors>(depth, d, door);
                results.Add(result);
            }
        }
        return results;
    }
}