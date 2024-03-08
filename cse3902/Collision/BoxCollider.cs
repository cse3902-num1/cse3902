using System.Drawing;
using Microsoft.Xna.Framework;
using cse3902.Interfaces;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System;
namespace cse3902;

public class BoxCollider : ICollider
{

    public Vector2 Position {set;get;}
    public Vector2 Size {set;get;}
    public Vector2 Origin {set;get;}
    public ColliderType ColliderType {set;get;}
    
    public BoxCollider(Vector2 position, Vector2 size, Vector2 origin, ColliderType type)
    {
        Position = position;
        Size = size;
        Origin = origin;
        ColliderType = type;
    }

    public bool IsColliding(ICollider collider)
    {
        // if (!ColliderType.CanCollideWith(collider.ColliderType)) return false;
        if (collider is null) {
            return false;
        }

        switch (collider)
        {
            case BoxCollider b:
                // Debug.WriteLine(string.Format("A: ({0}, {1}, {2}, {3}) B: ({4}, {5}, {6}, {7})",
                //     Position.X, Position.Y, Size.X, Size.Y,
                //     b.Position.X, b.Position.Y, b.Size.X, b.Size.Y
                // ));

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

                /* if we had other collider types, their collision checks would be added here */
        }
        return false;
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
            return new Vector2(Math.Abs(aright - bleft), Math.Abs(atop - bbottom));
        }

        return new Vector2(0,0); // placeHolder
    }
}