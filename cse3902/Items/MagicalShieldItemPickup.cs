using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalShieldItemPickup : BasicItemPickup
{
    public MagicalShieldItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(120, 0, 8, 16) });
    }
}