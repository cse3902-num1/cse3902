using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles
{
    internal class ArrowExplode : BasicParticleEffect
    {
        public ArrowExplode(GameContent content, Vector2 position) : base(position)
        {
            sprite = new Sprite(content.weapon,
                new List<Rectangle>()
                {
                    new Rectangle(53, 185, 7, 15)
                },
                new Vector2(3.5f, 7.5f)
            );
        }
    }
}
