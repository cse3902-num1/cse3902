using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MapItemPickup : BasicItemPickup
{
    public MapItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.MapItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.hasMap = true;
        Debug.WriteLine("map picked up");
        IsDead = true;
    }
}