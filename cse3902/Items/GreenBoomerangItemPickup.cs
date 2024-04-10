using cse3902.Items;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902;

public class GreenBoomerangItemPickup : BasicItemPickup
{
    public GreenBoomerangItemPickup(GameContent content, Room room) : base(room)
    {
        sprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                       ItemsConstant.GreenBoomerangItemSourceRect});
    }
    public override void Pickup(IPlayer player)
    {

        Debug.WriteLine("Green boomerang item picked up");
        IsDead = true;
    }
}