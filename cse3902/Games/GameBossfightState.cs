using System.Collections.Generic;
using cse3902.Bossfight;
using Microsoft.Xna.Framework;

namespace cse3902.Games;

public class GameBossfightState : IGameState
{
    public BossfightLevel Level = new BossfightLevel();

    public void Draw(Camera camera)
    {
        Level.Draw(camera);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        Level.Update(gameTime, controllers);
    }
}