using cse3902.Interfaces;

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles;

public class BlueArrow : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 400f;
    private GameContent content;
    private Vector2 blueArrowOrigin = new Vector2(7.5f,7.5f);
    
    public BlueArrow(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity)
    {
        leftSprite = new Sprite(content.weapon2, new List<Rectangle>() { ProjectileConstant.BlueArrowLeftSourceRect }, blueArrowOrigin);
        rightSprite = new Sprite(content.weapon, new List<Rectangle>() { ProjectileConstant.BlueArrowRightSourceRect}, blueArrowOrigin);
        upSprite = new Sprite(content.weapon, new List<Rectangle>() { ProjectileConstant.BlueArrowUpSourceRect }, blueArrowOrigin);
        downSprite = new Sprite(content.weapon2, new List<Rectangle>() { ProjectileConstant.BlueArrowDownSourceRect }, blueArrowOrigin);

        initialPosition = position;

        this.content = content;
        this.Hitbox = new BoxCollider(position, ProjectileConstant.BlueArrowCollideSize, ProjectileConstant.BlueArrowCollideOrigin, ColliderType.PROJECTILE);
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new ArrowExplode(content, Position);
        /* TODO: "spawn" the particle effect in the level */
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
