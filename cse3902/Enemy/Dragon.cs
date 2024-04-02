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

        public Dragon(GameContent content, Room room): base(content, room)
        {
            this.HP = 20;
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 25, 32),
                    new Rectangle(26, 11, 25, 32),
                    new Rectangle(51, 11, 25, 32),
                    new Rectangle(76, 11, 25, 32),
                },
                new Vector2(12.5f, 16f)
            );

            Position = new Vector2(500, 200);
            Collider = new BoxCollider(Position, new Vector2(25 * 2, 32 * 2), new Vector2(12.5f * 2, 16f * 2), ColliderType.ENEMY);
            this.content = content;

            this.room = room;
        }

        public override void Move(GameTime gameTime, int randomNum)
        {
            Vector2 newPosition = Position;
            switch (randomNum)
            {
                case 1:
                    newPosition.X -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    newPosition.X += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    newPosition.Y -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    newPosition.Y += 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position = newPosition;
        }

        public override void Attack()
        {
            SoundManager.Manager.fireballSound();

            Fireball ballUp = new Fireball(content, 
                room,
                Position,
                new Vector2(-200f, -50f)
            );
            Fireball ballDown = new Fireball(content,
                room,
                Position,
                new Vector2(-200f, +50f)
            );
            Fireball ballMid = new Fireball(content,
                room,
                Position,
                new Vector2(-200f, 0f)
            );
            room.Projectiles.Add(ballUp);
            ballUp.isEnermyProjectile = true;
            room.Projectiles.Add(ballMid);
            ballMid.isEnermyProjectile = true;
            room.Projectiles.Add(ballDown);
            ballDown.isEnermyProjectile = true;
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


          
            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            if (attackTimer.ElapsedMilliseconds >= 3000)
            {
                attackTimer.Restart();
                Attack();
            }

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controllers);
            /*if (BoxCollider.IsColliding(dragon.collider)) // Assuming you have a reference to the dragon
            {
                dragon.TakeDamage(damageAmount); // damageAmount is the damage this projectile does
                this.IsDead = true; // Optionally remove the projectile upon impact
            }
            */
        }


    }
}
