using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class FireballInventoryItem : IInventoryItem
{
    private GameContent content;

    public FireballInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        Fireball fireballProjectile = new Fireball(content, room, player.Position, direction * 400f);
        SoundEffect sound = SoundManager.Manager.fireballSound();
        sound.Play();
        room.Projectiles.Add(fireballProjectile);
        fireballProjectile.isEnermyProjectile = false;
    }
}