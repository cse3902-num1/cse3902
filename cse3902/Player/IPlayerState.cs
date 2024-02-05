using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public interface IPlayerState
    {
        public void Update(GameTime gameTime,IController keyboard);
        public void Draw(SpriteBatch spriteBatch);
    }
}
