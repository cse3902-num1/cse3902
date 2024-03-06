using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class FireballInventoryItem : IInventoryItem
{
    private GameContent content;

    public FireballInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        Fireball projectile = new Fireball(content, player.Position, direction * 400f, player);
        player.SpawnProjectile(projectile);
    }
}