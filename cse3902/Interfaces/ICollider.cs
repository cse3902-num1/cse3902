using Microsoft.Xna.Framework;

namespace cse3902.Interfaces;

public interface ICollider
{
    public Vector2 Position {set;get;}
    public ColliderType ColliderType {set;get;}
    public bool IsColliding(ICollider collider);
    
}
