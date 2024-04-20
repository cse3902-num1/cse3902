using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class HeartItemPickup : BasicItemPickup
{
    public HeartItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(0, 8, 7, 7) ,
                        new Rectangle(0, 0, 7, 7)},new Vector2(3.5f,3.5f));
    }
    public override void Pickup(IPlayer player)
    {
        if (player.Inventory.health < player.Inventory.lifeContainer) {
            player.Inventory.health += 1;
        }
             
        Debug.WriteLine("heart picked up, health is "+ player.Inventory.health);
        IsDead = true;
    }
}