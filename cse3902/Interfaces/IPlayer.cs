using cse3902.Interfaces;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
	public interface IPlayer : IGameObject
	{
        public Level level {set;get;} 
        public Direction Facing {set;get;}
        public ICollider Pushbox {set;get;}
        public PlayerInventory Inventory {set;get;}
        public void Move(Vector2 direction);
        public void Attack();
        public void UseItem(IInventoryItem item);
        public void TakeDamage();
    }
}

