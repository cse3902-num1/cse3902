using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class PowerBraceletItemPickup : BasicItemPickup
{
    public PowerBraceletItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(175, 0, 10, 16) });
    }
}