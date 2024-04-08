using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FoodItemPickup : BasicItemPickup
{
    public FoodItemPickup(GameContent content, Room room) : base(room)
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