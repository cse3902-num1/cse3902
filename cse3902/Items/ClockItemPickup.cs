using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class ClockItemPickUp : BasicItemPickup
{
    public ClockItemPickUp(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(57, 0, 12, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("Clock picked up");
        IsDead = true;
    }
}
