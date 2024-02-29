using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class BlueRingItemPickup : BasicItemPickup
{
    public BlueRingItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(168, 18, 8, 16) });
    }
}
