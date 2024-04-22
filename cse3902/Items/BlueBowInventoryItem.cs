using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class BlueBowInventoryItem: IInventoryItem
{
    private GameContent content;
    private float speed = 800f;
    public BlueBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        BlueArrow blueArrowProjectile = new BlueArrow(content, level, player.Position, direction * speed);
        SoundManager.Manager.arrowBoomerangSound();
        level.Projectiles.Add(blueArrowProjectile);
        blueArrowProjectile.isEnermyProjectile = false;
    }
}