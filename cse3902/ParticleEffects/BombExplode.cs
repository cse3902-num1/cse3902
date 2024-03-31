using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Projectiles;

internal class BombExplode : BasicParticleEffect
{
    public BombExplode(GameContent content, Vector2 position) : base(position)
    {
        sprite = new Sprite(content.weapon,
            new List<Rectangle>()
            {
                new Rectangle(138, 185, 15, 15),
                new Rectangle(155, 185, 15, 15),
                new Rectangle(172, 185, 15, 15)
            },
            new Vector2(8f, 8f)
        );
    }
}
