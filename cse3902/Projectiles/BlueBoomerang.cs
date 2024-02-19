using cse3902.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles
{
    internal class BlueBoomerang : IProjectile
    {
        private Vector2 velocity;
        private Sprite boomerang;
        public BlueBoomerang(GameContent content, Vector2 velocity, Vector2 charPos)
        {
            boomerang = new Sprite(content.blueBoomerang,
                new List<Rectangle>()
                {
                    new Rectangle(0, 0, 20, 32),
                    new Rectangle(20, 0, 20, 32),
                    new Rectangle(0, 32, 20, 32)
                },
                new Vector2(10, 16)
            );
            this.velocity = velocity;
            boomerang.SetPosition(charPos.X, charPos.Y);
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return boomerang.Position; }
            set { boomerang.Position = value; }
        }
        public void Update(GameTime gameTime)
        {
            boomerang.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            boomerang.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            boomerang.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerang.Draw(spriteBatch);
        }
    }
}
