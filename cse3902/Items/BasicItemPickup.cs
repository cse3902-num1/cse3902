using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicItemPickup : IItemPickup
{
    public Vector2 Position {set;get;}
    protected ISprite sprite; /* should set in constructor */

    public BasicItemPickup()
    {
        Position = new Vector2(0);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime, IController controller)
    {
        sprite.Update(gameTime, controller);
    }
}