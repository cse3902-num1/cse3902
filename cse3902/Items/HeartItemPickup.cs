using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902;

public class HeartItemPickup : BasicItemPickup
{
    public HeartItemPickup(GameContent content)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(0, 8, 7, 7) ,
                        new Rectangle(0, 0, 7, 7)},new Vector2(3.5f,3.5f));
    }
}