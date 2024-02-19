using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class GreenBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;

    public GreenBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenBoomerang projectile = new GreenBoomerang(content, direction * 200f, player.Position);
        player.SpawnProjectile(projectile);
    }
}