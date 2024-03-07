using cse3902.Interfaces;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        private IProjectile projectile;

        private GameContent content;

        public Goriya(GameContent content, Room room) : base(content, room)
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

            Position = new Vector2(400, 200);

            projectile = null;
            collider = new BoxCollider(Position, Size, ColliderType);
            this.content = content;
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
            if (projectile != null) {
                return;
            }

            Vector2 velocity = new Vector2(0, 0);
            switch (currentState)
            {
                case GoriyaState.Left:
                    velocity = new Vector2(-1, 0);
                    break;
                case GoriyaState.Right:
                    velocity = new Vector2(1, 0);
                    break;
                case GoriyaState.Up:
                    velocity = new Vector2(0, -1);
                    break;
                case GoriyaState.Down:
                    velocity = new Vector2(0, 1);
                    break;
            }
            velocity *= 200f;
            projectile = new GreenBoomerang(content, room, Position, velocity);
        }

        public override void TakeDmg(int damage)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Position = Position;
            currentSprite.Draw(spriteBatch);
            if (projectile is not null) {
                projectile.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 6);
            }

            if (projectile is not null) {
                projectile.Update(gameTime, controllers);

                /* filter out dead projectiles */
                if (projectile.IsDead) {
                    projectile = null;
                }
            }

            /* only move if boomerang has returned */
            // if (projectiles.Count == 0) {
                Move(gameTime, randomNum);
                ChangeAction(randomNum);
            // }

            currentSprite.Update(gameTime, controllers);
        }
    }
}
