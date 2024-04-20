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
    public class OldMan : EnemyBase
    {
        private GameContent content;
        private float OldManMoveSpeed = 20f;
        private const int RandomChangeInterval = 500;  // Time in milliseconds
        private const int AttackInterval = 200;
        public OldMan(GameContent content, Room room) : base(content, room)
        {
            this.HP = 30;
            sprite = new Sprite(content.oldman,
                new List<Rectangle>()
                {
                    EnermyConstant.OldMan,
                },
                EnermyConstant.OldManOrigin
            );
            Collider = new BoxCollider(EnermyConstant.OldManPosition, EnermyConstant.OldmanColliderSize, EnermyConstant.OldmanColliderOrigin, ColliderType.ENEMY);
            this.content = content;

            this.room = room;
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
                switch (randomNum)
                {
                    case 1:
                        newPosition.X -= OldManMoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 2:
                        newPosition.X += OldManMoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 3:
                        newPosition.Y -= OldManMoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 4:
                        newPosition.Y += OldManMoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                }
            
            Position = newPosition;
        }

        public override void Attack()
        {
            if (!IsGhost)
            {
                Vector2[] velocities = { EnermyConstant.OldmanFireBallVelocity1, EnermyConstant.OldmanFireBallVelocity2, EnermyConstant.OldmanFireBallVelocity3, EnermyConstant.OldmanFireBallVelocity4, EnermyConstant.OldmanFireBallVelocity5, EnermyConstant.OldmanFireBallVelocity6, EnermyConstant.OldmanFireBallVelocity7, EnermyConstant.OldmanFireBallVelocity8 };

                foreach (Vector2 velocity in velocities)
                {
                    Fireball ball = new Fireball(content, room, Position, velocity);
                    ball.isEnermyProjectile = true;
                    room.Projectiles.Add(ball);
                }
                SoundManager.Manager.fireballSound();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, List<IController> controllers)
        {
            base.Update(gameTime, controllers);

            randomChangeTimer.Start();
            attackTimer.Start();
            UpdateRandomNumber();
            TryAttack();
            Move(gameTime, randomNum);

            sprite.Update(gameTime, controllers);

        }
        private void UpdateRandomNumber()
        {
            if (randomChangeTimer.ElapsedMilliseconds >= RandomChangeInterval)
            {
                randomChangeTimer.Restart();
                randomNum = random.Next(1, 5);  // Assuming randomNum is declared elsewhere
            }
        }

        private void TryAttack()
        {
            if (attackTimer.ElapsedMilliseconds >= AttackInterval)
            {
                attackTimer.Restart();
                Attack();
            }
        }


    }
}
