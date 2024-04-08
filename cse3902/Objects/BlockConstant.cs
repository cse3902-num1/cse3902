using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Objects
{
    public class BlockConstant
    {
        public static readonly Vector2 ColliderScale = new Vector2(16, 16) * 3;
        public static readonly Vector2 ColliderOffset = new Vector2(8, 8) * 3;
        public static readonly Vector2 SpriteOrigin = new Vector2(8, 8);
        public static readonly float SpriteScale = 3.0f;
        public static Rectangle BlockSprite1 = new Rectangle(2, 11, 16, 16);
        public static Rectangle BlockSprite2 = new Rectangle(19, 11, 16, 16);
        public static Rectangle BlockSprite3 = new Rectangle(36, 11, 16, 16);
        public static Rectangle BlockSprite4 = new Rectangle(53, 11, 16, 16);
        public static Rectangle BlockSprite5 = new Rectangle(19, 28, 16, 16);
        public static Rectangle BlockSprite6 = new Rectangle(36, 28, 16, 16);
        public static Rectangle BlockSprite7 = new Rectangle(53, 28, 16, 16);
    }
}
