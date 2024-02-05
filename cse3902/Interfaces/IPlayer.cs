using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
	public interface IPlayer
	{
<<<<<<< HEAD
        void Update(GameTime gameTime);

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
       
        void Attack();

        // Add additional methods for other player actions as needed

        // Example additional methods:
        void UseItem();
        void TakeDamage();
        void BlockCycle();
        void ItemCycle();
        void CharacterCycle();
=======
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void Move(Vector2 direction);
        public void Attack();
        public void UseItem(int idx);
        public void TakeDamage();
>>>>>>> 82811393a008aa311cff966cb8f3598723aaaa11
    }
}

