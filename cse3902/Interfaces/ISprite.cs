using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public interface ISprite
{
 
    public void Update(Game game, GameTime gameTime);

    public void Draw(SpriteBatch spriteBatch);
}
