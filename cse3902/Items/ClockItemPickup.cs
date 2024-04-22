using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class ClockItemPickUp : BasicItemPickup
{
    public ClockItemPickUp(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.ClockItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("Clock picked up");
        IsDead = true;
    }
}
