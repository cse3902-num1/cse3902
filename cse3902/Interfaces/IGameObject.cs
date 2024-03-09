using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public interface IGameObject
{
    public Vector2 Position {set;get;}
    public void Update(GameTime gameTime, IController controller);
    public void Draw(SpriteBatch spriteBatch);
}