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
    internal class ArrowExplode : IProjectile
    {
        public bool IsDead {set;get;}
        private Vector2 velocity;
        private Sprite explode;

        public ArrowExplode(GameContent content)
        {
            explode = new Sprite(content.weapon,
                new List<Rectangle>()
                {
                    new Rectangle(53, 185, 7, 15)
                },
                new Vector2(3.5f, 7.5f)
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
            get { return explode.Position; }
            set { explode.Position = value; }
        }

        public void Update(GameTime gameTime)
        {
            explode.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            explode.Draw(spriteBatch);
        }
    }
}
