using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;

namespace cse3902;

public class PurpleCystleInventoryItem : IInventoryItem
{
    public void Use(IPlayer player, Level level)
    {
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
        const int PROJECTILE_DESTRUCTION_COUNT = 3;
        for (int i = 0; i < PROJECTILE_DESTRUCTION_COUNT; i++) {
            float distance = 9999.0f;
            IProjectile closest = null;
            foreach (IProjectile projectile in level.Projectiles) {
                if (projectile.IsDead) continue;

                float d = Vector2.DistanceSquared(projectile.Position, player.Position);
                if (d < distance) {
                    distance = d;
                    closest = projectile;
                }
            }
            if (closest == null) break;
            closest.IsDead = true;
        }
    }
}