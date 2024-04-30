using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossStateStart : IBossState
{
    private Boss boss;
    private GameContent content;
    private Sprite sprite;

    private Timer timer;

    public BossStateStart(GameContent content, Boss boss) {
        this.boss = boss;
        this.content = content;

        timer = new Timer();
        timer.Start(0);

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
        sprite.Update(gameTime, controllers);

        /* in the start state, the boss doesn't do contact damage */
        // if (boss.IsBossPlayerColliding()) boss.Level.player.Health -= 999;

        /* make boss move up and down */
        Vector2 p = boss.Position;
        p.Y = (float)Math.Cos(gameTime.TotalGameTime.TotalSeconds * 1.0) * 50 + -350;
        boss.Position = p;

        /* transition to next state once time is up */
        timer.Update(gameTime);
        if (timer.Time >= 3) {
            boss.State = new BossStateCircleAttack(content, boss);
        }
    }

    public void OnTakeDamage(int damage)
    {
        /* in the start state, the boss is invulnerable */
        // boss.Health -= damage;
    }
}