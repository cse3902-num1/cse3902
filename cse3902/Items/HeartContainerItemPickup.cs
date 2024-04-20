using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class HeartContainerItemPickup : BasicItemPickup
{
    public HeartContainerItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.HeartContainerItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.lifeContainer += 1;
        Debug.WriteLine("heart container picked up, heart container is " + player.Inventory.lifeContainer);
        IsDead = true;
    }
}