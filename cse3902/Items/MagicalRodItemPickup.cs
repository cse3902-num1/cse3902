using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalRodItemPickup : BasicItemPickup
{
    public MagicalRodItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(225, 0, 6, 16) });
    }
}