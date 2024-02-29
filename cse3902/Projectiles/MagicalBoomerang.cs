using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class MagicalBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 300f;
    public MagicalBoomerang(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity, maxDistance)
    {
        sprite = new Sprite(content.blueBoomerang,
            new List<Rectangle>()
            {
                new Rectangle(0, 0, 20, 32),
                new Rectangle(20, 0, 20, 32),
                new Rectangle(0, 32, 20, 32)
            },
            new Vector2(10, 16)
        );
    }
}
