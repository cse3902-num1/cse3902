using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using cse3902.RoomClasses;

namespace cse3902.Enemy
{
    
    public class Keese : EnemyBase
    {
        private float KeeseMoveSpeedEnermyConstant = 100f;
        private float GhostKeeseMoveSpeedEnermyConstant = 30f;
        private const int RandomChangeInterval = 500;
        public Keese(GameContent content, Room room) : base(content, room)
        {
            this.HP = 5;
            sprite = new Sprite(content.enemiesSheet,
                new List<Rectangle>()
                {
                    EnermyConstant.KeeseSpriteSheet1,
                    EnermyConstant.KeeseSpriteSheet2
                },
                EnermyConstant.KeeseOrigin
            );

            Position = EnermyConstant.KeeseInitialPosition;
            Collider = new BoxCollider(Position, EnermyConstant.KeeseColliderSize, EnermyConstant.KeeseColliderOrigin, ColliderType);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            if (IsGhost)
            {
                Vector2 playerPos = room.Player.Position;
                if (newPosition.X < playerPos.X)
                {
                    newPosition.X += GhostKeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (newPosition.X > playerPos.X)
                {
                    newPosition.X -= GhostKeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (newPosition.Y < playerPos.Y)
                {
                    newPosition.Y += GhostKeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (newPosition.Y > playerPos.Y)
                {
                    newPosition.Y -= GhostKeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {
                switch (randomNum)
                {
                    case 1:
                        newPosition.Y -= KeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 2:
                        newPosition.X -= KeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 3:
                        newPosition.X += KeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 4:
                        newPosition.Y += KeeseMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                }
            }
            Position = newPosition;
        }

        public override void Attack()
        {

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
