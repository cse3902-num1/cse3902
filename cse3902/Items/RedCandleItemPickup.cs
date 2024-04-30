using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RedCandleItemPickup : BasicItemPickup
{
    public RedCandleItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.RedCandleItemSourceRect}, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {

        //Debug.WriteLine("red candle item picked up");
        IsDead = true;
    }
}