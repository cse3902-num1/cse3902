using System;
using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using Microsoft.Xna.Framework;
namespace cse3902;

public static class CollisionResolver
{

    public static void CollisionMove(Player player, ICollider collider, int width, int height)
    {
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

        if (height > width)
        {
            if (aleft >= bleft)
            {
                player.Position = new Vector2(player.Position.X - 200, player.Position.Y);
            }
            else
            {
                player.Position = new Vector2(player.Position.X + 200, player.Position.Y);
            }
        }
        else
        {
            if (atop >= btop)
            {
                player.Position = new Vector2(player.Position.X, player.Position.Y + 200);
            }
            else
            {
                player.Position = new Vector2(player.Position.X, player.Position.Y - 200);
            }
        }
    }

    public static void ResolveProjectileEnemyCollision(IProjectile projectile, List<CollisionResult<IEnemy>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        /* call something like OnHit() on the projectile, passing in the enemy (or list of enemies? or the collision result?) */
        projectile.IsDead = true;
        results[0].Entity.TakeDmg(1);
    }

    public static void ResolvePlayerBlockCollision(IPlayer player, List<CollisionResult<Block>> results)
    {

        /* TODO: get collision result with largest area and use it to calculate how much to move the player back */
    }
   
}