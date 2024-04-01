using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FairyItemPickup : BasicItemPickup
{
    public FairyItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(39, 0, 7, 15) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("fairy item picked up");
        IsDead = true;
    }
}
