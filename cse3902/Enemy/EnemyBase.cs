﻿using cse3902.Interfaces;
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
        public Vector2 Position { get; set; }
        public Vector2 Size { set; get; }
        public ColliderType ColliderType { set; get; }
        public int HP { get; set; } = 100;
        protected Sprite sprite;
        public ICollider collider;
        protected Stopwatch randomChangeTimer = new Stopwatch();
        protected Stopwatch attackTimer = new Stopwatch();
        protected Random random = new Random();
        protected int randomNum;

        protected Room room;
        
        protected EnemyBase(GameContent content, Room room)
        {
            this.room = room;
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
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
          
        }

        public abstract void Update(GameTime gameTime, List<IController> controllers);
    }
}
