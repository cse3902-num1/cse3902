using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class HeartContainerItemPickup : BasicItemPickup
{
    public HeartContainerItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(24, 0, 13, 14) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("heart container picked up");
        IsDead = true;
    }
}