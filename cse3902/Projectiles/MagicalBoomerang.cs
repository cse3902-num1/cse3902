using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class MagicalBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 300f;
    private Vector2 MagicalBoomeringOrigin = new Vector2(10, 16);
    public MagicalBoomerang(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity, maxDistance)
    {
        sprite = new Sprite(content.blueBoomerang,
            new List<Rectangle>()
            {
                ProjectileConstant.MagicalBoomerangAnimationSourceRect1,
                ProjectileConstant.MagicalBoomerangAnimationSourceRect2,
                ProjectileConstant.MagicalBoomerangAnimationSourceRect3
            },
            MagicalBoomeringOrigin
        );
        Hitbox = new BoxCollider(position, ProjectileConstant.MagicalBoomerangCollideSize, ProjectileConstant.BlueArrowCollideOrigin, ColliderType.PROJECTILE);
    }
}
