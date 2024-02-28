using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class BombItemPickup : BasicItemPickup
{
    public BombItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(135, 0, 9, 14) });
    }
}
