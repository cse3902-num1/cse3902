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
        private const int AttackInterval = 300;
        private Level level;
        private double time = 0.0;

        public OldMan(GameContent content, Level level) : base(content)
        {
            this.HP = EnermyConstant.OLD_MAN_HEALTH;
            sprite = new Sprite(content.oldman,
                new List<Rectangle>()
                {
                    EnermyConstant.OldMan,
                },
                EnermyConstant.OldManOrigin,
                4.0f
            );
            Collider = new BoxCollider(EnermyConstant.OldManPosition, EnermyConstant.OldmanColliderSize, EnermyConstant.OldmanColliderOrigin, ColliderType.ENEMY);
            this.content = content;

            this.level = level;
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            time = gameTime.TotalGameTime.TotalSeconds;

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
                const float FIREBALL_SPEED = 200f;
                double angleOffset = time * Math.Tau * 0.05;
                int count = 4;
                for (double angle = angleOffset; angle < Math.Tau + angleOffset; angle += Math.Tau / count) {
                    Vector2 velocity = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * FIREBALL_SPEED;
                    Fireball f = new Fireball(content, level, Position, velocity);
                    f.isEnermyProjectile = true;
                    level.Projectiles.Add(f);
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

        public override void Die() {
            /* spawn 2 triforces and a health potion as reward */

            IItemPickup triforceDrop1 = new TriforceItemPickup(content, level);
            triforceDrop1.Position = Position + new Vector2(-8, 0);
            level.Items.Add(triforceDrop1);

            IItemPickup triforceDrop2 = new TriforceItemPickup(content, level);
            triforceDrop2.Position = Position + new Vector2(8, 0);
            level.Items.Add(triforceDrop2);

            IItemPickup healthDrop = new SecondPotionItemPickup(content, level);
            healthDrop.Position = Position + new Vector2(0, 0);
            level.Items.Add(healthDrop);

            base.Die();
        }
    }
}
