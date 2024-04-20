using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RedCandleItemPickup : BasicItemPickup
{
    public RedCandleItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.RedCandleItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("red candle item picked up");
        IsDead = true;
    }
}