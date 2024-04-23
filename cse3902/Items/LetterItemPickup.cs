using cse3902.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class LetterItemPickup : BasicItemPickup
{
    public LetterItemPickup(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        ItemsConstant.LetterItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        //Debug.WriteLine("letter picked up");
        IsDead = true;
    }
}