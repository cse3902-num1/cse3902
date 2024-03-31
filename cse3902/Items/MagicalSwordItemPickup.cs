using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalSwordItemPickup : BasicItemPickup
{
    public MagicalSwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
    }
}