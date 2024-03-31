using cse3902.Interfaces;

namespace cse3902;

public interface IItemPickup : IGameObject
{
    public ICollider Collider {set;get;}
    public bool IsDead {set;get;}
    public void Pickup(IPlayer player);
}
