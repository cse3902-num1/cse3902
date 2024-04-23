using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class StepLadderItemPickup : BasicItemPickup
{
    public StepLadderItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.StepLadderItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("step ladder item picked up");
        IsDead = true;
    }
}