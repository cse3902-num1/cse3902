using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class HeartContainerItemPickup : BasicItemPickup
{
    public HeartContainerItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.HeartContainerItemSourceRect}, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.lifeContainer += 1;
        //Debug.WriteLine("heart container picked up, heart container is " + player.Inventory.lifeContainer);
        IsDead = true;
    }
}