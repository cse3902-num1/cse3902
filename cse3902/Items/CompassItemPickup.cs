using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class CompassItemPickUp : BasicItemPickup
{
    public CompassItemPickUp(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(257, 1, 12, 13) });
    }
}
