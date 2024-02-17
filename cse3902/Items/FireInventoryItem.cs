namespace cse3902;

public class FireInventoryItem : IInventoryItem
{
    private IPlayer player;

    public FireInventoryItem(IPlayer player)
    {
        this.player = player;
    }

    public void Use()
    {
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}