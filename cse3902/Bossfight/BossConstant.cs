using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Bossfight
{
    public  class BossConstant
    {
        public static Rectangle bossSprite = new Rectangle(0,0,256,416);
        public static float bossScale = 0.5f;

        public static Vector2 RotateVector2(Vector2 v, double angle) {
            Vector2 p = v;
            p.X = (float) (Math.Cos(angle) * v.X - Math.Sin(angle) * v.Y);
            p.Y = (float) (Math.Sin(angle) * v.X + Math.Cos(angle) * v.Y);
            return p;
        }
    }
}
