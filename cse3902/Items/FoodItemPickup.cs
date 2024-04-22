using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FoodItemPickup : BasicItemPickup
{
    public FoodItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.FoodItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("food item picked up");
        IsDead = true;
    }
}