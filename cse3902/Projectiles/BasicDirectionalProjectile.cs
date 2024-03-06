using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace cse3902.Projectiles;

public abstract class BasicDirectionalProjectile : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Velocity {set;get;}
    public Vector2 Position {set;get;}
    //public Player player;
    
    /* set in constructor */
    protected ISprite leftSprite;
    protected ISprite rightSprite;
    protected ISprite upSprite;
    protected ISprite downSprite;
    
    private ISprite currentSprite;
    public ICollider collider2;
    public Player player;

    /* need to call this super constructor in the subclass's constructor */
    public BasicDirectionalProjectile(Vector2 position, Vector2 velocity, Player player)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.player = player;
      
        currentSprite = downSprite; /* currentSprite can't be null */
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        currentSprite.Position = Position;
        currentSprite.Draw(spriteBatch);
    }

    public virtual void Update(GameTime gameTime, List<IController> controllers)
    {
        
        Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

        if (Velocity.X >= 0) currentSprite = rightSprite;
        if (Velocity.X < 0)  currentSprite = leftSprite;
        if (Velocity.Y >= 0) currentSprite = downSprite;
        if (Velocity.Y < 0)  currentSprite = upSprite;

        currentSprite.Update(gameTime, controllers);

        if (collider2.IsColliding(player.collider)) {
            this.IsDead = true;
            
            player.TakeDamage();
            
        }
    }
}