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
    public class Skeleton : EnemyBase
    {
        private float SkeletonMoveSpeedEnermyConstant = 100f;
        private float GhostSkeletonMoveSpeedEnermyConstant = 30f;
        private const int RandomChangeInterval = 500;
        private Level level;
        private GameContent content;
        public Skeleton(GameContent content, Level level) : base(content)
        {
            this.HP = EnermyConstant.SKELETON_HEALTH;
            sprite = new Sprite(content.skeleton,
                new List<Rectangle>()
                {
                    EnermyConstant.SkeletonSpriteSheet1,
                    EnermyConstant.SkeletonSpriteSheet2
                },
                EnermyConstant.SkeletonOrigin
            );
            this.level = level;
            Position = EnermyConstant.SkeletonInitialPosition;
            Collider = new BoxCollider(Position, EnermyConstant.SkeletonColliderSize, EnermyConstant.SkeletonColliderOrigin, ColliderType);
            
            this.content = content;
        }
        /*if Skeleton is in nightmare mode, when Skeleton is dying it will follow player, and still take damage.
         * Otherwise it moves randomly*/
        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            float speed = SkeletonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float ghostSpeed = GhostSkeletonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (IsGhost)
            {
                Vector2 playerPos = level.player.Position;
                if (newPosition.X < playerPos.X)
                {
                    newPosition.X += ghostSpeed;
                }
                else if (newPosition.X > playerPos.X)
                {
                    newPosition.X -= ghostSpeed;
                }
                if (newPosition.Y < playerPos.Y)
                {
                    newPosition.Y += ghostSpeed;
                }
                else if (newPosition.Y > playerPos.Y)
                {
                    newPosition.Y -= ghostSpeed;
                }
            }
            else
            {
            
                switch (randomNum)
                {
                    case 1:
                        newPosition.Y -= speed;
                        break;
                    case 2:
                        newPosition.X -= speed;
                        break;
                    case 3:
                        newPosition.X += speed;
                        break;
                    case 4:
                        newPosition.Y += speed;
                        break;
               }
            }
            Position = newPosition;
        }
        //update base class and timer.
        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            base.Update(gameTime, controllers);

            randomChangeTimer.Start();
            if (randomChangeTimer.ElapsedMilliseconds >= RandomChangeInterval)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controllers);
        }

        public override void Die() {
            /* spawn some projectiles */
            Vector2 velocity = Vector2.Normalize(level.player.Position - Position) * 200;
            Fireball f = new Fireball(content, level, Position, velocity);
            f.isEnermyProjectile = true;
            level.SpawnProjectile(f);

            base.Die();
        }
    }
}
