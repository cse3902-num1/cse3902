using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Enemy
{
    public abstract class EnemyBase : IEnemy
    {
        public Vector2 Position { get; set; }
        public int HP { get; set; } = 100;
        protected Sprite sprite;
        public ICollider collider;
        protected Stopwatch randomChangeTimer = new Stopwatch();
        protected Stopwatch attackTimer = new Stopwatch();
        protected Random random = new Random();
        protected int randomNum;

        protected EnemyBase(GameContent content)
        {
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
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine("testing");
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
          
        }

        

        public abstract void Update(GameTime gameTime, IController controller);

    }
}
