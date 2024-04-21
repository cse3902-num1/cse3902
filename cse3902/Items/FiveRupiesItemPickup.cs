using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FiveRupiesItemPickup : BasicItemPickup
{
    public FiveRupiesItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.FiveRupiesItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.Rubies += 5;
        Debug.WriteLine("five rubies picked up");
        IsDead = true;
    }
}