using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Goriya : EnemyBase
    {
        private enum GoriyaState { Left, Right, Up, Down }
        private GoriyaState currentState = GoriyaState.Down;
        private Sprite spriteUp;
        private Sprite spriteDown;
        private Sprite spriteLeft;
        private Sprite spriteRight;
        private Sprite currentSprite;
        private GreenBoomerang greenBoomerang;
        private bool isAttack;
        private bool goingBack = false;

        public Goriya(GameContent content) : base(content)
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
            currentSprite = spriteDown;

            greenBoomerang = new GreenBoomerang(content,
                new Vector2(0f, 0f),
                new Vector2(0f, 0f)
            );

            Position = new Vector2(400, 200);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            float totalTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (currentState)
            {
                case GoriyaState.Up:
                    Position += new Vector2(0, -0) * 100f * totalTime;
                    break;
                case GoriyaState.Left:
                    Position += new Vector2(-1, 0) * 100f * totalTime;
                    break;
                case GoriyaState.Right:
                    Position += new Vector2(1, 0) * 100f * totalTime;
                    break;
                case GoriyaState.Down:
                    Position += new Vector2(0, 1) * 100f * totalTime;
                    break;
            }
        }

        public void ChangeAction(int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    currentState = GoriyaState.Up;
                    currentSprite = spriteUp;
                    break;
                case 2:
                    currentState = GoriyaState.Down;
                    currentSprite = spriteDown;
                    break;
                case 3:
                    currentState = GoriyaState.Left;
                    currentSprite = spriteLeft;
                    break;
                case 4:
                    currentState = GoriyaState.Right;
                    currentSprite = spriteRight;
                    break;
                case 5: Attack(); break;
            }
        }

        public override void Attack()
        {
            isAttack = true;
            greenBoomerang.Position = Position;
        }

        public override void TakeDmg(int damage)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Position = Position;
            currentSprite.Draw(spriteBatch);

            if (isAttack)
            {
                greenBoomerang.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
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
                greenBoomerang.Update(gameTime, controllers);
            }
            else
            {
                Move(gameTime, randomNum);
                ChangeAction(randomNum);
            }

            currentSprite.Update(gameTime, controllers);
        }
    }
}
