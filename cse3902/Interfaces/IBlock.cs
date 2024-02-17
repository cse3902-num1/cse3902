using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces
{
	public interface IBlock
	{
       
       public void Draw(SpriteBatch spriteBatch);

       public void Update(GameTime gameTime, IController controller);
    }
}

