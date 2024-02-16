namespace cse3902;

public class YellowBoomerangInventoryItem : IInventoryItem
{
    private IPlayer player;

    public YellowBoomerangInventoryItem(IPlayer player)
    {
        this.player = player;
    }

    public void Use()
    {
        /* TODO: instantiate the projectile */
        /* TODO: call something like SpawnProjectile() on player */
    }
}