using System;
using System.Diagnostics;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class FireInventoryItem : IInventoryItem
{
    private GameContent content;
    private float speed = 300f;

    public FireInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        /* spawn a ring of fireballs */
        int count = 8;
        for (double angle = 0; angle < Math.Tau; angle += Math.Tau / count) {
            Vector2 velocity = new Vector2((float) Math.Sin(angle), (float) Math.Cos(angle)) * speed;
            Fire f = new Fire(content, level, player.Position, velocity);
            f.isEnermyProjectile = false;
            level.Projectiles.Add(f);
        }
        SoundManager.Manager.newFireballSound();
        // Vector2 direction = player.Facing.asVector2();
        // Fire fire = new Fire(content, level, player.Position, direction * speed);
        // SoundManager.Manager.arrowBoomerangSound();
        // level.Projectiles.Add(fire);
        // fire.isEnermyProjectile = false;
    }

}