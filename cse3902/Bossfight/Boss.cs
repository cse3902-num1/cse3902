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
    private Sprite sprite;
    public Rectangle bossHealthBar;
    public int Health = 9999;
    public int MaxHealth = 9999;
    private Random random;

    public Boss(GameContent content, BossfightLevel level, Vector2 position) {
        sprite = new Sprite(content.boggus,
            new List<Rectangle>()
            {
                BossConstant.bossSprite
            },
            new Vector2(257f/2, 419f/2),
            BossConstant.bossScale
        );
        this.content = content;
        this.Level = level;
        this.Position = position;
        
        this.random = new Random();

        projectileTimer.Start();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsDead) return;

        sprite.Position = Position;
        sprite.Draw(spriteBatch);

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

        /* boss-player collision */
        if (!Level.player.IsDead) {
            float minDistance = Radius + Level.player.Radius;
            if (Vector2.DistanceSquared(Position, Level.player.Position) < minDistance * minDistance) {
                Level.player.Health -= 999;
            }
        }

        Vector2 p = Position;
        // p.Y = -350 + (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.5) * 50;
        p.X = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds * 1.0) * 350;
        p.Y = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.0) * 350;
        Position = p;

        if (projectileTimer.ElapsedMilliseconds < 1000) return;
        projectileTimer.Restart();

        RingsAttack();
    }

    private void RingsAttack() {
        double offset = random.NextDouble() * Math.Tau;
        int count = 32;
        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {
            IBossfightProjectile p1 = SpawnRedProjectile(
                this.Position,
                new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * 150
            );
        }

        
        for (int speed = 200; speed >= 0; speed -= 10) {
            IBossfightProjectile p1 = SpawnBlueProjectile(
                this.Position,
                Vector2.Normalize(Level.player.Position - Position) * speed
            );
            IBossfightProjectile p2 = SpawnBlueProjectile(
                this.Position,
                -Vector2.Normalize(Level.player.Position - Position) * speed
            );
        }
    }

    private IBossfightProjectile SpawnRedProjectile(Vector2 position, Vector2 velocity) {
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

    private IBossfightProjectile SpawnBlueProjectile(Vector2 position, Vector2 velocity) {
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