using System.Collections.Generic;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class Boss
{
    public Vector2 Position {set;get;} = new Vector2();

    private GameContent content;
    public BossfightLevel Level;

    public Boss(GameContent content, BossfightLevel level, Vector2 position) {
        this.content = content;
        this.Level = level;
        this.Position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
    }
}