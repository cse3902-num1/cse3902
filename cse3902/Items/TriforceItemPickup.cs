using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class TriforceItemPickup : BasicItemPickup
{
    public TriforceItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(274, 3, 11, 12),
                        new Rectangle(274, 18, 11, 12)
                        }, new Vector2(3.5f, 3.5f));
    }
}