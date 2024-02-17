namespace cse3902;

public class PurpleCystleInventoryItem : IInventoryItem
{
    private IPlayer player;

    public PurpleCystleInventoryItem(IPlayer player)
    {
        this.player = player;
    }

    public void Use()
    {
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}