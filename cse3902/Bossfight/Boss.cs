using System;
using System.Collections.Generic;

using System.Diagnostics;

using cse3902.Enemy;
using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class Boss
{
    public Vector2 Position {set;get;}

    private GameContent content;
    public BossfightLevel Level;
    private Sprite boggus;

    private Random random;

    public Boss(GameContent content, BossfightLevel level, Vector2 position) {
        boggus = new Sprite(
            content.boggus,
            new List<Rectangle>()
            {
                new Rectangle(0,0,256,416)
            },
            new Vector2(257f/2, 419f/2),
            0.5f
        );
        this.content = content;
        this.Level = level;
        this.Position = position;

        this.random = new Random();

        projectileTimer.Start();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        boggus.Position = Position;
        boggus.Draw(spriteBatch);
    }

    private Stopwatch projectileTimer = new Stopwatch();
    public void Update(GameTime gameTime, List<IController> controllers)

    //{
        //boggus.Update(gameTime, controllers);
        //Position += new Vector2(1, 0);

    {        
        if (projectileTimer.ElapsedMilliseconds < 1000) return;
        projectileTimer.Restart();

        RingsAttack();
    }

    private void RingsAttack() {
        double offset = 0;
        int count = 32;
        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {
            IBossfightProjectile p1 = SpawnRedProjectile(
                this.Position,
                new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * 150
            );
        }

        offset = random.NextDouble() * Math.Tau * 0.05;
        double gap_width = Math.Tau * 0.25;
        double gap_angle = Math.Tau * 0.25 + ((random.NextDouble() - 0.5)*2 * Math.Tau * 0.2);
        count = 100;
        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {

            if (angle >= gap_angle - gap_width/2 && angle <= gap_angle + gap_width/2) continue;

            IBossfightProjectile p2 = SpawnBlueProjectile(
                this.Position,
                new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * 75
            );
        }
    }

    private IBossfightProjectile SpawnRedProjectile(Vector2 position, Vector2 velocity) {
        IBossfightProjectile p = new BasicBossfightProjectile(content, Level, position, velocity, 16f * 3, new Sprite(
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
        IBossfightProjectile p = new BasicBossfightProjectile(content, Level, position, velocity, 16f * 3, new Sprite(
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