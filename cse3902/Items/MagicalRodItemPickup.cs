using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class MagicalRodItemPickup : BasicItemPickup
{
    public MagicalRodItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(225, 0, 6, 16) });
    }
}