using cse3902.Items;

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class KeyItemPickup : BasicItemPickup
{
    public KeyItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                         ItemsConstant.KeyItemSourceRect });
    }

    public override void Pickup(IPlayer player)
    {
        player.Inventory.Keys += 1;
        //Debug.WriteLine("Keys: " + player.Inventory.Keys);
        IsDead = true;
        
    }
}