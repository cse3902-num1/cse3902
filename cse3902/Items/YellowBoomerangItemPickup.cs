using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;


public class YellowBoomerangItemPickup : BasicSlotAPickup
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
        isAdded = PlayerInventory.inventoryItems.OfType<YellowBoomerangItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotAItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isYellowBoomerangPicked = true;
        Debug.WriteLine("yellow boomerang item picked up");
        IsDead = true;
    }
}
