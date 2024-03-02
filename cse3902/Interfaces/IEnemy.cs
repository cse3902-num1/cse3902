using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces;

public interface IEnemy : IGameObject
{
    public void Move(GameTime gameTime, int randomNum);

    public void Attack();

    public void TakeDmg(int damage);
    
}
