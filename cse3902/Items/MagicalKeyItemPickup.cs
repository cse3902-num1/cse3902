using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MagicalKeyItemPickup : BasicItemPickup
{
    public MagicalKeyItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.MagicKeyItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {
        Debug.WriteLine("magic key picked up");
        IsDead = true;
    }
}