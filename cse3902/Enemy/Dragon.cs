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
    public class Dragon : EnemyBase
    {
        private GameContent content;
        private float DragonMoveSpeedEnermyConstant = 50f;
        private float GhostDragonMoveSpeedEnermyConstant = 30f;
        private const int RandomChangeInterval = 500;  // Time in milliseconds
        private const int AttackInterval = 3000;
        private Level level;
        public Dragon(GameContent content, Level level): base(content)
        {
            this.HP = EnermyConstant.DRAGON_HEALTH;
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    EnermyConstant.DragonSpriteSheetAnimation1,
                    EnermyConstant.DragonSpriteSheetAnimation2,
                    EnermyConstant.DragonSpriteSheetAnimation3,
                    EnermyConstant.DragonSpriteSheetAnimation4,
                },
                EnermyConstant.DragonOrigin
            );
            Collider = new BoxCollider(EnermyConstant.DragonPosition, EnermyConstant.DragonColliderSize,EnermyConstant.DragonColliderOrigin, ColliderType.ENEMY);
            this.content = content;
            this.level = level;

        }
        /*if dragon is in nightmare mode, when dragon is dying it will follow player, and still take damage.
         * Otherwise it moves randomly*/
        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            
            if (IsGhost)
            {
                Vector2 playerPos = level.player.Position;
                if (newPosition.X < playerPos.X)
                {
                    newPosition.X += GhostDragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                } 
                else if (newPosition.X > playerPos.X)
                {
                    newPosition.X -= GhostDragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (newPosition.Y < playerPos.Y)
                {
                    newPosition.Y += GhostDragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (newPosition.Y > playerPos.Y)
                {
                    newPosition.Y -= GhostDragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            
            else
            {
            
                switch (randomNum)
                {
                    case 1:
                        newPosition.X -= DragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 2:
                        newPosition.X += DragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 3:
                        newPosition.Y -= DragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 4:
                        newPosition.Y += DragonMoveSpeedEnermyConstant * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                }
         
        }
        

            Position = newPosition;
        }
        /*In Advanture mode Attack using fireball for all directions.
         * In Nightmare mode is not attacking
         */
        public override void Attack()
        {

            if (IsGhost) return;


            /* spawn several rings of fireballs, with different speeds and # of fireballs */
            double speed = 50.0;
            int fireballCount = 8;
            double angleOffset = random.NextDouble() * Math.Tau;
            for (int ring = 0; ring < 4; ring++) {

                for (double angle = angleOffset; angle < Math.Tau + angleOffset; angle += Math.Tau / fireballCount) {
                    double xvelocity = Math.Sin(angle) * speed;
                    double yvelocity = Math.Cos(angle) * speed;
                    Fireball f = new Fireball(content, level, Position, new Vector2((float) xvelocity, (float) yvelocity));
                    f.isEnermyProjectile = true;
                    level.Projectiles.Add(f);
                }

                speed += 25.0;
                fireballCount += 3;
            }

            SoundManager.Manager.fireballSound();
        }
        // update dragon position and draw dragon
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            if (IsGhost)
            {
                sprite.setAlpha(0.4f);
            }
            sprite.Draw(spriteBatch);
        }
        // update timer, movement etc.
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
            /* spawn a triforce and a health potion as reward */

            IItemPickup triforceDrop = new TriforceItemPickup(content, level);
            triforceDrop.Position = Position + new Vector2(-4, 0);
            level.Items.Add(triforceDrop);

            IItemPickup healthDrop = new SecondPotionItemPickup(content, level);
            healthDrop.Position = Position + new Vector2(4, 0);
            level.Items.Add(healthDrop);

            base.Die();
        }
    }
}
