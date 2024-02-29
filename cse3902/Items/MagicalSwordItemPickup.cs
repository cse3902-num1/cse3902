using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalSwordItemPickup : BasicItemPickup
{
    public MagicalSwordItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
    }
}