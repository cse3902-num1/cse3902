using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class Boss
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    private GameContent content;    
    public BossfightLevel Level;
    public float Radius = 75f;
    public Rectangle bossHealthBar;
    public int Health = 9999;
    public int MaxHealth = 9999;
    public Random random;
    public IBossState State;

    public Boss(GameContent content, BossfightLevel level, Vector2 position) {
        this.content = content;
        this.Level = level;
        this.Position = position;
        
        this.random = new Random();

        projectileTimer.Start();

        this.State = new BossStateStart(content, this);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsDead) return;

        State.Draw(spriteBatch);

        /* draw health bar */
        int margin = 8;
        bossHealthBar = new Rectangle(
            /* x */ -(int)BossfightLevel.WORLD_WIDTH/2 + margin,
            /* y */ -(int)BossfightLevel.WORLD_HEIGHT/2 + margin,
            /* width */ (int) (
                ((int)BossfightLevel.WORLD_WIDTH - 2*margin) * ((float)Health / MaxHealth)
            ),
            /* height */ 8
        );
        spriteBatch.Draw(content.redBackground, bossHealthBar, Color.White);
    }

    private Stopwatch projectileTimer = new Stopwatch();
    public void Update(GameTime gameTime, List<IController> controllers)
    {
        if (IsDead) return;

        if (Health <= 0) IsDead = true;

        State.Update(gameTime, controllers);
    }

    public bool IsBossPlayerColliding() {
        if (Level.player.IsDead) return false;
        float minDistance = Radius + Level.player.Radius;
        if (Vector2.DistanceSquared(Position, Level.player.Position) > minDistance * minDistance) return false;
        return true;
    }

    public void TakeDamage(int damage) {
        State.OnTakeDamage(damage);
    }


    public IBossfightProjectile SpawnRedProjectile(Vector2 position, Vector2 velocity) {
        IBossfightProjectile p = new BasicBossfightProjectile(content, Level, position, velocity, 8f, new Sprite(
            content.enemies,
            new List<Rectangle>()
            {
                ProjectileConstant.FireBallAnimationSourceRect3,
            },
            new Vector2(4.5f, 9)
        ));
        Level.SpawnProjectile(p);
        return p;
    }

    public IBossfightProjectile SpawnBlueProjectile(Vector2 position, Vector2 velocity) {
        IBossfightProjectile p = new BasicBossfightProjectile(content, Level, position, velocity, 8f, new Sprite(
            content.enemies,
            new List<Rectangle>()
            {
                ProjectileConstant.FireBallAnimationSourceRect4
            },
            new Vector2(4.5f, 9)
        ));
        Level.SpawnProjectile(p);
        return p;

    }
}