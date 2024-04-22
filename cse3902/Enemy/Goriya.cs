using cse3902.Interfaces;
using cse3902.Projectiles;

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
        private float GhostGoriyaMoveSpeedEnermyConstant = 30f;
        private const int RandomChangeInterval = 500;
        private GameContent content;
        private Level level;
        public Goriya(GameContent content, Level level) : base(content)
        {
            this.HP = EnermyConstant.GORIYA_HEALTH;
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
            this.level = level;
        }
        /*if Goriya is in nightmare mode, when Goriya is dying it will follow player, and still take damage.
         * Otherwise it moves randomly*/
        public override void Move(GameTime gameTime, int randomNum)
        {
            float totalTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (IsGhost)
            {
                Vector2 playerPos = level.player.Position;
                if (Position.X <= playerPos.X && Position.Y <= playerPos.Y)
                {
                    currentSprite = spriteRight;
                    Position += Constant.moveDownOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                    Position += Constant.moveRightOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                }
                else if (Position.X <= playerPos.X && Position.Y > playerPos.Y)
                {
                    currentSprite = spriteRight;
                    Position += Constant.moveRightOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                    Position += Constant.moveUpOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                }
                else if (Position.X > playerPos.X && Position.Y <= playerPos.Y)
                {
                    currentSprite = spriteLeft;
                    Position += Constant.moveLeftOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                    Position += Constant.moveDownOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                }
                else if (Position.X > playerPos.X && Position.Y > playerPos.Y)
                {
                    currentSprite = spriteLeft;
                    Position += Constant.moveLeftOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                    Position += Constant.moveUpOneUnit * GhostGoriyaMoveSpeedEnermyConstant * totalTime;
                }
            }
            else
            {
            
                switch (currentState)
                {
                    case GoriyaState.Up:
                        Position += Constant.moveUpOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                        break;
                    case GoriyaState.Left:
                        Position += Constant.moveLeftOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                        break;
                    case GoriyaState.Right:
                        Position += Constant.moveRightOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                        break;
                    case GoriyaState.Down:
                        Position += Constant.moveDownOneUnit * GoriyaMoveSpeedEnermyConstant * totalTime;
                        break;
                }
            }
        }
        /*randonly changing goria's action between move in different direction or attack
         */
        public void ChangeAction(int randomNum)
        {
            if (!IsGhost)
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
        }
        /*In advanture mode goriya will move and throw boomering
         */
        public override void Attack()
        {
            if (projectile != null || IsGhost) {
                return;
            }
            SoundManager.Manager.arrowBoomerangSound();

            Vector2 velocity = new Vector2(0, 0);

            if (level.player != null) {
                velocity = Vector2.Normalize(level.player.Position - Position) * 1.0f;

            } else switch (currentState) {
                case GoriyaState.Left:
                    velocity = Constant.moveLeftOneUnit;
                    break;
                case GoriyaState.Right:
                    velocity = Constant.moveRightOneUnit;
                    break;
                case GoriyaState.Up:
                    velocity = Constant.moveUpOneUnit;
                    break;
                case GoriyaState.Down:
                    velocity = Constant.moveDownOneUnit;
                    break;
            }

            velocity *= 200f;
            projectile = new GreenBoomerang(content, level, Position, velocity);
            projectile.isEnermyProjectile = true;
        }
        // if in advanture mode set transparent to 0.4 , otherwise draw goriya without transparent.
        public override void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Position = Position;
            if (IsGhost)
            {
                currentSprite.setAlpha(0.4f);
            }
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
                Move(gameTime, randomNum);
                ChangeAction(randomNum);

            currentSprite.Update(gameTime, controllers);
        }
    }
}
