using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles;

public class Fireball : BasicDirectionalProjectile
{
    private Vector2 FireBallOrigin = new Vector2(4.5f, 9);
    public Fireball(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity)
    {
        leftSprite = new Sprite(content.enemies,
            new List<Rectangle>()
            {
                ProjectileConstant.FireBallAnimationSourceRect1,
                ProjectileConstant.FireBallAnimationSourceRect2,
                ProjectileConstant.FireBallAnimationSourceRect3,
                ProjectileConstant.FireBallAnimationSourceRect4
            },
            FireBallOrigin
        );
        rightSprite = leftSprite; /* lazy but should be fine for now */
        upSprite = leftSprite;
        downSprite = leftSprite;
        Hitbox = new BoxCollider(position, ProjectileConstant.FireBallCollideSize, ProjectileConstant.FireBallCollideOrigin, ColliderType.PROJECTILE);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}