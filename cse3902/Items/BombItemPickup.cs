using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class BombItemPickup : BasicItemPickup
{
    public BombItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(135, 0, 9, 14) });
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.Bombs += 1;
        Debug.WriteLine("Bombs: " + player.Inventory.Bombs);
        IsDead = true;
    }
}
