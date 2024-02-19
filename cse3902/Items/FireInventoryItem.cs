using System.Diagnostics;

namespace cse3902;

public class FireInventoryItem : IInventoryItem
{
    public void Use(IPlayer player)
    {
        Debug.WriteLine("[info] using fire item");
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}