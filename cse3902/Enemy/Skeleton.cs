using cse3902.Interfaces;
using cse3902.RoomClasses;
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
        public Skeleton(GameContent content, Room room) : base(content, room)
        {
            this.HP = 3;
            sprite = new Sprite(content.skeleton,
                new List<Rectangle>()
                {
                    EnermyConstant.SkeletonSpriteSheet1,
                    EnermyConstant.SkeletonSpriteSheet2
                },
                EnermyConstant.SkeletonOrigin
            );

            Position = EnermyConstant.SkeletonInitialPosition;
            Collider = new BoxCollider(Position, EnermyConstant.SkeletonColliderSize, EnermyConstant.SkeletonColliderOrigin, ColliderType);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            float speed = SkeletonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float ghostSpeed = GhostSkeletonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (IsGhost)
            {
                Vector2 playerPos = room.Player.Position;
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
    }
}
