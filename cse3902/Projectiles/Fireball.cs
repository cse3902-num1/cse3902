using System.Collections.Generic;
using System.Diagnostics;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles;

public class Fireball : BasicDirectionalProjectile
{
    public Fireball(GameContent content, Room room, Vector2 position, Vector2 velocity) : base(room, position, velocity)
    {
        leftSprite = new Sprite(content.enemies,
            new List<Rectangle>()
            {
                new Rectangle(101, 14, 8, 10),
                new Rectangle(110, 14, 8, 10),
                new Rectangle(119, 14, 8, 10),
                new Rectangle(128, 14, 8, 10)
            },
            new Vector2(4.5f, 9)
        );
        rightSprite = leftSprite; /* lazy but should be fine for now */
        upSprite = leftSprite;
        downSprite = leftSprite;
        Hitbox = new BoxCollider(position, new Vector2(8, 10), new Vector2(4, 5), ColliderType.PROJECTILE);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}