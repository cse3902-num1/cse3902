using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
	public interface IPlayer : IGameObject
	{
        public Direction Facing {set;get;}
        public void Move(Vector2 direction);
        public void Attack();
        public void UseItem(IInventoryItem item);
        public void SpawnProjectile(IProjectile projectile);
        public void TakeDamage();
    }
}

