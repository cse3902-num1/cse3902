using System;
using System.Collections.Generic;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;

namespace cse3902;

public class CollisionResult<T> {
    public Vector2 Size; /* size of overlap */
    public ICollider Collider; /* collider we collided with */
    public T Entity; /* the owner of the collider that we collided with */

    public CollisionResult(Vector2 size, ICollider collider, T entity)
    {
        Size = size;
        Collider = collider;
        Entity = entity;
    }

    public float GetArea()
    {
        return Math.Abs(Size.X * Size.Y);
    }
}
