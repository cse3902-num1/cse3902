using cse3902.Items;
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
                        ItemsConstant.RaftItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("raft item picked up");
        IsDead = true;
    }
}