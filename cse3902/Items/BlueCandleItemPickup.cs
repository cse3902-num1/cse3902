using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class BlueCandleItemPickup : BasicItemPickup
{
    public BlueCandleItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(160, 16, 8, 16) });
    }
}
