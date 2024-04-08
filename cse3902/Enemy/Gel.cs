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
    public class Gel : EnemyBase
    {
        private float GelMoveSpeedEnermyConstant = 100f;
        private const int RandomChangeInterval = 500;
        public Gel(GameContent content, Room room) : base(content, room)
        {
            this.HP = 1;
            sprite = new Sprite(content.enemiesSheet,
            new List<Rectangle>()
            {
                EnermyConstant.GelSpriteSheetAnimation1,
                EnermyConstant.GelSpriteSheetAnimation2
            },
            EnermyConstant.GelOrigin
     );

            Position = EnermyConstant.GelInitialPosition;
            Collider = new BoxCollider(Position, EnermyConstant.GelColliderSize, EnermyConstant.GelColliderOrigin, ColliderType.ENEMY);
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += GelMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
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
