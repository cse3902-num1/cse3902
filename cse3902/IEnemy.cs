using Microsoft.Xna.Framework;

namespace cse3902;

public interface IEnemy
{
    public void move();

    public void attack();

    public void takeDmg();
}
