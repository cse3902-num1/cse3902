using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public interface IItemPickup
{
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
}
