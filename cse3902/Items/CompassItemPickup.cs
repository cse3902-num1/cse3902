using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class CompassItemPickUp : BasicItemPickup
{
    public CompassItemPickUp(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(257, 1, 12, 13) });
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.hasCompass = true;
        Debug.WriteLine("Compass picked up");
        IsDead = true;
    }
}
