using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class YellowBoomerangItemPickup : BasicItemPickup
{
    public YellowBoomerangItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) });
    }
}
