using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FireItemPickUp : BasicItemPickup
{
    public FireItemPickUp(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.mergedSheet, new List<Rectangle>() {
            ItemsConstant.FireItemAnimationSourceRect1,
             ItemsConstant.FireItemAnimationSourceRect2,
        });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("fire picked up");
        IsDead = true;
    }
}