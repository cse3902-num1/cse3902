using cse3902.Interfaces;
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
        private Random random = new Random();
        private int randomNum = 1;

        public Dragon(GameContent content)
        {
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    new Rectangle(0, 10, 25, 32),
                    new Rectangle(25, 10, 25, 32),
                    new Rectangle(50, 10, 25, 32),
                    new Rectangle(75, 10, 25, 32)
                }
            );
            sprite.SetPosition(200, 200);
        }

        public void Move(GameTime gameTime, int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    sprite.Y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    sprite.X -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    sprite.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    sprite.Y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void Attack()
        {

        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime);
        }
    }
}
