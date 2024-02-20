using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using cse3902.Interfaces;
using System;
using System.Diagnostics;

namespace cse3902.Projectiles
{
    internal class BlueArrow : IProjectile
    {
        private Vector2 velocity;
        private Sprite blueArrowUp;
        private Sprite blueArrowDown;
        private Sprite blueArrowLeft;
        private Sprite blueArrowRight;
        private ArrowExplode arrowExplode;
        private Vector2 playerPos;
        private Stopwatch explodeTimer = new Stopwatch();

        public BlueArrow(GameContent content, Vector2 velocity, IPlayer player)
        {
            blueArrowUp = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(27, 185, 7, 15) }, new Vector2(3.5f, 8.5f));
            blueArrowDown = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(15, 15, 15, 15) }, new Vector2(7.5f, 7.5f));
            blueArrowLeft = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(0, 15, 15, 15) }, new Vector2(7.5f, 7.5f));
            blueArrowRight = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(36, 185, 15, 15) }, new Vector2(7.5f, 7.5f));
            arrowExplode = new ArrowExplode(content);
            this.velocity = velocity;
            playerPos = player.Position;
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
            if (Math.Abs(Position.X - playerPos.X) <= 400f
                && Math.Abs(Position.Y - playerPos.Y) <= 400f)
            {
                blueArrowUp.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                blueArrowDown.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                blueArrowLeft.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                blueArrowRight.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Math.Abs(Position.X - playerPos.X) >= 400f
                || Math.Abs(Position.Y - playerPos.Y) >= 400f)
            {
                arrowExplode.Position = blueArrowUp.Position;
                explodeTimer.Start();

                if (explodeTimer.ElapsedMilliseconds <= 500)
                {

                    arrowExplode.Draw(spriteBatch);
                }
            }
            else
            {
                if (velocity.X > 0)
                {
                    blueArrowRight.Draw(spriteBatch);
                }
                else if (velocity.X < 0)
                {
                    blueArrowLeft.Draw(spriteBatch);
                }
                else if (velocity.Y < 0)
                {
                    blueArrowUp.Draw(spriteBatch);
                }
                else if (velocity.Y > 0)
                {
                    blueArrowDown.Draw(spriteBatch);
                }
            }
        }
    }
}
