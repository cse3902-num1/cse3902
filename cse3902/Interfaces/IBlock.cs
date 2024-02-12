using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces
{
	public interface IBlock
	{
       
       public void draw(SpriteBatch spriteBatch);

       public void update(GameTime gameTime);
    }
}

