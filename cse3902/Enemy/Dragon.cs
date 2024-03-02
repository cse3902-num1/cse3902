using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public class Dragon : EnemyBase
    {
        
        private Fireball ballUp;
        private Fireball ballDown;
        private Fireball ballMid;
        public Dragon(GameContent content): base(content)
        {
            this.HP = 20;
            sprite = new Sprite(content.enemies,
                new List<Rectangle>()
                {
                    new Rectangle(1, 11, 25, 32),
                    new Rectangle(26, 11, 25, 32),
                    new Rectangle(51, 11, 25, 32),
                    new Rectangle(76, 11, 25, 32)
                }
            );

            ballUp = new Fireball(content, 
                new Vector2(-200f, -50f), 
                new Vector2(sprite.X, sprite.Y)
            );
            ballDown = new Fireball(content,
                new Vector2(-200f, +50f),
                new Vector2(sprite.X, sprite.Y)
            );
            ballMid = new Fireball(content,
                new Vector2(-200f, 0f),
                new Vector2(sprite.X, sprite.Y)
            );

            Position = new Vector2(500, 200);
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
            ballUp.Position = new Vector2(sprite.X, sprite.Y);
            ballDown.Position = new Vector2(sprite.X, sprite.Y);
            ballMid.Position = new Vector2(sprite.X, sprite.Y);
        }
        public override void TakeDmg(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                // Handle enemy's death like death animation
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);

            ballUp.Draw(spriteBatch);
            ballDown.Draw(spriteBatch);
            ballMid.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, IController controller)
        {
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
            ballUp.Update(gameTime, controller);
            ballDown.Update(gameTime, controller);
            ballMid.Update(gameTime, controller);

            Move(gameTime, randomNum);

            sprite.Update(gameTime, controller);
            /*if (BoxCollider.IsColliding(dragon.collider)) // Assuming you have a reference to the dragon
            {
                dragon.TakeDamage(damageAmount); // damageAmount is the damage this projectile does
                this.IsDead = true; // Optionally remove the projectile upon impact
            }
            */
        }


    }
}
