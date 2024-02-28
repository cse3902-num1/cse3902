namespace cse3902.Interfaces;

public interface ICollider
{
    public ColliderType ColliderType {set;get;}
    public bool IsColliding(ICollider collider);
}
