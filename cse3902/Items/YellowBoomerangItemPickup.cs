using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class YellowBoomerangItemPickup : BasicItemPickup
{
    private bool isAdded = false;
    public static bool isYellowBoomerangPicked = false;
    public YellowBoomerangItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) });
    }
    public override void Pickup(IPlayer player)
    {
        if (!isAdded)
        {
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isYellowBoomerangPicked = true;
        Debug.WriteLine("yellow boomerang item picked up");
        IsDead = true;
    }
}
