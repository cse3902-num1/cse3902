using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MagicalShieldItemPickup : BasicItemPickup
{
    public MagicalShieldItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(120, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        Debug.WriteLine("magic shield picked up");
        IsDead = true;
    }
}