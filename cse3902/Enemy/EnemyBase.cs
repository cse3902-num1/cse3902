using cse3902.Games;
using cse3902.Interfaces;
using cse3902.Objects;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace cse3902.Enemy
{
    public abstract class EnemyBase : IEnemy
    {
        public bool IsDead {set;get;}

        public bool IsGhost { set;get;}

        private Vector2 _position;
        public Vector2 Position {
            get {
                return _position;
            }
            set {
                _position = value;
                if (collider is not null) {
                    collider.Position = value;
                }
                if (sprite is not null) {
                    sprite.Position = value;
                }
            }
        }
        public ColliderType ColliderType { set; get; }
        public ICollider collider
        {
            get { return Collider; }
            set { Collider = value; }
        }
        public int HP { get; set; } = 100;
        //ICollider IEnemy.Collider { get; set; }

        protected Sprite sprite;
        public ICollider Collider;
        protected Stopwatch randomChangeTimer = new Stopwatch();
        protected Stopwatch attackTimer = new Stopwatch();
        protected Random random = new Random();
        protected int randomNum;

        
        protected EnemyBase(GameContent content)
        {

            IsDead = false;
            IsGhost = false;
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
            SoundManager.Manager.enemyDamageSound();
            HP -= damage;
            if (HP <= 0)
            {
                Die();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            if (IsGhost)
            {
                sprite.setAlpha(0.4f);
            }
            sprite.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime, List<IController> controllers)
        {
            Collider.Position = Position;

        }

        public virtual void Die()
        {
            SoundManager.Manager.enemyDeadSound();
            if (Game1.isNightmare)
            {
                IsGhost = true;
            } 
            else
            {
                IsDead = true;
                Debug.WriteLine(IsDead);
            }
        }
    }
}
