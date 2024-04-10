using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class WhiteSwordItemPickup : BasicSlotBPickup
{
    private bool isAdded = false;
    public static bool isWhiteSwordPicked;
    public WhiteSwordItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 16, 8, 16) });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<WhiteSwordItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotBItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isWhiteSwordPicked = true;
        Debug.WriteLine("white sword item picked up");
        IsDead = true;
    }
}