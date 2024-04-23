using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class SecondPotionItemPickup : BasicItemPickup
{
    public SecondPotionItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
            ItemsConstant.SecondPotionItemSourceRect,
        });
    }
    public override void Pickup(IPlayer player)
    {

        player.Inventory.health = player.Inventory.lifeContainer;
        //Debug.WriteLine("life potion picked up, health is " + player.Inventory.health);
        IsDead = true;
    }
}