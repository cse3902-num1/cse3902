using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public class MagicalBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    
    public MagicalBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        MagicalBoomerang magicBoomerangProjectile = new MagicalBoomerang(content, room, player.Position, direction * 400f);
        room.Projectiles.Add(magicBoomerangProjectile);
        magicBoomerangProjectile.isEnermyProjectile = false;
    }
}