using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class MagicalBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    
    public MagicalBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        MagicalBoomerang projectile = new MagicalBoomerang(content, direction * 400f, player.Position);
        player.SpawnProjectile(projectile);
    }
}