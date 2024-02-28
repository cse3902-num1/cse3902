using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class FireItemPickUp : BasicItemPickup
{
    public FireItemPickUp(GameContent content)
    {
        sprite = new Sprite(content.mergedSheet, new List<Rectangle>() {
            new Rectangle(192, 236, 16, 16),
            new Rectangle(535, 237, 16, 16),
        });
    }
}