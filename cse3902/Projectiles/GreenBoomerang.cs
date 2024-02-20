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
        public bool IsDead {set;get;}
        private Vector2 velocity;
        private Sprite sprite;
        private Vector2 initialPosition;
        private bool isReturning;
        private const float maxDistance = 200f;
        public GreenBoomerang(GameContent content, Vector2 velocity, Vector2 initialPosition)
        {
            sprite = new Sprite(content.enemiesSheet,
                new List<Rectangle>()
                {
                    new Rectangle(290, 11, 8, 16),
                    new Rectangle(299, 11, 8, 16),
                    new Rectangle(308, 11, 8, 16)
                },
                new Vector2(4, 8)
            );
            this.velocity = velocity;
            this.initialPosition = initialPosition;
            this.isReturning = false;
            Position = initialPosition;
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return sprite.Position; }
            set { sprite.Position = value; }
        }
        public void Update(GameTime gameTime)
        {
            Position += velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;

            /* flip direction once we reach max distance */
            if (Vector2.Distance(initialPosition, Position) >= maxDistance)
            {
                isReturning = true;
                Velocity = -Velocity;
            }

            /* finish once we return to original position */
            if (isReturning && Vector2.Distance(initialPosition, Position) <= 10)
            {
                IsDead = true;
            }
            sprite.Update(gameTime);

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
