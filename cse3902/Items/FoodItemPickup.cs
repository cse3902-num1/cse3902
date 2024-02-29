using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class FoodItemPickup : BasicItemPickup
{
    public FoodItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(96, 0, 8, 16) });
    }
}