using cse3902.Items;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class MagicalSwordItemPickup : BasicSlotAPickup
{
    private bool isAdded = false;
    public static bool isMagicalSwordPicked = false;
    public MagicalSwordItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.MagicSwordItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<MagicalSwordItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotAItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        isMagicalSwordPicked = true;
        Debug.WriteLine("magic sword item picked up");
        IsDead = true;
    }
}