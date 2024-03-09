using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class RupyItemPickup : BasicItemPickup
{
    public RupyItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                                new Rectangle(71, 16, 9, 16) ,
                                new Rectangle(71, 0, 9, 16)
                            }, new Vector2(3.5f, 3.5f));
    }
}