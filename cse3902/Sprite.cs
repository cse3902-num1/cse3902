using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class Sprite : ISprite
    {
        private Vector2 position;
        private Texture2D texture2D;
             

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        //need sprite
        public Sprite(Texture2D _texture2D,ContentManager content)
        {
            position = Vector2.Zero;
            texture2D = _texture2D;
        }


        public void Update(Game game, GameTime gameTime)
        {

        }

        public void Draw(Game game, GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        // Set the position of the sprite
        public void SetPosition(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Set the state of the sprite
        public void SetState(string state)
        {
            // Implement logic to change the state of the sprite
        }

    }
}

