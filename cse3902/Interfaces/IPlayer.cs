using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
	public interface IPlayer
	{
        public void Update(GameTime gameTime,IController keyboard);
        public void Draw(SpriteBatch spriteBatch);
        public void Move(Vector2 direction);
        public void Attack();
        public void UseItem(int idx);
        public void TakeDamage();
    }
}

