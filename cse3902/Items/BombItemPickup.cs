using cse3902.Items;
using cse3902.PlayerClasses;

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class BombItemPickup : BasicSlotBPickup
{
    private bool isAdded = false;
    public BombItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.BombItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<BombItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotBItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        player.Inventory.Bombs += 1;
        Debug.WriteLine("Bombs: " + player.Inventory.Bombs);
        IsDead = true;
    }
}
