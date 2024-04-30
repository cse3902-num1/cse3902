using System.Numerics;

namespace cse3902.Bossfight;

public interface IBossfightProjectile {
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public float Radius {set;get;}
    public Sprite sprite {set;get;}
}