using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MagicalShieldItemPickup : BasicItemPickup
{
    public MagicalShieldItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.MagicShieldItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {
        //Debug.WriteLine("magic shield picked up");
        IsDead = true;
    }
}