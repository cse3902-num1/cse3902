using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Projectiles;

public class Fireball : BasicDirectionalProjectile
{
    private GameContent content;
    private Vector2 initialPosition;
    private const float maxDistance = 800f;
    private Vector2 FireBallOrigin = new Vector2(4.5f, 9);
    public Fireball(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity)
    {
        leftSprite = new Sprite(content.enemies,
            new List<Rectangle>()
            {
                // ProjectileConstant.FireBallAnimationSourceRect1,
                // ProjectileConstant.FireBallAnimationSourceRect2,
                ProjectileConstant.FireBallAnimationSourceRect3,
                ProjectileConstant.FireBallAnimationSourceRect4
            },
            FireBallOrigin
        );
        rightSprite = leftSprite; /* lazy but should be fine for now */
        upSprite = leftSprite;
        downSprite = leftSprite;
        Hitbox = new BoxCollider(position, ProjectileConstant.FireBallCollideSize, ProjectileConstant.FireBallCollideOrigin, ColliderType.PROJECTILE);

        this.initialPosition = position;
        this.content = content;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new ArrowExplode(content, Position);
        level.ParticleEffects.Add(fx);
    }

    public override void Update(GameTime gameTime, List<IController> controllers)
    {
        base.Update(gameTime, controllers);

        if (Vector2.Distance(initialPosition, Position) > maxDistance)
        {
            Die();
        }
    }
}