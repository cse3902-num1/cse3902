using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossStateCircleAttack : IBossState
{
    private Boss boss;
    private GameContent content;
    private Sprite sprite;

    private Timer stageTimer;
    private Timer attackTimer;
    private Timer endTimer;

    private int state = 0;

    public BossStateCircleAttack(GameContent content, Boss boss) {
        this.boss = boss;
        this.content = content;

        stageTimer = new Timer();
        stageTimer.Start(0);

        attackTimer = new Timer();
        attackTimer.Start(0);

        endTimer = new Timer();

        sprite = new Sprite(content.boggus,
            new List<Rectangle>()
            {
                BossConstant.bossSprite
            },
            new Vector2(257f/2, 419f/2),
            BossConstant.bossScale
        );
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = boss.Position;
        sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        const double STAGE_TIME = 10;
        const double END_TIME = 1;
        const double ATTACK_INTERVAL = 1;

        attackTimer.Update(gameTime);
        stageTimer.Update(gameTime);
        endTimer.Update(gameTime);
        
        sprite.Update(gameTime, controllers);

        if (boss.IsBossPlayerColliding()) boss.Level.player.Health -= 999;


        if (state == 0) {

            double angle = Math.Tau * stageTimer.Time / STAGE_TIME; // make boss take 4 seconds to complete orbit
            Vector2 p = new Vector2(0, -350);
            float px = p.X;
            float py = p.Y;
            p.X = (float) (Math.Cos(angle) * px - Math.Sin(angle) * py);
            p.Y = (float) (Math.Sin(angle) * px + Math.Cos(angle) * py);
            // p.Y = -350 + (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.5) * 50;
            // p.X = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds * 1.0) * 350;
            // p.Y = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.0) * 350;
            boss.Position = p;

            if (attackTimer.Time >= ATTACK_INTERVAL) {
                attackTimer.Start(0);
                RingsAttack();
            }

            if (stageTimer.Time >= STAGE_TIME) {
                endTimer.Start(0);
                state++;
            }

        } else if (state == 1) {
            /* kill bullets within a range of the center (0, 0), where the range is a function of the endTimer time */
            float maxDistance = BossfightLevel.WORLD_WIDTH * (float)(endTimer.Time / END_TIME);
            boss.Level.projectiles.ForEach(p => {
                if (!p.IsEnemy) return;
                if (Vector2.DistanceSquared(p.Position, new Vector2(0, 0)) <= maxDistance * maxDistance) {
                    p.IsDead = true;
                }
            });

            if (endTimer.Time >= END_TIME) {
                state++;
            }
        } else {
            /* kill all bullets left */
            boss.Level.projectiles.ForEach(p => { if (p.IsEnemy) p.IsDead = true; });

            /* transition to next state */
            boss.State = new BossStateStart(content, boss);
        }
    }

    public void OnTakeDamage(int damage)
    {
        boss.Health -= damage;
    }
    private void RingsAttack() {
        double offset = boss.random.NextDouble() * Math.Tau;
        int count = 32;
        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {
            IBossfightProjectile p1 = boss.SpawnRedProjectile(
                boss.Position,
                new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * 150
            );
        }

        
        for (int speed = 200; speed >= 0; speed -= 10) {
            IBossfightProjectile p1 = boss.SpawnBlueProjectile(
                boss.Position,
                Vector2.Normalize(boss.Level.player.Position - boss.Position) * speed
            );
            IBossfightProjectile p2 = boss.SpawnBlueProjectile(
                boss.Position,
                -Vector2.Normalize(boss.Level.player.Position - boss.Position) * speed
            );
        }
    }
}