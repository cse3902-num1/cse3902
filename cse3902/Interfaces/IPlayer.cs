using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
	public interface IPlayer
	{
        public Vector2 Position {set;get;}
        public Direction Facing {set;get;}
        public void Update(GameTime gameTime, KeyboardController keyboard);
        public void Draw(SpriteBatch spriteBatch);
        public void Move(Vector2 direction);
        public void Attack();
        public void UseItem(IInventoryItem item);
        public void SpawnProjectile(IProjectile projectile);
        public void TakeDamage();
    }
}

