using System.Drawing;
using Microsoft.Xna.Framework;
using cse3902.Interfaces;

namespace cse3902;

public class BoxCollider : ICollider
{
    private Vector2 position;
    private Vector2 size;

    public Vector2 Position {set;get;}
    public Vector2 Size {set;get;}
    public ColliderType ColliderType {set;get;}
    
    public BoxCollider(Vector2 position, Vector2 size, ColliderType type)
    {
        Position = position;
        Size = size;
        ColliderType = type;
    }

    public bool IsColliding(ICollider collider)
    {
        if (!ColliderType.CanCollideWith(collider.ColliderType)) return false;

        switch (collider)
        {
            // case BoxCollider boxCollider: return rectangle.Contains(boxCollider.rectangle);
            /* TODO: use position and size instead of rectangles */
            
            /* if we had other collider types, their collision checks would be added here */
        }

        return false;
    }
}