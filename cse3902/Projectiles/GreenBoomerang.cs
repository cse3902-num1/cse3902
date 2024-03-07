using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class GreenBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 200f;
    public GreenBoomerang(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity, maxDistance)
    {
        sprite = new Sprite(content.enemiesSheet,
            new List<Rectangle>()
            {
                new Rectangle(290, 11, 8, 16),
                new Rectangle(299, 11, 8, 16),
                new Rectangle(308, 11, 8, 16)
            },
            new Vector2(4, 8)
        );
    }
    /*
    public override void Update(GameTime gameTime, List<IController> controllers)
    {
        Debug.WriteLine($"Updating Boomerang: Position={Position}, Velocity={Velocity}, IsReturning={isReturning}, Distance={Vector2.Distance(initialPosition, Position)}");
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (isReturning && Vector2.Distance(initialPosition, Position) <= 10)
        {
            IsDead = true;
        }
        /* flip direction once we reach max distance */
    /*
        if (Vector2.Distance(initialPosition, Position) >= maxDistance)
        {
            isReturning = true;
            Velocity = -Velocity;
        }

        /* finish once we return to original position */
    /*
        sprite.Update(gameTime,controllers);

      
        
    }
    */

}
