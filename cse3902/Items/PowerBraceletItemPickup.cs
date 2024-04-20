using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class PowerBraceletItemPickup : BasicItemPickup
{
    public PowerBraceletItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.PowerBraceletItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("power bracelet item picked up");
        IsDead = true;
    }
}
