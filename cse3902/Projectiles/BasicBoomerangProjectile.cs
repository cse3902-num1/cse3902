using System.Collections.Generic;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicBoomerangProjectile : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}

    protected ISprite sprite; /* set in constructor */
    protected float range;
    protected float totalDistance;
    protected bool isReturning;
    protected Vector2 initialPosition;

    public BasicBoomerangProjectile(Vector2 position, Vector2 velocity, float range)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.range = range;
        totalDistance = 0;
        isReturning = false;
        initialPosition = position;
    }

    private void Die()
    {
        IsDead = true;
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
        totalDistance += Velocity.Length() * (float) gameTime.ElapsedGameTime.TotalSeconds; /* slow but should be fine for now */

        if (!isReturning && totalDistance > range && totalDistance <= range * 2)
        {
            isReturning = true;
            Velocity *= -1;
        }

        if (totalDistance > range * 2)
        {
            Die();
        }

        sprite.Update(gameTime, controllers);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }
}