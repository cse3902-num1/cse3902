﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace cse3902.Projectiles;

internal class GreenBoomerang : BasicBoomerangProjectile
{
    private const float maxDistance = 400f;
    private Vector2 GreenBoomerangOrigin = new Vector2(4, 8);
    public GreenBoomerang(GameContent content, Level level, Vector2 position, Vector2 velocity) : base(level, position, velocity, maxDistance)
    {
        sprite = new Sprite(content.enemiesSheet,
            new List<Rectangle>()
            {
                ProjectileConstant.GreenBoomerangAnimationSourceRect1,
                ProjectileConstant.GreenBoomerangAnimationSourceRect2,
                ProjectileConstant.GreenBoomerangAnimationSourceRect3
            },
            GreenBoomerangOrigin
        );
        Hitbox = new BoxCollider(position, ProjectileConstant.GreenBoomerangCollideSize, ProjectileConstant.GreenBoomerangCollideOrigin, ColliderType.PROJECTILE);
    }


}
