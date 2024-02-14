using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Enemy
{
    public class Goriya : IEnemy
    {
        private enum GoriyaState { Left, Right, Up, Down }
        private GoriyaState currentState = GoriyaState.Down;
        private Sprite spriteUp;
        private Sprite spriteDown;
        private Sprite spriteLeft;
        private Sprite spriteRight;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;



        public Goriya(GameContent content)
        {
            spriteUp = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    new Rectangle(0, 32, 16, 16),
                    new Rectangle(16, 32, 16, 16)
                }
            );
            spriteDown = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    new Rectangle(0, 48, 16, 16),
                    new Rectangle(16, 48, 16, 16)
                }
            );
            spriteRight = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    new Rectangle(0, 16, 16, 16),
                    new Rectangle(16, 16, 16, 16)
                }
            );
            spriteLeft = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    new Rectangle(0, 0, 16, 16),
                    new Rectangle(16, 0, 16, 16)
                }
            );
            spriteDown.SetPosition(200, 200);
            spriteUp.SetPosition(200, 200);
            spriteLeft.SetPosition(200, 200);
            spriteRight.SetPosition(200, 200);
        }

        public void Move(GameTime gameTime, int randomNum)
        {
            float totalTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (currentState)
            {
                case GoriyaState.Up:
                    spriteUp.Y -= 100f * totalTime;
                    spriteDown.Y -= 100f * totalTime;
                    spriteLeft.Y -= 100f * totalTime;
                    spriteRight.Y -= 100f * totalTime;
                    break;
                case GoriyaState.Left:
                    spriteUp.X -= 100f * totalTime;
                    spriteDown.X -= 100f * totalTime;
                    spriteLeft.X -= 100f * totalTime;
                    spriteRight.X -= 100f * totalTime;
                    break;
                case GoriyaState.Right:
                    spriteUp.X += 100f * totalTime;
                    spriteDown.X += 100f * totalTime;
                    spriteLeft.X += 100f * totalTime;
                    spriteRight.X += 100f * totalTime;
                    break;
                case GoriyaState.Down:
                    spriteUp.Y += 100f * totalTime;
                    spriteDown.Y += 100f * totalTime;
                    spriteLeft.Y += 100f * totalTime;
                    spriteRight.Y += 100f * totalTime;
                    break;
            }
        }

        public void ChangeDirection(int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    currentState = GoriyaState.Up;
                    break;
                case 2:
                    currentState = GoriyaState.Down;
                    break;
                case 3:
                    currentState = GoriyaState.Left;
                    break;
                case 4:
                    currentState = GoriyaState.Right;
                    break;
            }
        }

        public void Attack(GameTime gameTime)
        {

        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == GoriyaState.Up)
            {
                spriteUp.Draw(spriteBatch);
            } 
            else if (currentState == GoriyaState.Down)
            {
                spriteDown.Draw(spriteBatch);
            } 
            else if (currentState == GoriyaState.Left)
            {
                spriteLeft.Draw(spriteBatch);
            }
            else if (currentState == GoriyaState.Right)
            {
                spriteRight.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            ChangeDirection(randomNum);
            Move(gameTime, randomNum);

            if (currentState == GoriyaState.Up)
            {
                spriteUp.Update(gameTime);
            }
            else if (currentState == GoriyaState.Down)
            {
                spriteDown.Update(gameTime);
            }
            else if (currentState == GoriyaState.Left)
            {
                spriteLeft.Update(gameTime);
            }
            else if (currentState == GoriyaState.Right)
            {
                spriteRight.Update(gameTime);
            }
        }
    }
}
