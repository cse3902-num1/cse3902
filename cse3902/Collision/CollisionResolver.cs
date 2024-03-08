using System;
using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using Microsoft.Xna.Framework;
namespace cse3902;

public static class CollisionResolver
{

    public static void CollisionMove(IPlayer iplayer, ICollider collider, float width, float height)
    {
        Player player = (Player) iplayer; /* really goofy but i'm too lazy to care rn */

        // a is subject b is object
        BoxCollider b = (BoxCollider)collider;
        float aleft = player.Position.X - player.Origin.X;
        float aright = aleft + player.Size.X;
        float atop = player.Position.Y - player.Origin.Y;
        float abottom = atop + player.Size.Y;

        float bleft = b.Position.X - b.Origin.X;
        float bright = bleft + b.Size.X;
        float btop = b.Position.Y - b.Origin.Y;
        float bbottom = btop + b.Size.Y;

        Vector2 newPosition = player.Position;
        if (height > width)
        {
            if (aleft >= bleft)
            {
                newPosition.X += width;
            }
            else
            {
                newPosition.X -= width;
            }
        }
        else
        {
            if (atop >= btop)
            {
                newPosition.Y += height;
            }
            else
            {
                newPosition.Y -= height;
            }
        }
        player.Position = newPosition;
    }

    public static void ResolveProjectileEnemyCollision(IProjectile projectile, List<CollisionResult<IEnemy>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        /* call something like OnHit() on the projectile, passing in the enemy (or list of enemies? or the collision result?) */
        projectile.IsDead = true;
        foreach (CollisionResult<IEnemy> r in results) {
            r.Entity.TakeDmg(1);
        }
    }

    public static void ResolvePlayerBlockCollision(IPlayer player, List<CollisionResult<Block>> results)
    {
        /* if no collisions occurred, do nothing */
        if (results.Count == 0) {
            return;
        }

        /* TODO: get collision result with largest area and use it to calculate how much to move the player back */

        /* get collision result with largest overlap area */
        float area = 0f;
        CollisionResult<Block> biggestResult = results[0];
        foreach (CollisionResult<Block> result in results)
        {
            if (result.GetArea() > area) {
                area = result.GetArea();
                biggestResult = result;
            }
        }

        /* determine direction based on relative positions of colliders, and apply that movement */
        CollisionMove(player, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
    }
   
}