using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class WhiteSwordItemPickup : BasicItemPickup
{
    public WhiteSwordItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 16, 8, 16) });
    }
}