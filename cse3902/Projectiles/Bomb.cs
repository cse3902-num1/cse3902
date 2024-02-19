using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles
{
    internal class Bomb : IProjectile
    {
        private Vector2 velocity;
        private Sprite bomb;
        
        public Bomb(GameContent content)
        {
            bomb = new Sprite(content.weapon, 
                new List<Rectangle>()
                {
                    new Rectangle(129, 185, 7, 15)
                },
                new Vector2(3.5f, 7.5f)
            );
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
