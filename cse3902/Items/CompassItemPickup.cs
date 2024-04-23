using cse3902.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class CompassItemPickUp : BasicItemPickup
{
    public CompassItemPickUp(GameContent content, Level level) : base(level)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.CompassItemSourceRect }, new Vector2(8, 8));
    }
    public override void Pickup(IPlayer player)
    {
        player.Inventory.hasCompass = true;
        //Debug.WriteLine("Compass picked up");
        IsDead = true;
    }
}
