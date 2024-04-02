﻿using cse3902.Interfaces;
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

namespace cse3902.Enemy
{
    public abstract class EnemyBase : IEnemy
    {
        public bool IsDead {set;get;}

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
            SoundManager.Manager.enemyDamageSound();
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
            // foreach (Block block in room.Blocks)
            // {
            //     if (Collider.IsColliding(block.Collider))
            //     {
            //         BoxCollider blockBoxCollider = (BoxCollider)block.Collider; // Cast to BoxCollider if sure it is BoxCollider

            //         // GetOverlap should probably take another BoxCollider, not a list of Blocks
            //         Vector2 overlap = Collider.GetOverlap(blockBoxCollider);
            //         Vector2 reconciliation = new Vector2(-20000, -20000);
            //         //reconciliation  += CollisionResolver.CollisionMove(Collider, blockBoxCollider, overlap.X,overlap.Y);
            //         Debug.WriteLine("Before: " + Collider.Position);
            //         Collider.Position += reconciliation;
            //         Debug.WriteLine("After: " + Collider.Position);
            //     }

            // }

        }

        public virtual void Die()
        {
            SoundManager.Manager.enemyDeadSound();
            IsDead = true;
        }
    }
}
