using cse3902.Projectiles;
using Microsoft.Xna.Framework;
namespace cse3902;

public class BlueBombInventoryItem : IInventoryItem
{
    private GameContent content;

    public BlueBombInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player)
    {
        Vector2 direction = player.Facing.asVector2();
        Vector2 position = player.Position + direction * 20f;
        Bomb bomb = new Bomb(content, position);
        player.SpawnProjectile(bomb);
    }
}