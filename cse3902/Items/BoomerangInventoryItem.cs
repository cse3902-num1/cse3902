namespace cse3902;

public class BoomerangInventoryItem : IInventoryItem
{
    private IPlayer player;

    public BoomerangInventoryItem(IPlayer player)
    {
        this.player = player;
    }

    public void Use()
    {
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}