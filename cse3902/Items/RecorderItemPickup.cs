using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RecorderItemPickup : BasicItemPickup
{
    public RecorderItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(187, 0, 5, 17) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("recorder  item picked up");
        IsDead = true;
    }
}