using System;
using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Objects;
using Microsoft.Xna.Framework;
namespace cse3902;

public static class CollisionResolver
{

    public static Vector2 CollisionMove(ICollider collider1, ICollider collider, float width, float height)
    {
        BoxCollider a = (BoxCollider)collider1;

        // a is subject b is object
        BoxCollider b = (BoxCollider)collider;
        float aleft = a.Position.X - a.Origin.X;
        float aright = aleft + a.Size.X;
        float atop = a.Position.Y - a.Origin.Y;
        float abottom = atop + a.Size.Y;

        float bleft = b.Position.X - b.Origin.X;
        float bright = bleft + b.Size.X;
        float btop = b.Position.Y - b.Origin.Y;
        float bbottom = btop + b.Size.Y;

        Vector2 newPosition = a.Position;
        if (height > width) // if collision height greater, it's moving horizontally
        {
            if (aleft >= bleft) // if player is moving collide with right part of the object 
            {
                newPosition.X += width;
                return new Vector2(width, 0);
            }
            else //if player is moving collide with left part of the object
            {
                newPosition.X -= width;
                return new Vector2(-width, 0);
            }
        }
        else    // moving vertically
        {
            if (atop >= btop)   // player is moving collide with top of the object
            {
                newPosition.Y += height;
                return new Vector2 (height, 0);
            }
            else
            {
                newPosition.Y -= height;    // player is moving collide with bottom of the obejct
                return new Vector2 (-height, 0);
            }
        }
        //a.Position = newPosition;
        return new Vector2(newPosition.X, newPosition.Y);
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
        
    }

    /* Called only when projectile collision with player */
    public static void ResolveProjectilePlayerCollision(IProjectile projectile, IPlayer player)
    {
        projectile.IsDead = true;
        player.TakeDamage();
    }

    public static void ResolvePlayerEnemyCollision(IPlayer player, List<CollisionResult<IEnemy>> results)
    {
        if (results.Count == 0)
        {
            return;
        }

        foreach (CollisionResult<IEnemy> result in results)
        {
            player.TakeDamage();
        }
    }

    /* Called only when projectile collision with walls */
    public static void ResolveProjectileWallCollision(IProjectile projectile)
    {
        projectile.IsDead = true;
    }

    public static void ResolveEnemyWallCollision(IEnemy enemy,  List<CollisionResult<IEnemy>> results)
    {
        if (results.Count == 0)
        {
            return;
        }

        CollisionMove(enemy, results[0].Collider, (int)results[0].Size.X, (int)results[0].Size.Y);
    }
   
}