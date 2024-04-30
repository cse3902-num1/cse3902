using System.Collections.Generic;
using cse3902.Bossfight;
using Microsoft.Xna.Framework;

namespace cse3902.Games;

public class GameBossfightState : IGameState
{
    private GameContent content;
    private Game1 game;

    public BossfightLevel Level;

    public GameBossfightState(GameContent content, Game1 game) {
        this.content = content;
        this.game = game;
        
        this.Level = new BossfightLevel(content, game);
    }

    public void Draw(Camera camera)
    {
        Level.Draw(camera);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        Level.Update(gameTime, controllers);
    }
}