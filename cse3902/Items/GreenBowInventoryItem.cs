using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class GreenBowInventoryItem : IInventoryItem
{
    private GameContent content;
    private float directionShift = 600f;
    public GreenBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenArrow greenArrowProjectile = new GreenArrow(content, level, player.Position, direction * directionShift);
        SoundManager.Manager.arrowBoomerangSound();
        level.Projectiles.Add(greenArrowProjectile);
        greenArrowProjectile.isEnermyProjectile = false;
    }
}