using cse3902.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles
{
    internal class BlueBoomerang : IProjectile
    {
        public bool IsDead {get;set;}
        private Vector2 velocity;
        private ISprite sprite;
        private Vector2 initialPosition;
        private bool isReturning;
        private const float maxDistance = 300f;
        public BlueBoomerang(GameContent content, Vector2 velocity, Vector2 initialPosition)
        {
            sprite = new Sprite(content.blueBoomerang,
                new List<Rectangle>()
                {
                    new Rectangle(0, 0, 20, 32),
                    new Rectangle(20, 0, 20, 32),
                    new Rectangle(0, 32, 20, 32)
                },
                new Vector2(10, 16)
            );
            this.velocity = velocity;
            this.initialPosition = initialPosition;
            isReturning = false;
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
            Position += Velocity * (float) gameTime.ElapsedGameTime.TotalSeconds;
            
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}
