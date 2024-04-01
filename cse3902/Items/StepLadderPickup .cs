using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class StepLadderItemPickup : BasicItemPickup
{
    public StepLadderItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(207, 0, 17, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("step ladder item picked up");
        IsDead = true;
    }
}