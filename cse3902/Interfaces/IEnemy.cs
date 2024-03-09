using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces;

public interface IEnemy : IGameObject
{
    public Vector2 Position { get; set; }
    public void Move(GameTime gameTime, int randomNum);

    public void Attack();

    public void TakeDmg();
}
