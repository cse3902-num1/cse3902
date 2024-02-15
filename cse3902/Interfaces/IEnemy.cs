using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces;

public interface IEnemy
{
    public void Move(GameTime gameTime, int randomNum);

    public void Attack();

    public void TakeDmg();

    public void Draw(SpriteBatch spriteBatch);

    public void Update(GameTime gameTime);
}
