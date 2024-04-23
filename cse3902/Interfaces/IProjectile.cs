using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Interfaces
{
    public interface IProjectile : IGameObject
    {
        public bool IsDead {get;set;} /* kinda hacky for now, but owner will check for dead projectiles and remove them */
        public Vector2 Velocity { get; set; }
        public bool isEnermyProjectile { get; set; }
        public void Die();
    }
}
