using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public interface IBossfightProjectile {
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public float Radius {set;get;}
    public Sprite sprite {set;get;}

    public void Update(GameTime gameTime, List<IController> controllers);
    public void Draw(SpriteBatch spriteBatch);
}