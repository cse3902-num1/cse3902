using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class MagicalRodItemPickup : BasicItemPickup
{
    public MagicalRodItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.MagicRodItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        //Debug.WriteLine("magic rod picked up");
        IsDead = true;
    }
}