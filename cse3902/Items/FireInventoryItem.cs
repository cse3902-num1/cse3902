using System.Diagnostics;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class FireInventoryItem : IInventoryItem
{
    private GameContent content;

    public FireInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        Fire fire = new Fire(content, room, player.Position, direction * 300f);
        SoundEffect sound = SoundManager.Manager.arrowBoomerangSound();
        sound.Play();
        room.Projectiles.Add(fire);
        fire.isEnermyProjectile = false;
    }

}