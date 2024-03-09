using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class RaftItemPickup : BasicItemPickup
{
    public RaftItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(192, 0, 16, 16) });
    }
}