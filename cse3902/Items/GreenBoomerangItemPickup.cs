using cse3902.Items;
using cse3902.PlayerClasses;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902;

public class GreenBoomerangItemPickup : BasicSlotBPickup
{
    private bool isAdded = false;
    public GreenBoomerangItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.GreenBoomerangItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {
        isAdded = PlayerInventory.inventoryItems.OfType<GreenBoomerangItemPickup>().Any();
        if (!isAdded)
        {
            PlayerInventory.slotBItems.Add(this);
            PlayerInventory.inventoryItems.Add(this);
            isAdded = true;
        }
        //Debug.WriteLine("Green boomerang item picked up");
        IsDead = true;
    }
}