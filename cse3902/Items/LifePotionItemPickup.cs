using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class LifePotionItemPickup : BasicItemPickup
{
    public LifePotionItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
            new Rectangle(80, 15, 8, 16),
        });
    }
}