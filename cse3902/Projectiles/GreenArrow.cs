using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles;

public class GreenArrow : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 400f;
    private GameContent content;

    private Vector2 GreenArrowOrigin = new Vector2(7.5f, 7.5f);
    public GreenArrow(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity)
    {
        leftSprite = new Sprite(content.weapon2, new List<Rectangle>() { ProjectileConstant.GreenArrowLeftSourceRect }, GreenArrowOrigin);
        rightSprite = new Sprite(content.weapon, new List<Rectangle>() { ProjectileConstant.GreenArrowRightSourceRect }, GreenArrowOrigin);
        upSprite = new Sprite(content.weapon, new List<Rectangle>() { ProjectileConstant.GreenArrowUpSourceRect }, GreenArrowOrigin);
        downSprite = new Sprite(content.weapon2, new List<Rectangle>() { ProjectileConstant.GreenArrowDownSourceRect }, GreenArrowOrigin);
        
        initialPosition = position;

        this.content = content;
        this.Hitbox = new BoxCollider(position, ProjectileConstant.GreenArrowCollideSize, ProjectileConstant.GreenArrowCollideOrigin, ColliderType.PROJECTILE);
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new ArrowExplode(content, Position);
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
