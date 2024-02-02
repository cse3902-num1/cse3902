using System;
using Microsoft.Xna.Framework;

namespace cse3902
{
	public interface IPlayer
	{
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
    }
}

