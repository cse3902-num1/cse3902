using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class SwordItemPickup : BasicItemPickup
{
    public SwordItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
    }
}