using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class BoomerangItemPickup : IItemPickup
{
    public Vector2 Position;
    public ISprite sprite;

    public BoomerangItemPickup(GameContent content)
    {
        Position = new Vector2(0, 0);

        /* TODO: load the sprite's texture and frame data */
    }

    public void Update(GameTime gameTime)
    {
        /* TODO: nothing probably, but we could animate the sprite */
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        /* TODO: draw the sprite */
    }
}
