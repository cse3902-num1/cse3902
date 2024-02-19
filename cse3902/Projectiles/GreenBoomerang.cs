using cse3902.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles
{
    internal class GreenBoomerang : IProjectile
    {
        private Vector2 velocity;
        private Sprite boomerang;
        public GreenBoomerang(GameContent content, Vector2 velocity, Vector2 charPos)
        {
            boomerang = new Sprite(content.enemiesSheet,
                new List<Rectangle>()
                {
                    new Rectangle(290, 11, 8, 16),
                    new Rectangle(299, 11, 8, 16),
                    new Rectangle(308, 11, 8, 16)
                },
                new Vector2(4, 8)
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
