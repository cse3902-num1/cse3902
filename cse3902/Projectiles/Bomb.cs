using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Projectiles
{
    internal class Bomb : IProjectile
    {
        public bool IsDead {set;get;}
        private Vector2 velocity;
        private Sprite bomb;
        private BombExplode explode;
        private Stopwatch explodeTimer = new Stopwatch();
        
        public Bomb(GameContent content, Vector2 velocity, IPlayer player)
        {
            bomb = new Sprite(content.weapon, 
                new List<Rectangle>()
                {
                    new Rectangle(129, 185, 7, 15)
                },
                new Vector2(3.5f, 7.5f)
            );
            this.IsDead = false;
            if (velocity.X > 0)
            {
                bomb.Position = player.Position + new Vector2(20, 0);
            }
            if (velocity.X < 0)
            {
                bomb.Position = player.Position + new Vector2(-20, 0);
            }
            if (velocity.Y > 0)
            {
                bomb.Position = player.Position + new Vector2(0, 20);
            }
            if (velocity.Y < 0)
            {
                bomb.Position = player.Position + new Vector2(0, -20);
            }
            explode = new BombExplode(content, bomb.Position);
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Position
        {
            get { return bomb.Position; }
            set { bomb.Position = value; }
        }

        public void Update(GameTime gameTime)
        {
            
            bomb.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            explodeTimer.Start();
            if (explodeTimer.ElapsedMilliseconds <= 1500)
            {
                bomb.Draw(spriteBatch);
            }
            else
            {
                if (explodeTimer.ElapsedMilliseconds <= 1700)
                {
                    explode.Draw(spriteBatch);
                }
                else
                {
                    IsDead = true;
                }
            }
        }
    }
}
