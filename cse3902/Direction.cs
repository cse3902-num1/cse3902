using System;
using Microsoft.Xna.Framework;

namespace cse3902;

public enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}

/* see https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration */
public static partial class Extensions
{
    public static Vector2 asVector2(this Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:  return new Vector2(-1, 0);
            case Direction.Right: return new Vector2(1, 0);
            case Direction.Up:    return new Vector2(0, -1);
            case Direction.Down:  return new Vector2(0, 1);
        }
        /* should never reach here */
        throw new InvalidOperationException("Unhandled direction");
    }
}
