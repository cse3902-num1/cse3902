using cse3902.Interfaces;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private float GoriyaMoveSpeedEnermyConstant = 100f;
        private const int RandomChangeInterval = 500;
        private GameContent content;

        public Goriya(GameContent content, Room room) : base(content, room)
        {
            this.HP = 7;
            spriteUp = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    EnermyConstant.GoriyaSpriteSheetUp1,
                    EnermyConstant.GoriyaSpriteSheetUp2
                },
                EnermyConstant.GoriyaOrigin
            );
            spriteDown = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    EnermyConstant.GoriyaSpriteSheetDown1,
                    EnermyConstant.GoriyaSpriteSheetDown2,
                },
                EnermyConstant.GoriyaOrigin
            );
            spriteRight = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    EnermyConstant.GoriyaSpriteSheetRight1,
                    EnermyConstant.GoriyaSpriteSheetRight2,
                },
                EnermyConstant.GoriyaOrigin
            );
            spriteLeft = new Sprite(content.goriya,
                new List<Rectangle>()
                {
                    EnermyConstant.GoriyaSpriteSheetLeft1,
                    EnermyConstant.GoriyaSpriteSheetLeft2,
                },
                EnermyConstant.GoriyaOrigin
            );
            currentSprite = spriteDown;

            Position = EnermyConstant.GoriyaInitialPosition;

            projectile = null;
            Collider = new BoxCollider(Position, EnermyConstant.GoriyaColliderSize, EnermyConstant.GoriyaColliderOrigin, ColliderType);
            this.content = content;
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            float totalTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (currentState)
            {
                case GoriyaState.Up:
                    Position += EnermyConstant.moveUpOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                    break;
                case GoriyaState.Left:
                    Position += EnermyConstant.moveLeftOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                    break;
                case GoriyaState.Right:
                    Position += EnermyConstant.moveRightOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                    break;
                case GoriyaState.Down:
                    Position += EnermyConstant.moveDownOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
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
            SoundManager.Manager.arrowBoomerangSound();

            Vector2 velocity = new Vector2(0, 0);
            switch (currentState)
            {
                case GoriyaState.Left:
                    velocity = EnermyConstant.moveLeftOneUnit;
                    break;
                case GoriyaState.Right:
                    velocity = EnermyConstant.moveRightOneUnit;
                    break;
                case GoriyaState.Up:
                    velocity = EnermyConstant.moveUpOneUnit;
                    break;
                case GoriyaState.Down:
                    velocity = EnermyConstant.moveDownOneUnit;
                    break;
            }
            velocity *= 200f;
            projectile = new GreenBoomerang(content, room, Position, velocity);
            projectile.isEnermyProjectile = true;

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
            base.Update(gameTime, controllers);

            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= RandomChangeInterval)
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
