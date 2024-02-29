namespace cse3902;

public enum ColliderType
{
    WALL,
    BLOCK,
    DOOR,
    PLAYER,
    ENEMY,
    ITEM_PICKUP,
    PROJECTILE,
}

/* see https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration */
public static partial class Extensions
{
    public static bool CanCollideWith(this ColliderType a, ColliderType b)
    {
        /* wall collisions */
        if (a == ColliderType.PLAYER && b == ColliderType.WALL) return true;
        if (a == ColliderType.ENEMY && b == ColliderType.WALL) return true;
        if (a == ColliderType.PROJECTILE && b == ColliderType.WALL) return true;

        /* block collisions */
        if (a == ColliderType.PLAYER && b == ColliderType.BLOCK) return true;
        if (a == ColliderType.ENEMY && b == ColliderType.BLOCK) return true;

        /* door collisions */
        if (a == ColliderType.PLAYER && b == ColliderType.DOOR) return true;

        /* item collisions */
        if (a == ColliderType.PLAYER && b == ColliderType.ITEM_PICKUP) return true;

        /* projectile collisions */
        if (a == ColliderType.PROJECTILE && b == ColliderType.PLAYER) return true;
        if (a == ColliderType.PROJECTILE && b == ColliderType.ENEMY) return true;

        return false;
    }
}