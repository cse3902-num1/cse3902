using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class GreenBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    private float directionShift = 200f;
    public GreenBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenBoomerang greenBoomerangProjectile = new GreenBoomerang(content, level, player.Position, direction * directionShift);
        SoundManager.Manager.arrowBoomerangSound();
        level.Projectiles.Add(greenBoomerangProjectile);
        greenBoomerangProjectile.isEnermyProjectile = false;
    }
}