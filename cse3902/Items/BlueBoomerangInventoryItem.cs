using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class BlueBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    
    public BlueBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        BlueBoomerang projectile = new BlueBoomerang(content, direction * 400f, player.Position);
        player.SpawnProjectile(projectile);
    }
}