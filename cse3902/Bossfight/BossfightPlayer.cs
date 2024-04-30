using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossfightPlayer {
    public Vector2 Position;
    public BossfightLevel Level;

    public BossfightPlayer(BossfightLevel level, Vector2 position) {
        this.Level = level;
        this.Position = position;
    }

    public void Update(GameTime gameTime, List<IController> controllers) {

    }

    public void Draw(SpriteBatch spriteBatch) {

    }
}