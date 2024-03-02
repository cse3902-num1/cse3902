﻿using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles;

public class BlueArrow : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 400f;
    private GameContent content;
    
    public BlueArrow(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity)
    {
        leftSprite = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(0, 15, 15, 15) }, new Vector2(7.5f, 7.5f));
        rightSprite = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(36, 185, 15, 15) }, new Vector2(7.5f, 7.5f));
        upSprite = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(27, 185, 7, 15) }, new Vector2(3.5f, 8.5f));
        downSprite = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(15, 15, 15, 15) }, new Vector2(7.5f, 7.5f));

        initialPosition = position;

        this.content = content;
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new ArrowExplode(content, Position);
        /* TODO: "spawn" the particle effect in the level */
    }

    public override void Update(GameTime gameTime, IController controller)
    {
        base.Update(gameTime, controller);

        if (Vector2.Distance(initialPosition, Position) > maxDistance)
        {
            Die();
        }
    }
}
