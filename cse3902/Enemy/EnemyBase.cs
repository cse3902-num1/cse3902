using cse3902.Interfaces;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace cse3902.Enemy
{
    public abstract class EnemyBase : IEnemy
    {
        public bool IsDead {set;get;}
        public Vector2 Position { get; set; }
        public ColliderType ColliderType { set; get; }
        public ICollider collider { set; get; }
        public int HP { get; set; } = 100;
        protected Sprite sprite;
        public ICollider Collider;
        protected Stopwatch randomChangeTimer = new Stopwatch();
        protected Stopwatch attackTimer = new Stopwatch();
        protected Random random = new Random();
        protected int randomNum;

        protected Room room;
        
        protected EnemyBase(GameContent content, Room room)
        {
            this.room = room;
            IsDead = false;
            // Initialize sprite and collider here based on specific enemy content
        }

        public virtual void Move(GameTime gameTime, int randomNum)
        {
            // Implement basic random movement logic here, if applicable
        }

        public virtual void Attack()
        {
        }

        public virtual void TakeDmg(int damage)
        {
            HP -= damage;
            Debug.Write("OUCH!");
            if (HP <= 0)
            {
                Die();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime, List<IController> controllers)
        {
            Collider.Position = Position;
        }

        public virtual void Die()
        {
            IsDead = true;
        }
    }
}
