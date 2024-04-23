using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicItemPickup : IItemPickup
{
    public Vector2 Position {set;get;}
    protected ISprite sprite; /* should set in constructor */
    protected Level level;
    public ICollider Collider {set;get;}
    public bool IsDead {set;get;}

    public BasicItemPickup(Level level)
    {
        Position = new Vector2(0);
        this.level = level;
        this.Collider = new BoxCollider(Position, ItemsConstant.BasicItemColliderSize, ItemsConstant.BasicItemColliderOrigin, ColliderType.ITEM_PICKUP);
        this.IsDead = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
       
        sprite.Draw(spriteBatch);
        
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        Collider.Position = Position;
        sprite.Update(gameTime, controllers);
    }

    public virtual void Pickup(IPlayer player) {
        IsDead = true;
    }
}