using cse3902.Interfaces;
using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class BlueBowInventoryItem: IInventoryItem
{
    private GameContent content;
    public BlueBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        BlueArrow blueArrowProjectile = new BlueArrow(content, room, player.Position, direction * 400f);
        SoundManager.Manager.arrowBoomerangSound();
        room.Projectiles.Add(blueArrowProjectile);
        blueArrowProjectile.isEnermyProjectile = false;
    }
}