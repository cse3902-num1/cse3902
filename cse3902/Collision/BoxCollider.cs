using Microsoft.Xna.Framework;
using cse3902.Interfaces;
using System;
namespace cse3902;

public class BoxCollider : ICollider
{
    public bool IsEnabled {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Size {set;get;}
    public Vector2 Origin {set;get;}
    public ColliderType ColliderType {set;get;}
    
    public BoxCollider(Vector2 position, Vector2 size, Vector2 origin, ColliderType type)
    {
        IsEnabled = true;
        Position = position;
        Size = size;
        Origin = origin;
        ColliderType = type;
    }

    public bool IsColliding(ICollider collider)
    {
        if (!IsEnabled) return false;

        if (collider is null) return false;

        switch (collider)
        {
            case BoxCollider b:
                /* AABB intersection test */
                float aleft = Position.X - Origin.X;
                float aright = aleft + Size.X;
                float atop = Position.Y - Origin.Y;
                float abottom = atop + Size.Y;

                float bleft = b.Position.X - b.Origin.X;
                float bright = bleft + b.Size.X;
                float btop = b.Position.Y - b.Origin.Y;
                float bbottom = btop + b.Size.Y;

                if (aleft >= bright) return false;
                if (aright <= bleft) return false;
                if (atop >= bbottom) return false;
                if (abottom <= btop) return false;

                return true;
            
            default:
                throw new NotImplementedException("Unhandled collider type " + collider.GetType().Name);
        }
    }
    public Vector2 GetOverlap(ICollider collider)
    {
        switch (collider)
        {
            case BoxCollider b:
                float aleft = Position.X - Origin.X;
                float aright = aleft + Size.X;
                float atop = Position.Y - Origin.Y;
                float abottom = atop + Size.Y;

                float bleft = b.Position.X - b.Origin.X;
                float bright = bleft + b.Size.X;
                float btop = b.Position.Y - b.Origin.Y;
                float bbottom = btop + b.Size.Y;

                return new Vector2(Math.Min(Math.Abs(aright - bleft),Math.Abs(bright -aleft)), Math.Min(Math.Abs(atop - bbottom),Math.Abs(btop - abottom)));

            default:
                throw new NotImplementedException("Unhandled collider type " + collider.GetType().Name);
        }
    }
}