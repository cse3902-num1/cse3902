using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class ClockItemPickUp : BasicItemPickup
{
    public ClockItemPickUp(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(57, 0, 12, 16) });
    }
}
