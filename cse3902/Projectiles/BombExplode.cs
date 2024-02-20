using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Projectiles
{
    internal class BombExplode : IProjectile
    {
        public bool IsDead {set;get;}
        private Vector2 velocity;
        private Sprite bomb;

        public BombExplode(GameContent content)
        {
            bomb = new Sprite(content.weapon,
                new List<Rectangle>()
                {
                    new Rectangle(138, 185, 15, 15),
                    new Rectangle(155, 185, 15, 15),
                    new Rectangle(172, 185, 15, 15)
                },
                new Vector2(7.5f, 7.5f)
            );
            this.IsDead = false;
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
            bomb.Draw(spriteBatch);
        }
    }
}
