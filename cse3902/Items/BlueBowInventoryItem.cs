using cse3902.Interfaces;
using cse3902.Projectiles;
using Microsoft.Xna.Framework;

namespace cse3902;

public class BlueBowInventoryItem: IInventoryItem
{
    private GameContent content;
    public BlueBowInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        BlueArrow projectile = new BlueArrow(content, direction * 400f);
        projectile.Position = player.Position;
        player.SpawnProjectile(projectile);
    }
}