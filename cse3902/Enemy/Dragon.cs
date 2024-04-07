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
    public class Dragon : EnemyBase
    {
        private GameContent content;
        private float DragonMoveSpeedConstant = 50f;
        private const int RandomChangeInterval = 500;  // Time in milliseconds
        private const int AttackInterval = 3000;
        public Dragon(GameContent content, Room room): base(content, room)
        {
            this.HP = 20;
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    Constant.DragonSpriteSheetAnimation1,
                    Constant.DragonSpriteSheetAnimation2,
                    Constant.DragonSpriteSheetAnimation3,
                    Constant.DragonSpriteSheetAnimation4,
                },
                Constant.DragonOrigin
            );
            Collider = new BoxCollider(Constant.DragonPosition, Constant.DragonColliderSize,Constant.DragonColliderOrigin, ColliderType.ENEMY);
            this.content = content;

            this.room = room;
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= DragonMoveSpeedConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += DragonMoveSpeedConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= DragonMoveSpeedConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += DragonMoveSpeedConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position = newPosition;
        }

        public override void Attack()
        {

            Vector2[] velocities = { Constant.DragonFireBallVelocity1, Constant.DragonFireBallVelocity2, Constant.DragonFireBallVelocity3 };

            foreach (Vector2 velocity in velocities)
            {
                Fireball ball = new Fireball(content, room, Position, velocity);
                ball.isEnermyProjectile = true;
                room.Projectiles.Add(ball);
            }
            SoundManager.Manager.fireballSound();
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
