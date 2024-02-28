using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class FairyItemPickup : BasicItemPickup
{
    public FairyItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(39, 0, 7, 15) });
    }
}
