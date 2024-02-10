using System;
using Microsoft.Xna.Framework;

namespace cse3902
{
	public interface IItem
	{
        public Vector2 Position { get; set; }

        public void Use(Player player)
        {
            // Implement logic for using the item on the player
            // Example: Increase player's health, change player's state, etc.
        }
    }
}

