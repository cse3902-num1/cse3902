using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalKeyItemPickup : BasicItemPickup
{
    public MagicalKeyItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(248, 0, 8, 16)});
    }
}