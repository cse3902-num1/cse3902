using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class FireballInventoryItem : IInventoryItem
{
    private GameContent content;
    private float directionShift = 400f;

    public FireballInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        Fireball fireballProjectile = new Fireball(content, room, player.Position, direction * directionShift);
        SoundManager.Manager.fireballSound();
        room.Projectiles.Add(fireballProjectile);
        fireballProjectile.isEnermyProjectile = false;
    }
}