using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace cse3902.Blocks
{
	public class Tile: IBlock
	{
		public Tile()
		{
		}

        public bool IsVisible {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void update(GameTime gameTime) { 
        
           
        }
    }
}

