using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class BlueCandleItemPickup : BasicItemPickup
{
    public BlueCandleItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.BlueCandleItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
       
        Debug.WriteLine("blue candle picked up");
        IsDead = true;
    }
}
