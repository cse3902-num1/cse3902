using cse3902.Items;

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class BlueRingItemPickup : BasicItemPickup
{
    public BlueRingItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.BlueRingItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("Blue ring picked up");
        IsDead = true;
    }
}
