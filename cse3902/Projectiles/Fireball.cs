using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

public class Fireball : BasicDirectionalProjectile
{
    public Fireball(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity)
    {
        leftSprite= new Sprite(content.enemies, 
            new List<Rectangle>()
            {
                new Rectangle(100, 11, 9, 18),
                new Rectangle(109, 11, 9, 18),
                new Rectangle(118, 11, 9, 18),
                new Rectangle(127, 11, 9, 18)
            },
            new Vector2(4.5f, 9)
        );
        rightSprite = leftSprite; /* lazy but should be fine for now */
        upSprite = leftSprite;
        downSprite = leftSprite;
    }
}
