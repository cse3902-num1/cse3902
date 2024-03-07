using System.Collections.Generic;
using System.Diagnostics;
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

    public void Die()
    {
        IsDead = true;
    }

    public virtual void Update(GameTime gameTime, List<IController> controllers)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += Velocity * deltaTime;

        // Calculate the straight-line displacement from the starting point to the current position
        float displacement = Vector2.Distance(initialPosition, Position);
        Debug.WriteLine("position" + Position + "displacement" + displacement);

        // Check if the boomerang has reached its maximum range and should start returning
        if (!isReturning && displacement >= range)
        {
            Debug.WriteLine("displacement" + displacement + "range" + range);
            isReturning = true;
            // Instead of simply inverting the velocity, calculate the direction back to the initial position
            Velocity = (initialPosition - Position);
            if (Velocity != Vector2.Zero)
                Velocity.Normalize();
            Velocity *= Velocity.Length(); // Set the return speed (might be different from initial speed)
        }

        // Check if the boomerang has returned close enough to the initial position
        if (isReturning && displacement <= 0.1f)
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