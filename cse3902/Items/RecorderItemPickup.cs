
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RecorderItemPickup : BasicItemPickup
{
    public RecorderItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(187, 0, 5, 17) }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {

        //Debug.WriteLine("recorder  item picked up");
        IsDead = true;
    }
}