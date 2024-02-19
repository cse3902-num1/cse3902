using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using cse3902.Interfaces;

namespace cse3902.Projectiles
{
    internal class BlueArrow : IProjectile
    {
        private Vector2 velocity;
        private Sprite blueArrowUp;
        private Sprite blueArrowDown;
        private Sprite blueArrowLeft;
        private Sprite blueArrowRight;

        public BlueArrow(GameContent content, Vector2 velocity)
        {
            blueArrowUp = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(27, 185, 7, 15) });
            blueArrowDown = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(0, 15, 15, 15) });
            blueArrowLeft = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(15, 15, 15, 15) });
            blueArrowRight = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(36, 185, 15, 15) });
            this.velocity = velocity;
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return blueArrowUp.Position; }
            set
            {
                blueArrowUp.Position = value;
                blueArrowDown.Position = value;
                blueArrowLeft.Position = value;
                blueArrowRight.Position = value;
            }
        }
        public void Update(GameTime gameTime)
        {
            blueArrowUp.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            blueArrowDown.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            blueArrowLeft.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            blueArrowRight.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
            {
                blueArrowRight.Draw(spriteBatch);
            }
            else if (velocity.X < 0)
            {
                blueArrowLeft.Draw(spriteBatch);
            }
            else if (velocity.Y > 0)
            {
                blueArrowUp.Draw(spriteBatch);
            }
            else if (velocity.Y < 0)
            {
                blueArrowDown.Draw(spriteBatch);
            }
        }
    }
}
