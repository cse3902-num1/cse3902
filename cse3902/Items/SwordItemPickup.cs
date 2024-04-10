using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Items;
using cse3902.PlayerClasses;
using System.Linq;

namespace cse3902;

public class SwordItemPickup : BasicSlotBPickup
{
    private bool isAdded = false;
    public static bool swordIsPicked = false;
    public SwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<SwordItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        swordIsPicked = true;
        Debug.WriteLine("sword item picked up");
        IsDead = true;
    }
}