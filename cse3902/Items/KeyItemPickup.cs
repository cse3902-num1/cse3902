using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class KeyItemPickup : BasicItemPickup
{
    public KeyItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(240, 0, 8, 15) });
    }
}