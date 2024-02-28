using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MapItemPickup : BasicItemPickup
{
    public MapItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(87, 0, 8, 15) });
    }
}