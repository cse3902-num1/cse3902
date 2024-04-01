using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class SecondPotionItemPickup : BasicItemPickup
{
    public SecondPotionItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
            new Rectangle(80, 0, 8, 16),
        });
    }
    public override void Pickup(IPlayer player)
    {

        player.Inventory.health = player.Inventory.lifeContainer;
        Debug.WriteLine("life potion picked up, health is " + player.Inventory.health);
        IsDead = true;
    }
}