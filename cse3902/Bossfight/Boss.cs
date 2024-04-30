using System.Collections.Generic;
using cse3902.Enemy;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class Boss
{
    public Vector2 Position {set;get;}

    private GameContent content;
    public BossfightLevel Level;
    private Sprite boggus;

    public Boss(GameContent content, BossfightLevel level, Vector2 position) {
        boggus = new Sprite(content.boggus,
               new List<Rectangle>()
               {
                   new Rectangle(0,0,256,416)
               },
              0.5f
           )  ;
        this.content = content;
        this.Level = level;
        this.Position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        boggus.Position = Position;
        boggus.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        boggus.Update(gameTime, controllers);
        Position += new Vector2(1, 0);
        
    }
}