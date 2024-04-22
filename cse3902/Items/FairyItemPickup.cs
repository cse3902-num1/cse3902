using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class FairyItemPickup : BasicItemPickup
{
    public FairyItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.FairyItemSourceRect });
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("fairy item picked up");
        IsDead = true;
    }
}
