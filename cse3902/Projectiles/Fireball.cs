using cse3902.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles
{
    internal class Fireball : IProjectile
    {
        private Vector2 velocity;
        private Sprite fireBall;
        public Fireball(GameContent content, Vector2 velocity, Vector2 charPos)
        {
            fireBall = new Sprite(content.enemies, 
                new List<Rectangle>()
                {
                    new Rectangle(100, 11, 9, 18),
                    new Rectangle(109, 11, 9, 18),
                    new Rectangle(118, 11, 9, 18),
                    new Rectangle(127, 11, 9, 18)
                }
            );
            this.velocity = velocity;
            fireBall.SetPosition(charPos.X, charPos.Y);
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return fireBall.Position; }
            set { fireBall.Position = value; }
        }

        public void Update(GameTime gameTime)
        {
            fireBall.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            fireBall.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireBall.Draw(spriteBatch);
        }
    }
}
