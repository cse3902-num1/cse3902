using cse3902.Interfaces;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902.Enemy
{
    public class Dragon : EnemyBase
    {
        
        private List<IProjectile> projectiles;

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

            projectiles = new List<IProjectile>();

            // ballUp = new Fireball(content, 
            //     new Vector2(-200f, -50f), 
            //     new Vector2(sprite.X, sprite.Y)
            // );
            // ballDown = new Fireball(content,
            //     new Vector2(-200f, +50f),
            //     new Vector2(sprite.X, sprite.Y)
            // );
            // ballMid = new Fireball(content,
            //     new Vector2(-200f, 0f),
            //     new Vector2(sprite.X, sprite.Y)
            // );

            Position = new Vector2(500, 200);
            Collider = new BoxCollider(Position, new Vector2(25, 32), new Vector2(12.5f, 16f), ColliderType.ENEMY);
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
            projectiles.Add(ballUp);
            projectiles.Add(ballMid);
            projectiles.Add(ballDown);
        }
        public override void TakeDmg(int damage)
        {
            HP -= damage;
            Debug.Write("OUCH!");
            if (HP <= 0)
            {
                // Handle enemy's death like death animation
                Die();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);

            projectiles.ForEach(p => p.Draw(spriteBatch));
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

            projectiles.ForEach(p => p.Update(gameTime, controllers));
            
            /* remove dead projectiles */
            projectiles = projectiles.Where(p => !p.IsDead).ToList();

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
