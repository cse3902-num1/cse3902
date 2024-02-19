using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using cse3902.Interfaces;

namespace cse3902.Projectiles
{
    internal class GreenArrow : IProjectile
    {
        private Vector2 velocity;
        private Sprite greenArrowUp;
        private Sprite greenArrowDown;
        private Sprite greenArrowLeft;
        private Sprite greenArrowRight;

        public GreenArrow(GameContent content, Vector2 velocity)
        {
            greenArrowUp = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(1, 185, 7, 15) }, new Vector2(3.5f, 7.5f));
            greenArrowDown = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(15, 0, 15, 15) }, new Vector2(7.5f, 7.5f));
            greenArrowLeft = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(0, 0, 15, 15) }, new Vector2(7.5f, 7.5f));
            greenArrowRight = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(10, 185, 15, 15) }, new Vector2(7.5f, 7.5f));
            this.velocity = velocity;
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return greenArrowUp.Position; }
            set
            {
                greenArrowUp.Position = value;
                greenArrowDown.Position = value;
                greenArrowLeft.Position = value;
                greenArrowRight.Position = value;
            }
        }
        public void Update(GameTime gameTime)
        {
            greenArrowUp.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            greenArrowDown.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            greenArrowLeft.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            greenArrowRight.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
            {
                greenArrowRight.Draw(spriteBatch);
            }
            else if (velocity.X < 0)
            {
                greenArrowLeft.Draw(spriteBatch);
            }
            else if (velocity.Y > 0)
            {
                greenArrowUp.Draw(spriteBatch);
            }
            else if (velocity.Y < 0)
            {
                greenArrowDown.Draw(spriteBatch);
            }
        }
    }
}
