using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles
{
    internal class Fire : IProjectile
    {
        private Vector2 velocity;
        private Sprite fire;

        public Fire(GameContent content, Vector2 velocity)
        {
            fire = new Sprite(content.weapon2,
                new List<Rectangle>()
                {
                    new Rectangle(0, 30, 15, 15),
                    new Rectangle(15, 30 , 15, 15)
                }
            );
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return fire.Position; }
            set { fire.Position = value; }
        }

        public void Update(GameTime gameTime)
        {
            fire.Position = velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            fire.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fire.Draw(spriteBatch);
        }
    }
}
