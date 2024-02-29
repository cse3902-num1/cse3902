using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class FiveRupiesItemPickup : BasicItemPickup
{
    public FiveRupiesItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
    }
}