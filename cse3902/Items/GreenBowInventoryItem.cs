using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class GreenBowInventoryItem : IInventoryItem
{
    private GameContent content;

    public GreenBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenArrow projectile = new GreenArrow(content, player.Position, direction * 300f);
        player.SpawnProjectile(projectile);
    }
}