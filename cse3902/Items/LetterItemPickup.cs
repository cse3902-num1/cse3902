using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class LetterItemPickup : BasicItemPickup
{
    public LetterItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(87, 16, 8, 15) });
    }
}