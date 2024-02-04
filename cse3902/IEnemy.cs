using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public interface IEnemy
{
    public void move(GameTime gameTime, int randomNum);

    public void attack();

    public void takeDmg();

    public void draw(SpriteBatch spriteBatch);

    public void update(GameTime gameTime);
}
