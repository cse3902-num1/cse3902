using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class BlueBombInventoryItem : IInventoryItem
{
    private GameContent content;
    private float positionShift = 20f;

    public BlueBombInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Level level)
    {
        Vector2 direction = player.Facing.asVector2();
        Vector2 position = player.Position + direction * positionShift;
        Bomb bomb = new Bomb(content, level, position);
        SoundManager.Manager.bombDropSound();
        level.Projectiles.Add(bomb);
        bomb.isEnermyProjectile = false;
    }
}