using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MagicalSwordItemPickup : BasicSwordPickup
{
    public static bool isMagicalSwordPicked = false;
    public MagicalSwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        isMagicalSwordPicked = true;
        Debug.WriteLine("magic sword item picked up");
        IsDead = true;
    }
}