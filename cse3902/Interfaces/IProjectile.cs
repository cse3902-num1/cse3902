using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces
{
    internal interface IProjectile
    {
        public Vector2 Velocity { get; set; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }
}
