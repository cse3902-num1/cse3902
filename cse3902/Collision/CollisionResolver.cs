using System;
using System.Collections.Generic;
using cse3902.DoorClasses;
using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.WallClasses;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace cse3902;

public static class CollisionResolver
{

    public static Vector2 CollisionMove(ICollider collider1, ICollider collider, float width, float height)
    {
        const float CollisionBuffer = 2;

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
        if (height > width) // if collision height greater, it's moving horizontally
        {
            if (aleft >= bleft) // if player is moving collide with right part of the object 
            {
                return new Vector2(width + CollisionBuffer, 0);
            }
            else //if player is moving collide with left part of the object
            {
                return new Vector2(-width - CollisionBuffer, 0);
            }
            
        }
        else    // moving vertically
        {
            if (abottom <= bbottom)   // player is moving collide with top of the object
            {
                return new Vector2 (0, -height- CollisionBuffer);
            }
            else // player is moving collide with bottom of the obejct
            {
                return new Vector2 (0, height+ CollisionBuffer);
            }
        }
    }

    public static void ResolveProjectileEnemyCollision(IProjectile projectile, List<CollisionResult<IEnemy>> results)
    {
        if (projectile.isEnermyProjectile) return;
        if (results.Count == 0) return;
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
        Vector2 reconciliation = CollisionMove(((Player) player).Pushbox, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
        player.Position += reconciliation;
    }

    public static void ResolveEnemyBlockCollision(IEnemy enemy, List<CollisionResult<Block>> blockResults)
    {
        /* if no collisions occurred, do nothing */
        if (blockResults.Count == 0) {
            return;
        }

        /* get collision result with largest overlap area */
        float biggestArea = 0f;
        ICollider biggestCollider = null;
        Vector2 biggestSize = new Vector2(0, 0);
        foreach (CollisionResult<Block> result in blockResults)
        {
            if (biggestCollider == null || result.GetArea() > biggestArea) {
                biggestArea = result.GetArea();
                biggestCollider = result.Collider;
                biggestSize = result.Size;
            }
        }

        /* determine direction based on relative positions of colliders, and apply that movement */
        Vector2 reconciliation = new Vector2(0, 0);
        switch (enemy)
        {
            case EnemyBase e:
                reconciliation = CollisionMove(e.Collider, biggestCollider, biggestSize.X, biggestSize.Y);
                break;
            default:
                throw new NotImplementedException("Unhandled enemy type " + enemy.GetType().Name);
        }
        enemy.Position += reconciliation;
    }

    /* Called only when projectile collision with player */
    public static void ResolveProjectilePlayerCollision(IProjectile projectile, List<CollisionResult<IPlayer>> results)
    {
        if (!projectile.isEnermyProjectile) return;
        if (results.Count == 0) return;
        projectile.IsDead = true;
        foreach (CollisionResult<IPlayer> result in results)
        {
            
            switch (result.Entity) {
                case Player p:
                    p.TakeDamage();
                    break;
            }
        }
    }

    public static void ResolvePlayerEnemyCollision(IPlayer player, List<CollisionResult<IEnemy>> results)
    {
        
        if (results.Count == 0)
        {
            return;
        }

        //float area = 0f;
        //CollisionResult<IEnemy> biggestResult = results[0];
        foreach (CollisionResult<IEnemy> result in results)
        {
            //if (result.GetArea() > area)
            //{
            //    area = result.GetArea();
            //    biggestResult = result;
            //}
            player.TakeDamage();

        }

        //Vector2 reconciliation = CollisionMove(player.Pushbox, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
        //player.Position += reconciliation;
    }

    /* Called only when projectile collision with walls */
    public static void ResolveProjectileWallCollision(IProjectile projectile)
    {
        projectile.IsDead = true;
    }

    public static void ResolveEnemyWallCollision(IEnemy enemy,  List<CollisionResult<Wall>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        float area = 0f;
        CollisionResult<Wall> biggestResult = results[0];
        foreach (CollisionResult<Wall> result in results)
        {
            if (result.GetArea() > area)
            {
                area = result.GetArea();
                biggestResult = result;
            }
        }

        Vector2 reconciliation = CollisionMove(enemy.collider, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
        enemy.Position += reconciliation;
    }

    public static void ResolvePlayerWallCollision(IPlayer player, List<CollisionResult<Wall>> results)
    {
        if (results.Count == 0)
        {
            return;
        }

        float area = 0f;
        CollisionResult<Wall> biggestResult = results[0];
        foreach (CollisionResult<Wall> result in results)
        {
            if (result.GetArea() > area)
            {
                area = result.GetArea();
                biggestResult = result;
            }
        }

        Vector2 reconciliation = CollisionMove(((Player)player).Pushbox, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
        player.Position += reconciliation;
    }

    public static void ResolvePlayerItemPickupCollision(IPlayer player, List<CollisionResult<IItemPickup>> results, List<IItemPickup> inventoryItems)
    {
        foreach (CollisionResult<IItemPickup> result in results)
        {
            inventoryItems.Add(result.Entity);
            result.Entity.Pickup(player);
        }
    }

    public static void ResolvePlayerDoorCollision(IPlayer player, List<CollisionResult<Doors>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        /* TODO */
        //Player should go to another room according to what door did it collide with.
    }

    public static void ResolveEnemyDoorCollision(IEnemy enemy, List<CollisionResult<Doors>> results)
    {
        if (results.Count == 0)
        {
            return;
        }
        //Enemy should collision the doors like walls.
        float area = 0f;
        CollisionResult<Doors> biggestResult = results[0];
        foreach (CollisionResult<Doors> result in results)
        {
            if (result.GetArea() > area)
            {
                area = result.GetArea();
                biggestResult = result;
            }
        }

        Vector2 reconciliation = CollisionMove(enemy.collider, biggestResult.Collider, biggestResult.Size.X, biggestResult.Size.Y);
        enemy.Position += reconciliation;
    }
}