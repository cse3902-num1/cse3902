using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace cse3902.Projectiles;

public class Fire : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 200f;
    private Stopwatch lifetime = new Stopwatch();
    private int ttl = 3000;
    private GameContent content;
    private Sprite sprite;
    private Vector2 FireOrigin = new Vector2(7.5f, 7.5f);
    public Fire(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity)
    {
        sprite = new Sprite(content.weapon2,
            new List<Rectangle>()
            {
                ProjectileConstant.FireAnimationSourceRect1,
                ProjectileConstant.FireAnimationSourceRect2
            },
            FireOrigin
        );

        initialPosition = position;
        upSprite = sprite;
        downSprite = sprite;
        leftSprite = sprite;
        rightSprite = sprite;
        this.content = content;
        this.Hitbox = new BoxCollider(position, ProjectileConstant.FireCollideSize, ProjectileConstant.FireCollideOrigin, ColliderType.PROJECTILE);

        this.lifetime.Start();
        this.ttl = ttl;
    }

    public override void Update(GameTime gameTime, List<IController> controllers)
    {

        base.Update(gameTime, controllers);

        Velocity = Vector2.Normalize(Velocity) * (float) Math.Max(Velocity.Length() - 800.0f * gameTime.ElapsedGameTime.TotalSeconds, 0);

        if (Vector2.Distance(initialPosition, Position) > maxDistance)
        {
            Die();
        }

        if (lifetime.ElapsedMilliseconds > ttl) Die();
    }


}
