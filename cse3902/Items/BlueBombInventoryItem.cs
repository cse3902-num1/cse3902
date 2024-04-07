using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class BlueBombInventoryItem : IInventoryItem
{
    private GameContent content;

    public BlueBombInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        Vector2 position = player.Position + direction * 20f;
        Bomb bomb = new Bomb(content, room, position);
        SoundManager.Manager.bombDropSound();
        room.Projectiles.Add(bomb);
        bomb.isEnermyProjectile = false;
    }
}