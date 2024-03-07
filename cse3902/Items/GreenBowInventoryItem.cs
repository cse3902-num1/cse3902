using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public class GreenBowInventoryItem : IInventoryItem
{
    private GameContent content;

    public GreenBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenArrow projectile = new GreenArrow(content, room, player.Position, direction * 300f);
        room.Projectiles.Add(projectile);
    }
}