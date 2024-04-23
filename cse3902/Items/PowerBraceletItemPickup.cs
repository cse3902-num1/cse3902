using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class PowerBraceletItemPickup : BasicItemPickup
{
    public PowerBraceletItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.PowerBraceletItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {

        //Debug.WriteLine("power bracelet item picked up");
        IsDead = true;
    }
}
