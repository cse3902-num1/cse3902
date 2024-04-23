using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Enemy;
using Microsoft.Xna.Framework.Audio;
using cse3902.Objects;
using System;


namespace cse3902.Projectiles;

public class Bomb : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public bool isEnermyProjectile { get; set; }
    public ICollider Hitbox; /* set in constructor */
    private ISprite sprite;
    private Stopwatch explodeTimer = new Stopwatch();
    private GameContent content;
    private Level level;
    private Vector2 BombOrigin = new Vector2(3.5f, 7.5f);
    private int ExplodeTime = 1500;
    public Bomb(GameContent content, Level level, Vector2 position)
    {
        sprite = new Sprite(content.weapon, 
            new List<Rectangle>()
            {
                ProjectileConstant.BombSourceRect
            },
            BombOrigin
        );

        Position = position;
        explodeTimer.Start();

        this.content = content;
        this.level = level;
        Hitbox = new BoxCollider(position, ProjectileConstant.BombCollideSize, ProjectileConstant.BombCollideOrigin, ColliderType.ITEM_PICKUP);
        Hitbox.IsEnabled = false; /* bombs don't collide with anything */
    }

    private void Die()
    {
        SoundManager.Manager.bombBlowUpSound();
        IsDead = true;
        IParticleEffect fx = new BombExplode(content, Position);
        level.ParticleEffects.Add(fx);
        Hitbox.Position = Position;

        const float RANGE = 64.0f;

        /* hurt all enemies within a certain range */
        foreach (IEnemy e in level.Enemies)
        {
            if (Vector2.Distance(e.Position, Position) > RANGE) continue;
            e.TakeDmg(ProjectileConstant.BOMB_DAMAGE);
        }

        /* destroy all blocks within a certain range */
        foreach (Block block in level.Blocks) {
            // if (block.BlockIndex == BlockConstant.BLOCK_TYPE_FLOOR) continue;
            if (block.BlockIndex != BlockConstant.BLOCK_TYPE_WALL) continue;
            if (Math.Abs(block.Position.X - Position.X) > RANGE) continue;
            if (Math.Abs(block.Position.Y - Position.Y) > RANGE) continue;
            // block.IsDead = true;
            block.BlockIndex = BlockConstant.BLOCK_TYPE_FLOOR;
        }

        EventBus.CameraShake(300, 10f);

        IsDead = true;
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        
        sprite.Update(gameTime, controllers);

        if (explodeTimer.ElapsedMilliseconds >= ExplodeTime)
        {
            Die();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }
}
