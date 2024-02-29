using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class RedRingItemPickup : BasicItemPickup
{
    public RedRingItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(168, 2, 8, 16) });
    }
}