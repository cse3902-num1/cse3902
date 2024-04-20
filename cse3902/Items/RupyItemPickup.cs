using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class RupyItemPickup : BasicItemPickup
{
    private Vector2 rupyItemOrigin = new Vector2(3.5f, 3.5f);
    public RupyItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                                ItemsConstant.RupyItemAnimationSourceRect1 ,
                                ItemsConstant.RupyItemAnimationSourceRect2
                            }, rupyItemOrigin);
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.Rubies += 1;
        Debug.WriteLine("Rubies: " + player.Inventory.Rubies);
        IsDead = true;
    }

}