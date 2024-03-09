using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class GreenBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 200f;
    public GreenBoomerang(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity, maxDistance)
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
    }
}
