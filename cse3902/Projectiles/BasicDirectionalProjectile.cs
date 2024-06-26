using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Enemy;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace cse3902.Projectiles;

public abstract class BasicDirectionalProjectile : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Velocity {set;get;}
    public Vector2 Position {set;get;}
    public bool isEnermyProjectile { set; get; }

    //public Player player;

    /* set in constructor */
    protected ISprite leftSprite;
    protected ISprite rightSprite;
    protected ISprite upSprite;
    protected ISprite downSprite;
    
    private ISprite currentSprite;
    public ICollider Hitbox; /* set in constructor */
    public Level level;

    /* need to call this super constructor in the subclass's constructor */
    public BasicDirectionalProjectile(Level level, Vector2 position, Vector2 velocity)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.level = level;
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        /* if draw() gets called before update(),
           currentSprite could be null. */
        if (currentSprite == null) return;

        currentSprite.Position = Position;
        currentSprite.Draw(spriteBatch);
    }

    public virtual void Update(GameTime gameTime, List<IController> controllers)
    {
        
        Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

        if (Velocity.Y > 0) currentSprite = downSprite;
        if (Velocity.X > 0) currentSprite = rightSprite;
        if (Velocity.X < 0) currentSprite = leftSprite;
        if (Velocity.Y < 0) currentSprite = upSprite;

        currentSprite.Update(gameTime, controllers);

        Hitbox.Position = Position;

    }

    public virtual void Die()
    {
        IsDead=true;
    }
}