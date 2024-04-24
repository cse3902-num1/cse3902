using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicBoomerangProjectile : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public bool isEnermyProjectile { get; set; }

    protected ISprite sprite; /* set in constructor */
    protected float range;
    protected float totalDistance;
    protected bool isReturning;
    protected Vector2 initialPosition;

    public ICollider Hitbox; /* set in constructor */
    protected Level level;

    public BasicBoomerangProjectile(Level level, Vector2 position, Vector2 velocity, float range)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.range = range;
        totalDistance = 0;
        isReturning = false;
        initialPosition = position;
        this.level = level;
    }

    public virtual void Die()
    {
        IsDead = true;
    }

    public virtual void Update(GameTime gameTime, List<IController> controllers)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += Velocity * deltaTime;

        // Calculate the straight-line displacement from the starting point to the current position
        // totalDistance += Vector2.Distance(initialPosition, Position);
        totalDistance += (Velocity * deltaTime).Length();

        // Check if the boomerang has reached its maximum range and should start returning
        if (!isReturning && totalDistance >= range && totalDistance < range * 2)
        {
            isReturning = true;

            Velocity *= -1f;
        }

        // Check if the boomerang has returned close enough to the initial position
        if (totalDistance >= range * 2)
        {
            Die();
        }

        /* check for collisions */
        if (isEnermyProjectile == false)
        {
            Hitbox.Position = Position;
            foreach (IEnemy e in level.Enemies)
            {
                switch (e)
                {
                    case EnemyBase enemyBase:
                        if (Hitbox.IsColliding(enemyBase.Collider))
                        {
                            e.TakeDmg(1);
                            Die();
                        }
                        break;
                }
            }
        }
        else
        {
            Hitbox.Position = Position;
            if (Hitbox.IsColliding(level.player.Pushbox))
            {
                this.IsDead = true;

                level.player.TakeDamage();
            }
        }

        sprite.Update(gameTime, controllers);
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }
}