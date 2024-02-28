using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class RedCandleItemPickup : BasicItemPickup
{
    public RedCandleItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(160, 0, 8, 16) });
    }
}