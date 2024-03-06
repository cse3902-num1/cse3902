using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        private GreenBoomerang greenBoomerang;
        private bool isAttack;
        private bool goingBack = false;

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
            spriteDown.SetPosition(400, 200);
            spriteUp.SetPosition(400, 200);
            spriteLeft.SetPosition(400, 200);
            spriteRight.SetPosition(400, 200);
            greenBoomerang = new GreenBoomerang(content,
                new Vector2(0f, 0f),
                new Vector2(0f, 0f)
            );
        }

        public Vector2 Position
        {
            get { return spriteUp.Position; }
            set { spriteUp.Position = value;
                spriteDown.Position = value;
                spriteLeft.Position = value;
                spriteRight.Position = value;
            }
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

        public void ChangeAction(int randomNum)
        {
            switch (randomNum)
            {
                case 1: currentState = GoriyaState.Up; break;
                case 2: currentState = GoriyaState.Down; break;
                case 3: currentState = GoriyaState.Left; break;
                case 4: currentState = GoriyaState.Right; break;
                case 5: Attack(); break;
            }
        }

        public void Attack()
        {
            isAttack = true;
            greenBoomerang.Position = new Vector2(spriteUp.X, spriteUp.Y);
        }

        public void TakeDmg()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentState)
            {
                case GoriyaState.Up: spriteUp.Draw(spriteBatch); break;
                case GoriyaState.Down: spriteDown.Draw(spriteBatch); break;
                case GoriyaState.Left: spriteLeft.Draw(spriteBatch); break;
                case GoriyaState.Right: spriteRight.Draw(spriteBatch); break;
            }
            if (isAttack)
            {
                greenBoomerang.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 6);
            }

            if (isAttack)
            {
                if (!goingBack)
                {
                    switch (currentState)
                    {
                        case GoriyaState.Up: greenBoomerang.Velocity = new Vector2(0f, -100f); break;
                        case GoriyaState.Down: greenBoomerang.Velocity = new Vector2(0f, 100f); break;
                        case GoriyaState.Left: greenBoomerang.Velocity = new Vector2(-100f, 0f); break;
                        case GoriyaState.Right: greenBoomerang.Velocity = new Vector2(100f, 0f); break;
                    }
                }
                else
                {
                    switch (currentState)
                    {
                        case GoriyaState.Up: greenBoomerang.Velocity = new Vector2(0f, 100f); break;
                        case GoriyaState.Down: greenBoomerang.Velocity = new Vector2(0f, -100f); break;
                        case GoriyaState.Left: greenBoomerang.Velocity = new Vector2(100f, 0f); break;
                        case GoriyaState.Right: greenBoomerang.Velocity = new Vector2(-100f, 0f); break;
                    }
                }

                if (Math.Abs(greenBoomerang.Position.X - spriteUp.X) > 100f
                    || Math.Abs(greenBoomerang.Position.Y - spriteUp.Y) > 100f)
                {
                    goingBack = true;
                }
                if (goingBack && Math.Abs(greenBoomerang.Position.X - spriteUp.X) < 10f
                    && Math.Abs(greenBoomerang.Position.Y - spriteUp.Y) < 10f)
                {
                    isAttack = false;
                    goingBack = false;
                }
                greenBoomerang.Update(gameTime);
            }
            else
            {
                Move(gameTime, randomNum);
                ChangeAction(randomNum);
            }

            switch(currentState)
            {
                case GoriyaState.Up: spriteUp.Update(gameTime); break;
                case GoriyaState.Down: spriteDown.Update(gameTime); break;
                case GoriyaState.Left: spriteLeft.Update(gameTime); break;
                case GoriyaState.Right: spriteRight.Update(gameTime); break;
            }
        }
    }
}
