using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class BowItemPickup : BasicSlotAPickup
{
    private bool isAdded = false;
    public BowItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.BowItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<BowItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotAItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        Debug.WriteLine("bow item picked up");
        IsDead = true;
    }
}
