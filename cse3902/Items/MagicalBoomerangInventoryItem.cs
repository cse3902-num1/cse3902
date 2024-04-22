using cse3902.Projectiles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class MagicalBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    private float directionShift = 600f;
    public MagicalBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        MagicalBoomerang magicBoomerangProjectile = new MagicalBoomerang(content, level, player.Position, direction * 400f);
        SoundManager.Manager.arrowBoomerangSound();
        level.Projectiles.Add(magicBoomerangProjectile);
        magicBoomerangProjectile.isEnermyProjectile = false;
    }
}