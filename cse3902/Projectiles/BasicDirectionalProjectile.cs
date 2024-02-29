using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles;

public abstract class BasicDirectionalProjectile : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Velocity {set;get;}
    public Vector2 Position {set;get;}
    
    /* set in constructor */
    protected ISprite leftSprite;
    protected ISprite rightSprite;
    protected ISprite upSprite;
    protected ISprite downSprite;
    protected ICollider collider;

    private ISprite currentSprite;
    

    /* need to call this super constructor in the subclass's constructor */
    public BasicDirectionalProjectile(Vector2 position, Vector2 velocity, ICollider collider)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.collider = collider; 
        currentSprite = downSprite; /* currentSprite can't be null */
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        currentSprite.Position = Position;
        currentSprite.Draw(spriteBatch);
    }

    public virtual void Update(GameTime gameTime, IController controller)
    {
        Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

        if (Velocity.X >= 0) currentSprite = rightSprite;
        if (Velocity.X < 0)  currentSprite = leftSprite;
        if (Velocity.Y >= 0) currentSprite = downSprite;
        if (Velocity.Y < 0)  currentSprite = upSprite;

        currentSprite.Update(gameTime, controller);
    }
}