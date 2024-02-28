using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class BookOfMagicItemPickup : BasicItemPickup
{
    public BookOfMagicItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(230, 0, 11, 16) });
    }
}