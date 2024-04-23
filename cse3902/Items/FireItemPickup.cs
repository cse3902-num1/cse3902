using cse3902.Items;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class FireItemPickUp : BasicSlotBPickup
{
    private bool isAdded = false;
    public FireItemPickUp(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.mergedSheet, new List<Rectangle>() {
            ItemsConstant.FireItemAnimationSourceRect1,
             ItemsConstant.FireItemAnimationSourceRect2,
        }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<FireItemPickUp>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotBItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        //Debug.WriteLine("fire picked up");
        IsDead = true;
    }
}