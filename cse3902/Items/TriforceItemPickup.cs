using cse3902.Items;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class TriforceItemPickup : BasicItemPickup
{
    private Vector2 triforceOrigin = new Vector2(3.5f, 3.5f);
    public TriforceItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.TriforceItemAnimationSourceRect1,
                        ItemsConstant.TriforceItemAnimationSourceRect2
                        }, triforceOrigin);
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.Triforce += 1;
        IsDead = true;
    }
}