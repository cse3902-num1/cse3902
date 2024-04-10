using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class BombItemPickup : BasicItemPickup
{
    private bool isAdded = false;
    public BombItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.BombItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<BombItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        player.Inventory.Bombs += 1;
        Debug.WriteLine("Bombs: " + player.Inventory.Bombs);
        IsDead = true;
    }
}
