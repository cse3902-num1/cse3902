using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
	public class Sprite: ISprite
	{
        private Vector2 position;

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
        public Sprite()
		{
            position = Vector2.Zero;
        }

		public void LoadContent(ContentManager content)
		{

		}

		public void Update(Game game, GameTime gameTime, List<InputState> inputStates)
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

