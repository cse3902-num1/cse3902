using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class MagicalSwordItemPickup : BasicSlotBPickup
{
    private bool isAdded = false;
    public static bool isMagicalSwordPicked = false;
    public MagicalSwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<MagicalSwordItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotBItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isMagicalSwordPicked = true;
        Debug.WriteLine("magic sword item picked up");
        IsDead = true;
    }
}