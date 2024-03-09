using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class StepLadderItemPickup : BasicItemPickup
{
    public StepLadderItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(207, 0, 17, 16) });
    }
}