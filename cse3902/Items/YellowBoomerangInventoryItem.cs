using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public class YellowBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;

    public YellowBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        // Vector2 direction = player.Facing.asVector2();
        // YellowBoomerang projectile = new YellowBoomerang(content, direction * 400f, player.Position);
        // player.SpawnProjectile(projectile);
    }
}