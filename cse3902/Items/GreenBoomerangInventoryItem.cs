using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public class GreenBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;

    public GreenBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenBoomerang projectile = new GreenBoomerang(content, room, player.Position, direction * 200f);
        player.SpawnProjectile(projectile);
    }
}