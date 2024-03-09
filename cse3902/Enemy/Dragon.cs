using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Dragon : IEnemy
    {
        public Vector2 Position {set;get;}
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

            Position = new Vector2(500, 200);
        }

        public Vector2 Position
        {
            get { return sprite.Position; }
            set { sprite.Position = value; }
        }
        public void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position = newPosition;
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
            sprite.Position = Position;
            sprite.Draw(spriteBatch);

            ballUp.Draw(spriteBatch);
            ballDown.Draw(spriteBatch);
            ballMid.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, IController controller)
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
            ballUp.Update(gameTime, controller);
            ballDown.Update(gameTime, controller);
            ballMid.Update(gameTime, controller);

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controller);
        }
    }
}
