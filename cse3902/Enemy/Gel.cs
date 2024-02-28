using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace cse3902.Enemy
{
    public class Gel : IEnemy
    {
        public Vector2 Position {set;get;}
        private Sprite sprite;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;

        public Gel(GameContent content)
        {

            sprite = new Sprite(content.enemiesSheet, 
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 7, 16),
                    new Rectangle(10, 11, 7, 16)
                }
            );

            Position = new Vector2(200, 200);
        }

        public void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position = newPosition;
        }

        public void Attack()
        {

        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, IController controller)
        {

            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controller);
        }
    }
}
