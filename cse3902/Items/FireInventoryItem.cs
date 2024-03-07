using System.Diagnostics;
using cse3902.RoomClasses;

namespace cse3902;

public class FireInventoryItem : IInventoryItem
{
    public void Use(IPlayer player, Room room)
    {
        Debug.WriteLine("[info] using fire item");
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}