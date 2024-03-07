using System.Collections.Generic;
using cse3902.Enemy;
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
    public ICollider Hitbox; /* set in constructor */
    public Room room;

    /* need to call this super constructor in the subclass's constructor */
    public BasicDirectionalProjectile(Room room, Vector2 position, Vector2 velocity)
    {
        IsDead = false;
        Position = position;
        Velocity = velocity;
        this.room = room;
      
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

        Hitbox.Position = Position;

        /* check for enemy collisions */
        foreach (IEnemy e in room.Enemies) {
            switch (e) {
                case EnemyBase enemyBase:
                    if (Hitbox.IsColliding(enemyBase.Collider)) {
                        IsDead = true;
                        e.TakeDmg(1);
                    }
                    break;
            }
        }

        /* check for player collisions */
        if (Hitbox.IsColliding(room.Player.Pushbox)) {
            // this.IsDead = true;
            
            // room.Player.TakeDamage();
        }
    }
}