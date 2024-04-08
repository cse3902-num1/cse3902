using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Items;

namespace cse3902;

public class SwordItemPickup : BasicSwordPickup
{
    public static bool swordIsPicked = false;
    public SwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        swordIsPicked = true;
        Debug.WriteLine("sword item picked up");
        IsDead = true;
    }
}