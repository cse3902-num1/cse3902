using System;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class FireballInventoryItem : IInventoryItem
{
    private GameContent content;
    private float speed = 400f;

    public FireballInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        Fireball fireballProjectile = new Fireball(content, level, player.Position, direction * speed);
        SoundManager.Manager.newFireballSound();
        level.Projectiles.Add(fireballProjectile);
        fireballProjectile.isEnermyProjectile = false;
    }
}