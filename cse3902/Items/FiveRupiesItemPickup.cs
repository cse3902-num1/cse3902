using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FiveRupiesItemPickup : BasicItemPickup
{
    public FiveRupiesItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("five rubies picked up");
        IsDead = true;
    }
}