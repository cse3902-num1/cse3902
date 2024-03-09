using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public interface IPlayerState
    {
        public void Update(GameTime gameTime, List<IController> controllers);
        public void Draw(SpriteBatch spriteBatch);
    }
}
