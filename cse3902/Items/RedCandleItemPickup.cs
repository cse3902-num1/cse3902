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
                        new Rectangle(160, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("red candle item picked up");
        IsDead = true;
    }
}