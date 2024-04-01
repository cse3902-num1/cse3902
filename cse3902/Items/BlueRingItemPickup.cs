using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class BlueRingItemPickup : BasicItemPickup
{
    public BlueRingItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(168, 18, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("Blue ring picked up");
        IsDead = true;
    }
}
