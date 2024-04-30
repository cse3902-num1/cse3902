using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossStateSpiralAttack : IBossState
{
    private Boss boss;
    private GameContent content;
    private Sprite sprite;

    private List<IBossfightProjectile> redProjectiles = new List<IBossfightProjectile>();
    private List<IBossfightProjectile> blueProjectiles = new List<IBossfightProjectile>();

    private int phase = 0;

    public BossStateSpiralAttack(GameContent content, Boss boss) {
        this.boss = boss;
        this.content = content;

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

    private Timer phase1Timer = new Timer(true);
    private Timer phase1AttackInterval = new Timer(true);
    private Timer phase2Timer = new Timer();
    private Timer phase3Timer = new Timer();
    private Timer endTimer = new Timer();
    const double PHASE_1_TIME = 5;
    const double PHASE_1_ATTACK_INTERVAL = 0.15;
    const double PHASE_2_TIME = 5;
    const double PHASE_3_TIME = 3;
    const double END_TIME = 1;
    public void Update(GameTime gameTime, List<IController> controllers)
    {
        phase1Timer.Update(gameTime);
        phase1AttackInterval.Update(gameTime);
        phase2Timer.Update(gameTime);
        phase3Timer.Update(gameTime);
        endTimer.Update(gameTime);
        
        sprite.Update(gameTime, controllers);

        if (boss.IsBossPlayerColliding()) boss.Level.player.Health -= 999;


        if (phase == 0) {

            double offset = phase1Timer.Time / PHASE_1_TIME;
            boss.Position = new Vector2(0, -350);

            if (phase1AttackInterval.Time >= PHASE_1_ATTACK_INTERVAL) {
                SpiralAttack();
                phase1AttackInterval.Start(0);
            }

            if (phase1Timer.Time >= PHASE_1_TIME) {
                phase2Timer.Start(0);
                phase++;
                redProjectiles.ForEach(p => p.AngularVelocity = Math.Tau * -0.02);
                redProjectiles.ForEach(p => p.Velocity = BossConstant.RotateVector2(p.Velocity, Math.Tau * 0.25));
                blueProjectiles.ForEach(p => p.Velocity = new Vector2(0, 0));
            }
        
        } else if (phase == 1) {

            if (phase2Timer.Time >= PHASE_2_TIME) {
                phase3Timer.Start(0);
                phase++;

                Vector2 v = Vector2.Normalize(boss.Level.player.Position - boss.Position);
                blueProjectiles.ForEach(p => p.AngularVelocity = 0);
                blueProjectiles.ForEach(p => p.Velocity = Vector2.Normalize(boss.Level.player.Position - p.Position) * 50); 
            }

        
        } else if (phase == 2) {

            blueProjectiles.ForEach(p => {
                float length = Vector2.Distance(p.Velocity, new Vector2(0, 0));
                Vector2 normal = Vector2.Normalize(p.Velocity);
                length += 15 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                p.Velocity = normal * length;
            });

            if (phase3Timer.Time >= PHASE_3_TIME) {
                endTimer.Start(0);
                phase++;
            }

        } else if (phase == 3) {
            /* kill bullets within a range of the center (0, 0), where the range is a function of the endTimer time */
            float maxDistance = BossfightLevel.WORLD_WIDTH * (float)(endTimer.Time / END_TIME);
            boss.Level.projectiles.ForEach(p => {
                if (!p.IsEnemy) return;
                if (Vector2.DistanceSquared(p.Position, new Vector2(0, 0)) <= maxDistance * maxDistance) {
                    p.IsDead = true;
                }
            });

            if (endTimer.Time >= END_TIME) {
                phase++;
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
    private void SpiralAttack() {
        double offset = phase1Timer.Time / PHASE_1_TIME * Math.Tau;
        int count = 8;
        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {
            IBossfightProjectile p1 = boss.SpawnRedProjectile(
                boss.Position,
                new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)) * 200,
                Math.Tau * 0.01
            );
            redProjectiles.Add(p1);
        }

        for (double angle = 0 + offset; angle < Math.Tau + offset; angle += Math.Tau / count) {
            IBossfightProjectile p1 = boss.SpawnBlueProjectile(
                boss.Position,
                new Vector2((float) Math.Cos(-angle), (float) Math.Sin(-angle)) * 200,
                Math.Tau * -0.01
            );
            blueProjectiles.Add(p1);
        }

        /* vector that points towards the player */
        Vector2 v = Vector2.Normalize(boss.Level.player.Position - boss.Position);
        
        // for (int speed = 200; speed >= 0; speed -= 10) {
        //     IBossfightProjectile p1 = boss.SpawnBlueProjectile(
        //         boss.Position,
        //         v * speed
        //     );
        //     IBossfightProjectile p2 = boss.SpawnBlueProjectile(
        //         boss.Position,
        //         -v * speed
        //     );
        //     localProjectiles.Add(p1);
        //     localProjectiles.Add(p2);
        // }

        // for (int speed = 200; speed >= 0; speed -= 10) {
        //     IBossfightProjectile p1 = boss.SpawnBlueProjectile(
        //         boss.Position,
        //         BossConstant.RotateVector2(v, Math.Tau * 0.25) * speed
        //     );
        //     IBossfightProjectile p2 = boss.SpawnBlueProjectile(
        //         boss.Position,
        //         BossConstant.RotateVector2(-v, Math.Tau * 0.25) * speed
        //     );
        // }
    }
}