using System.Drawing;
using cse3902.Interfaces;

namespace cse3902;

public class BoxCollider : ICollider
{
    public ColliderType ColliderType {set;get;}
    private Rectangle rectangle;

    public BoxCollider(Rectangle rectangle, ColliderType type)
    {
        this.rectangle = rectangle;
        this.ColliderType = type;
    }

    public bool IsColliding(ICollider collider)
    {
        if (!ColliderType.CollidesWith(collider.ColliderType)) return false;

        switch (collider)
        {
            case BoxCollider boxCollider: return rectangle.Contains(boxCollider.rectangle);
            /* if we had other collider types, their collision checks would be added here */
        }

        return false;
    }
}