using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class RecorderItemPickup : BasicItemPickup
{
    public RecorderItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(187, 0, 5, 17) });
    }
}