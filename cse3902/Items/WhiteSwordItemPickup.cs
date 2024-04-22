using cse3902.Items;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class WhiteSwordItemPickup : BasicSlotAPickup
{
    private bool isAdded = false;
    public static bool isWhiteSwordPicked;
    public WhiteSwordItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.WhiteItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<WhiteSwordItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotAItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isWhiteSwordPicked = true;
        Debug.WriteLine("white sword item picked up");
        IsDead = true;
    }
}