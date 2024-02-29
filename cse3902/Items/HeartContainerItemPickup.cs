using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class HeartContainerItemPickup : BasicItemPickup
{
    public HeartContainerItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(24, 0, 13, 14) });
    }
}