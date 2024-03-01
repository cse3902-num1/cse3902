using System;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Objects
{
    public abstract class BasicBlock : IBlock
	{
        public Vector2 Position {set;get;}
        protected ISprite sprite; /* set in constructor */

        public BasicBlock()
        {
            Position = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            sprite.Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(spriteBatch);
        }
    }
}

