using System;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class GreenBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 200f;
    public GreenBoomerang(GameContent content, Room room, Vector2 position, Vector2 velocity) : base(room, position, velocity, maxDistance)
    {
        sprite = new Sprite(content.enemiesSheet,
            new List<Rectangle>()
            {
                new Rectangle(290, 11, 8, 16),
                new Rectangle(299, 11, 8, 16),
                new Rectangle(308, 11, 8, 16)
            },
            new Vector2(4, 8)
        );
        Hitbox = new BoxCollider(position, new Vector2(8, 16), new Vector2(4, 8), ColliderType.PROJECTILE);
    }


}
