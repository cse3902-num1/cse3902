using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RaftItemPickup : BasicItemPickup
{
    public RaftItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(192, 0, 16, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("raft item picked up");
        IsDead = true;
    }
}