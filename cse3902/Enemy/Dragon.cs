using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Dragon : IEnemy
    {
        private Sprite sprite;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Stopwatch attackTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;
        private Fireball ballUp;
        private Fireball ballDown;
        private Fireball ballMid;

        public Dragon(GameContent content)
        {
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 25, 32),
                    new Rectangle(26, 11, 25, 32),
                    new Rectangle(51, 11, 25, 32),
                    new Rectangle(76, 11, 25, 32)
                }
            );
            sprite.SetPosition(500, 200);
            ballUp = new Fireball(content, 
                new Vector2(-200f, -50f), 
                new Vector2(sprite.X, sprite.Y)
            );
            ballDown = new Fireball(content,
                new Vector2(-200f, +50f),
                new Vector2(sprite.X, sprite.Y)
            );
            ballMid = new Fireball(content,
                new Vector2(-200f, 0f),
                new Vector2(sprite.X, sprite.Y)
            );
        }

        public Vector2 Position
        {
            get { return sprite.Position; }
            set { sprite.Position = value; }
        }
        public void Move(GameTime gameTime, int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    sprite.Y -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    sprite.X -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    sprite.X += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    sprite.Y += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void Attack()
        {
            ballUp.Position = new Vector2(sprite.X, sprite.Y);
            ballDown.Position = new Vector2(sprite.X, sprite.Y);
            ballMid.Position = new Vector2(sprite.X, sprite.Y);
        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            ballUp.Draw(spriteBatch);
            ballDown.Draw(spriteBatch);
            ballMid.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            randomChangeTimer.Start();
            attackTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            if (attackTimer.ElapsedMilliseconds >= 3000)
            {
                attackTimer.Restart();
                Attack();
            }
            ballUp.Update(gameTime);
            ballDown.Update(gameTime);
            ballMid.Update(gameTime);

            Move(gameTime, randomNum);

            sprite.Update(gameTime);
        }
    }
}
