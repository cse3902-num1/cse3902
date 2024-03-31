using System.Collections.Generic;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicItemPickup : IItemPickup
{
    public Vector2 Position {set;get;}
    protected ISprite sprite; /* should set in constructor */
    protected Room room;
    public ICollider Collider {set;get;}
    public bool IsDead {set;get;}

    public BasicItemPickup(Room room)
    {
        Position = new Vector2(0);
        this.room = room;
        this.Collider = new BoxCollider(Position, new Vector2(16, 16), new Vector2(8, 8), ColliderType.ITEM_PICKUP);
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
        // do nothing, child classes can override this
    }
}