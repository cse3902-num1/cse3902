using System.Collections.Generic;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicItemPickup : IItemPickup
{
    public Vector2 Position {set;get;}
    protected ISprite sprite; /* should set in constructor */
    protected Room room;

    public BasicItemPickup(Room room)
    {
        Position = new Vector2(0);
        this.room = room;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        sprite.Update(gameTime, controllers);
    }
}