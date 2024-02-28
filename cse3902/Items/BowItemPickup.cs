using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class BowItemPickup : BasicItemPickup
{
    public BowItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(144, 0, 8, 16) });
    }
}
